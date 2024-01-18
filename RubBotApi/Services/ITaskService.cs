using RubBotApi.Models;

namespace RubBotApi.Util;

public interface ITasksService
{
    Tasks CreateTasks(Tasks task);
    List<Tasks> GetAllTasks();
    Tasks GetTasksById(string taskId);
    Tasks UpdateTasks(string taskId, Tasks task);
    void DeleteTasks(string taskId);
}