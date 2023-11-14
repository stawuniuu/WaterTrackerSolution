using Microsoft.AspNetCore.Mvc;
using WaterTracker.API.Extensions;
using WaterTracker.API.Repositories.Contracts;
using WaterTracker.Models.Dtos;

namespace WaterTracker.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WaterIntakeController : ControllerBase
{
    private readonly IWaterRepository _waterRepository;

    public WaterIntakeController(IWaterRepository waterRepository)
    {
        _waterRepository = waterRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<WaterIntakeDto>>> GetIntakes()
    {
        try
        {
            var intakes = await _waterRepository.GetIntakes();

            if (intakes == null)
            {
                return NotFound();
            }

            var intakeDtos = intakes.ConvertToDto();

            return Ok(intakeDtos);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from database");
        }
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult<WaterIntakeDto>> GetIntakeById(int id)
    {
        try
        {
            var intake = await _waterRepository.GetIntakeById(id);

            if (intake == null)
            {
                return BadRequest();
            }

            var intakeDto = intake.ConvertToDto();

            return Ok(intakeDto);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from database");
        }
    }

    [HttpGet]
    [Route("user/{id}")]
    public async Task<ActionResult<IEnumerable<WaterIntakeDto>>> GetUserIntakes(int id)
    {
        try
        {
            var intakes = await _waterRepository.GetUserIntakes(id);

            if (intakes == null)
            {
                return BadRequest();
            }

            var intakesDto = intakes.ConvertToDto();

            return Ok(intakesDto);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from database");
        }
    }

    [HttpPost]
    public async Task<ActionResult<WaterIntakeDto>> AddIntake([FromBody] WaterIntakeDto intakeDto)
    {
        try
        {
            var newIntake = await _waterRepository.AddIntake(intakeDto.ConvertFromDto());

            if (newIntake == null)
            {
                return NoContent();
            }

            var result = await _waterRepository.GetIntakeById(newIntake.Id);

            if (result == null)
            {
                throw new Exception($"Something went wrong when attempting to add entry");
            }

            return CreatedAtAction(nameof(GetIntakeById), new { id = result.Id }, result);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Operation error");
        }
    }

    [HttpPut]
    public async Task<ActionResult<WaterIntakeDto>> EditIntake([FromBody] WaterIntakeDto intakeDto)
    {
        try
        {
            var newIntake = await _waterRepository.EditIntake(intakeDto.ConvertFromDto());

            if (newIntake == null)
            {
                return NoContent();
            }

            var result = await _waterRepository.GetIntakeById(newIntake.Id);

            if (result == null)
            {
                throw new Exception($"Something went wrong when attempting to edit entry");
            }

            return CreatedAtAction(nameof(GetIntakeById), new { id = result.Id }, result);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Operation error");
        }
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<ActionResult<WaterIntakeDto>> DeleteIntake(int id)
    {
        try
        {
            var intake = await _waterRepository.DeleteIntake(id);

            if (intake == null)
            {
                return NotFound();
            }

            var intakeDto = intake.ConvertToDto();

            return Ok(intakeDto);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from database");
        }
    }
}