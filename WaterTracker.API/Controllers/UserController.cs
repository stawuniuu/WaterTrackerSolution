using Microsoft.AspNetCore.Mvc;
using WaterTracker.API.Extensions;
using WaterTracker.API.Repositories.Contracts;
using WaterTracker.Models.Dtos;

namespace WaterTracker.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserRepository _userRepository;

    public UserController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers()
    {
        try
        {
            var users = await _userRepository.GetUsers();

            if (users == null)
            {
                return NotFound();
            }

            var userDtos = users.ConvertToDto();

            return Ok(userDtos);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from database");
        }
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult<UserDto>> GetUserById(int id)
    {
        try
        {
            var user = await _userRepository.GetUserById(id);

            if (user == null)
            {
                return BadRequest();
            }

            var userDto = user.ConvertToDto();

            return Ok(userDto);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from database");
        }
    }

    [HttpPost]
    public async Task<ActionResult<UserDto>> AddUser([FromBody] UserDto userDto)
    {
        try
        {
            var newUser = await _userRepository.AddUser(userDto.ConvertFromDto());

            if (newUser == null)
            {
                return NoContent();
            }

            var result = await _userRepository.GetUserById(newUser.Id);

            if (result == null)
            {
                throw new Exception($"Something went wrong when attempting to add entry");
            }

            return CreatedAtAction(nameof(GetUserById), new { id = result.Id }, result);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Operation error");
        }
    }

    [HttpPut]
    public async Task<ActionResult<UserDto>> EditUser([FromBody] UserDto userDto)
    {
        try
        {
            var newUser = await _userRepository.EditUser(userDto.ConvertFromDto());

            if (newUser == null)
            {
                return NoContent();
            }

            var result = await _userRepository.GetUserById(newUser.Id);

            if (result == null)
            {
                throw new Exception($"Something went wrong when attempting to edit entry");
            }

            return CreatedAtAction(nameof(GetUserById), new { id = result.Id }, result);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Operation error");
        }
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<ActionResult<UserDto>> DeleteUser(int id)
    {
        try
        {
            var user = await _userRepository.DeleteUser(id);

            if (user == null)
            {
                return NotFound();
            }

            var userDto = user.ConvertToDto();

            return Ok(userDto);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from database");
        }
    }
}