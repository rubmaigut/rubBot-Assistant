using Microsoft.AspNetCore.Mvc;
using RubBotApi.Models;
using RubBotApi.Util;

namespace RubBotApi.Controllers;

[ApiController]
[Route("/[controller]")]

public class AreaController: ControllerBase
{
    private readonly IAreaService _areaService;

    public AreaController(IAreaService areaService)
    {
        _areaService = areaService;
    }

    [HttpGet]
    public IActionResult GetAreas()
    {
        var areas = _areaService.GetAllAreas();
        return Ok(areas);
    }

    [HttpGet("{areaId}")]
    public IActionResult GetArea(string areaId)
    {
        var area = _areaService.GetAreaById(areaId);
        if (area == null)
            return NotFound();

        return Ok(area);
    }

    [HttpPost]
    public IActionResult CreateArea([FromBody] Area area)
    {
        var createdArea = _areaService.CreateArea(area);
        return CreatedAtAction(nameof(GetArea), new { areaId = createdArea.Id }, createdArea);
    }
    
    [HttpPut("{areaId}")]
    public IActionResult UpdateArea(string areaId,[FromBody] Area area)
    {
        var updateArea = _areaService.UpdateArea(areaId, area);
        return updateArea is null ? NotFound() : Ok(updateArea);
    }

    [HttpDelete("{areaId}")]
    public IActionResult DeleteArea(string areaId)
    {
        _areaService.DeleteArea(areaId);
        return StatusCode(202);
    }

}