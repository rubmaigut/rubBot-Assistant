using Microsoft.EntityFrameworkCore;
using RubBotApi.Data;
using RubBotApi.Models;
using RubBotApi.Util;

public class TasksService: ITasksService
{
    private readonly RubBotContext _context;

    public TasksService(RubBotContext context)
    {
        _context = context;
    }
    
    public Tasks CreateTasks(Tasks tasks)
    {
        _context.Tasks.Add(tasks);
        _context.SaveChanges();
        return tasks;
    }

    public List<Tasks> GetAllTasks()
    {
        return _context.Tasks.ToList();
    }
    
    public Tasks GetTasksById(string taskId)
    {
        return _context.Tasks.FirstOrDefault(p => p.Id == taskId);
    }
    
    public Tasks UpdateTasks(string taskId, Tasks task)
    {
        _context.Entry(task).State = EntityState.Modified;
        _context.SaveChanges();
        return task;
    }
    
    public void DeleteTasks(string taskId)
    {
        var task = _context.Tasks.FirstOrDefault(p => p.Id == taskId);
        if (task != null)
        {
            _context.Tasks.Remove(task);
            _context.SaveChanges();
        }
    }
}