using Microsoft.EntityFrameworkCore;
using RubBotApi.Data;
using RubBotApi.Models;
using RubBotApi.Util;

public class AreaService: IAreaService
{
    private readonly RubBotContext _context;

    public AreaService(RubBotContext context)
    {
        _context = context;
    }
    
    public Area CreateArea(Area area)
    {
        _context.Areas.Add(area);
        _context.SaveChanges();
        return area;
    }
    
    public List<Area> GetAllAreas()
    {
        return _context.Areas.ToList();
    }
    
    public Area GetAreaById(string areaId)
    {
        return _context.Areas.FirstOrDefault(r => r.Id == areaId);
    }
    
    public Area UpdateArea(string areaId, Area area)
    {
        _context.Entry(area).State = EntityState.Modified;
        _context.SaveChanges();
        return area;
    }
    
    public void DeleteArea(string areaId)
    {
        var area = _context.Areas.FirstOrDefault(p => p.Id == areaId);
        if (area != null)
        {
            _context.Areas.Remove(area);
            _context.SaveChanges();
        }
    }
}