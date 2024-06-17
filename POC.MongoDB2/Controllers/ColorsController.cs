using Microsoft.AspNetCore.Mvc;
using POC.MongoDB2.Data.Repositories;
using POC.MongoDB2.Data.Repositories.Interfaces;
using POC.MongoDB2.Entities;

namespace POC.MongoDB2.Controllers;

[ApiController]
[Route("/api/colors")]
public class ColorsController : ControllerBase
{
    private readonly IColorsRepository _colorsesRepository;

    public ColorsController(IColorsRepository colorsesRepository)
    {
        _colorsesRepository = colorsesRepository;
    }
    
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var colors = await _colorsesRepository.GetAll();
        
        return Ok(colors);
    }
    
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] Color color)
    {
        var addedColor = await _colorsesRepository.Add(color);
        
        return Ok(addedColor);
    }
    
    [HttpDelete("{colorId}")]
    public async Task<IActionResult> Delete([FromRoute] string colorId)
    {
        await _colorsesRepository.Remove(colorId);
        
        return Ok();
    }
    
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] Color color)
    {
        var addedColor = await _colorsesRepository.Update(color);
        
        return Ok(addedColor);
    }
}