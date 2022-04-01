using Microsoft.AspNetCore.Mvc;

namespace ApiTest.Controller;

[ApiController]
[Route("users/")]

public class UserByEmailController : ControllerBase
{
  UserService userService = new UserService();
  [HttpPost("{email}", Name = "getUserByEmail")]
  public IActionResult Post([FromRoute] string? email)
  {
    if(email is null) 
    {
      return NotFound();
    }
    User findUser = new User();
    findUser = userService.getUserByEmail(email);
    if(findUser.email is null )
    {
      return NotFound();
    }
    return Ok(findUser);
  }
}