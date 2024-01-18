using RubBotApi.Models;

namespace RubBotApi.Util;

public interface IProjectService
{
    Project CreateProject(Project project);
    List<Project> GetAllProjects();
    Project GetProjectById(string projectId);
    Project UpdateProject(string projectId, Project project);
    void DeleteProject(string projectId);
}