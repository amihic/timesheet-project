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

        private bool IsValidUser(string email, string password)
        {
            var user = _userService.GetUserByEmail(email);
            Console.WriteLine(user.Id);
            if (user == null)
            {
                Unauthorized();
                return false;
            }
            //Console.WriteLine(email);
            return true;
            //Console.WriteLine(email);
            //return false;
        }

        [HttpPost("/login")]
        [AllowAnonymous]
        public IActionResult Login([FromBody] LoginDTO model)
        {
            var user = _userService.GetUserByEmail(model.Email);
            
            
            var token = GenerateJwtToken(model.Email, user.Id);
            return Ok(new { token });
        }


        private string GenerateJwtToken(string email, int id)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, email),
                new Claim("User id", id.ToString()),//id usera koji se ubacuje u token
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
        public IActionResult UpdateCategory([FromBody] UserDTO userDto)
        {
            var userToUpdate = _mapper.Map<UserDTO, User>(userDto);
            _userService.UpdateUser(userToUpdate);

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategory([FromRoute] int id)
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
