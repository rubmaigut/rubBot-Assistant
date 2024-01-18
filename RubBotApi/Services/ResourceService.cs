using Microsoft.EntityFrameworkCore;
using RubBotApi.Data;
using RubBotApi.Models;
using RubBotApi.Util;

public class ResourceService: IResourceService
{
    private readonly RubBotContext _context;

    public ResourceService(RubBotContext context)
    {
        _context = context;
    }
    
    public Resource CreateResource(Resource resource)
    {
        _context.Resources.Add(resource);
        _context.SaveChanges();
        return resource;
    }
    
    public List<Resource> GetAllResources()
    {
        return _context.Resources.ToList();
    }
    
    public Resource GetResourceById(string resourceId)
    {
        return _context.Resources.FirstOrDefault(r => r.Id == resourceId);
    }
    
    public Resource UpdateResource(string resourceId, Resource resource)
    {
        _context.Entry(resource).State = EntityState.Modified;
        _context.SaveChanges();
        return resource;
    }
    
    public void DeleteResource(string resourceId)
    {
        var resource = _context.Resources.FirstOrDefault(p => p.Id == resourceId);
        if (resource != null)
        {
            _context.Resources.Remove(resource);
            _context.SaveChanges();
        }
    }
}