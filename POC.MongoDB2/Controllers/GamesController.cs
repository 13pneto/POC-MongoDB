using Microsoft.AspNetCore.Mvc;
using POC.MongoDB2.Data.Repositories;
using POC.MongoDB2.Data.Repositories.Interfaces;
using POC.MongoDB2.Entities;

namespace POC.MongoDB2.Controllers;

[ApiController]
[Route("/api/games")]
public class GamesController : ControllerBase
{
    private readonly IGamesRepository _gamesRepository;

    public GamesController(IGamesRepository gamesRepository)
    {
        _gamesRepository = gamesRepository;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var games = await _gamesRepository.GetAll();
        
        return Ok(games);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] Game game)
    {
        var addedGame = await _gamesRepository.Add(game);
        
        return Ok(addedGame);
    }
    
    [HttpDelete("{gameId}")]
    public async Task<IActionResult> Delete([FromRoute] string gameId)
    {
        await _gamesRepository.Remove(gameId);
        
        return Ok();
    }
    
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] Game game)
    {
        var addedGame = await _gamesRepository.Update(game);
        
        return Ok(addedGame);
    }
}