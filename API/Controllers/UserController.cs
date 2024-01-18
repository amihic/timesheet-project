using API.DTO;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TimeSheet.Domain.Helpers;
using TimeSheet.Domain.Interfaces;
using TimeSheet.Domain.Model;
using TimeSheet.Service;

namespace API.Controllers
{
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        private readonly IMapper _mapper;

        public UserController(IMapper mapper, IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
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
        public async Task<IActionResult> GetUsersAsync([FromQuery] SearchParamsDTO searchParams)
        {
            var parameters = _mapper.Map<SearchParamsDTO, SearchParams>(searchParams);

            var users = await _userService.GetUsersAsync(parameters);

            var usersToReturn = _mapper.Map<IEnumerable<User>, IEnumerable<UserDTO>>(users);

            return Ok(usersToReturn);
        }
    }
}
