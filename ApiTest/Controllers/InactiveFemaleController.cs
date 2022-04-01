using Microsoft.AspNetCore.Mvc;

namespace ApiTest.Controller;

[ApiController]
[Route("users/inactive_females")]

public class InActiveFemalesController : ControllerBase
{
  UserService userService = new UserService();
  [HttpGet(Name = "getInActiveFemales")]
  public IActionResult Get()
  {
    List<User> inactiveFemales = new List<User>();
    inactiveFemales = userService.getInactiveFemales();
    return Ok(inactiveFemales);
  }
}