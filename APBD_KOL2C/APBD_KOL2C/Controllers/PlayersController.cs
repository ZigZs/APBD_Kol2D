using APBD_KOL2C.DTO;
using APBD_KOL2C.Exceptions;
using APBD_KOL2C.Services;
using Microsoft.AspNetCore.Mvc;

namespace APBD_KOL2C.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PlayersController : ControllerBase
{
    private readonly IPlayerService _playerService;

    public PlayersController(IPlayerService playerService)
    {
        _playerService = playerService;
    }

    [HttpGet("{id}/matches")]
    public async Task<IActionResult> GetCustomerPurchases(int id)
    {
        try
        {
            var result = await _playerService.GetPlayerMatches(id);
            return Ok(result);
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    /*[HttpPost]
    public async Task<IActionResult> AddPlayerWithPlayerMatch([FromBody] PostPlayerWithPlayerMatchDto dto)
    {
        try
        {
            await _playerService.AddPlayerWithPlayerMatches(dto);
            return Created(String.Empty, dto);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }*/
}