using Microsoft.AspNetCore.Mvc;
using RubBotApi.Models;
using RubBotApi.Util;

namespace RubBotApi.Controllers;

[ApiController]
[Route("/[controller]")]

public class ProjectController: ControllerBase
{
    private readonly IProjectService _projectService;

    public ProjectController(IProjectService projectService)
    {
        _projectService = projectService;
    }

    [HttpGet]
    public IActionResult GetProjects()
    {
        var projects = _projectService.GetAllProjects();
        return Ok(projects);
    }

    [HttpGet("{projectId}")]
    public IActionResult GetProject(string projectId)
    {
        var project = _projectService.GetProjectById(projectId);
        if (project == null)
            return NotFound();

        return Ok(project);
    }

    [HttpPost]
    public IActionResult CreateProject([FromBody] Project project)
    {
        var createdProject = _projectService.CreateProject(project);
        return CreatedAtAction(nameof(GetProject), new { projectId = createdProject.Id }, createdProject);
    }
    
    [HttpPut("{id}")]
    public IActionResult UpdateProject(string projectId,[FromBody] Project project)
    {
        var updateProject = _projectService.UpdateProject(projectId, project);
        return updateProject is null ? NotFound() : Ok(updateProject);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteProject(string projectId)
    {
        _projectService.DeleteProject(projectId);
        return StatusCode(202);
    }
}