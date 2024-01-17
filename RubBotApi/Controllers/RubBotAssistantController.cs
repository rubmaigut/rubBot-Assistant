using Microsoft.AspNetCore.Mvc;

namespace RubBotApi.Controllers;

[ApiController]
[Route("/[controller]")]

public class RubBotAssistantController: ControllerBase
{
    [HttpGet]
    public ActionResult GetAll()
    {
        return Ok("Basic Api Working");
    }
}