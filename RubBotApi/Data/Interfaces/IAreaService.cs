using RubBotApi.Models;

namespace RubBotApi.Util;

public interface IAreaService
{
    Area CreateArea(Area area);
    List<Area> GetAllAreas();
    Area GetAreaById(string areaId);
    Area UpdateArea(string areaId, Area area);
    void DeleteArea(string areaId);
}