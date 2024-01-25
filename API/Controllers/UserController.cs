using API.DTO;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using TimeSheet.Domain.Helpers;
using TimeSheet.Domain.Interfaces;
using TimeSheet.Domain.Model;
using TimeSheet.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNet.Identity;

namespace API.Controllers
{
    //[Authorize(Roles = "Admin")]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IJwtService _jwtService;


        public UserController(IMapper mapper, IUserService userService, IConfiguration configuration, IJwtService jwtService)
        {
            _mapper = mapper;
            _userService = userService;
            _configuration = configuration;
            _jwtService = jwtService;
        }

        [HttpPost("/login")]
        [AllowAnonymous]
        public IActionResult Login([FromBody] LoginDTO model)
        {
            var user = _mapper.Map<LoginDTO, User>(model);

            var userToLogIn = _userService.GetUserByEmail(user);

            var token = GenerateJwtToken(userToLogIn);
            return Ok(new { token });
        }

        private string GenerateJwtToken(User user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim("UserId", user.Id.ToString()),//id usera koji se ubacuje u token
                new Claim("Role", user.Role.ToString())
            };

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(_configuration["Jwt:ExpireMinutes"])),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] CreateUserDTO newUserDto)
        {
            var newUser = _mapper.Map<CreateUserDTO, User>(newUserDto);
            _userService.CreateUser(newUser);

            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateUser([FromBody] UserDTO userDto)
        {
            var userToUpdate = _mapper.Map<UserDTO, User>(userDto);
            _userService.UpdateUser(userToUpdate);

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser([FromRoute] int id)
        {
            _userService.DeleteUser(id);

            return Ok();
        }

        [HttpGet("/allUsers")]
        public async Task<IActionResult> GetUsersAsync([FromQuery] SearchParamsForCliCatProUseDTO searchParams)
        {
            var parameters = _mapper.Map<SearchParamsForCliCatProUseDTO, SearchParams>(searchParams);

            var users = await _userService.GetUsersAsync(parameters);

            var usersToReturn = _mapper.Map<IEnumerable<User>, IEnumerable<UserDTO>>(users);

            return Ok(usersToReturn);
        }
    }
}
