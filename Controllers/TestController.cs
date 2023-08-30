using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kwiz.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TestController : ControllerBase
{
    [Authorize("KwizAdminsOnly")]
    [HttpGet("[action]")]
    public IActionResult Admin()
        => Ok($"Hello from kwiz.admin {HttpContext.User.Identity.Name}");

    [Authorize]
    [HttpGet("[action]")]
    public IActionResult SimpleUser()
        => Ok($"Hello from kwiz.admin {HttpContext.User.Identity.Name}");
}