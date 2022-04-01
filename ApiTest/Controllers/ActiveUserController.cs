using Microsoft.AspNetCore.Mvc;

namespace ApiTest.Controller;

[ApiController]
[Route("users/acitve_users")]
public class ActiveUserController : ControllerBase
{
  UserService userService = new UserService();
  [HttpGet(Name = "getActiveUsers")]
  public IActionResult Get()
  {
    List<User> activeUsers = new List<User>();
    activeUsers = userService.getActiveUsers();
    return Ok(activeUsers);
  }
}
