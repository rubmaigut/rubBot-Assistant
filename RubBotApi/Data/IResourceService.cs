using RubBotApi.Models;

namespace RubBotApi.Util;

public interface IResourceService
{
    Resource CreateResource(Resource resource);
    List<Resource> GetAllResources();
    Resource GetResourceById(string resourceId);
    Resource UpdateResource(string resourceId, Resource resource);
    void DeleteResource(string resourceId);
}