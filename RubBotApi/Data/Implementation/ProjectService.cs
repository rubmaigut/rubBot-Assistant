using Microsoft.EntityFrameworkCore;
using RubBotApi.Data;
using RubBotApi.Models;
using RubBotApi.Util;

public class ProjectService: IProjectService
{
    private readonly RubBotContext _context;

    public ProjectService(RubBotContext context)
    {
        _context = context;
    }
    
    public Project CreateProject(Project project)
    {
        _context.Projects.Add(project);
        _context.SaveChanges();
        return project;
    }
    
    public List<Project> GetAllProjects()
    {
        return _context.Projects.ToList();
    }
    
    public Project GetProjectById(string projectId)
    {
        return _context.Projects.FirstOrDefault(p => p.Id == projectId);
    }

    public Project UpdateProject(string projectId, Project project)
    {
        _context.Entry(project).State = EntityState.Modified;
        _context.SaveChanges();
        return project;
    }
    
    public void DeleteProject(string projectId)
    {
        var project = _context.Projects.FirstOrDefault(p => p.Id == projectId);
        if (project != null)
        {
            _context.Projects.Remove(project);
            _context.SaveChanges();
        }
    }
}