using Microsoft.AspNetCore.Mvc;
using RubBotApi.Models;
using RubBotApi.Util;

namespace RubBotApi.Controllers;

[ApiController]
[Route("/[controller]")]

public class ResourceController: ControllerBase
{
    private readonly IResourceService _resourceService;

    public ResourceController(IResourceService resourceService)
    {
        _resourceService = resourceService;
    }

    [HttpGet]
    public IActionResult GetResources()
    {
        var resources = _resourceService.GetAllResources();
        return Ok(resources);
    }

    [HttpGet("{resourceId}")]
    public IActionResult GetResource(string resourceId)
    {
        var resource = _resourceService.GetResourceById(resourceId);
        if (resource == null)
            return NotFound();

        return Ok(resource);
    }

    [HttpPost]
    public IActionResult CreateResource([FromBody] Resource resource)
    {
        var createdResource = _resourceService.CreateResource(resource);
        return CreatedAtAction(nameof(GetResource), new { resourceId = createdResource.Id }, createdResource);
    }
    
    [HttpPut("{resourceId}")]
    public IActionResult UpdateResource(string resourceId,[FromBody] Resource resource)
    {
        var updateResource = _resourceService.UpdateResource(resourceId, resource);
        return updateResource is null ? NotFound() : Ok(updateResource);
    }

    [HttpDelete("{resourceId}")]
    public IActionResult DeleteResource(string resourceId)
    {
        _resourceService.DeleteResource(resourceId);
        return StatusCode(202);
    }

}