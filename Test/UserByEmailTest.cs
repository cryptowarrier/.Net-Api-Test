using Xunit;
using ApiTest.Controller;
using ApiTest;
using Microsoft.AspNetCore.Mvc;


namespace Test;

public class UserByEmailTest
{
  private UserByEmailController _controller;
  private UserService _userService;
  private User? user;

  public UserByEmailTest()
  {
    _controller = new UserByEmailController();
    _userService = new UserService();
    user = _userService.users?[0];
  }

  [Fact]
  public void Post_UserByEmail_ReturnsOkResult()
  {
    // act
    var response = _controller.Post(user?.email);
    // assert
    Assert.IsType<OkObjectResult>(response as OkObjectResult);
  }

  [Fact]
  public void Post_UserByEmail_ReturnsUserByEmail()
  {
    //act
    var response = _controller.Post(user?.email) as OkObjectResult;
    // assert
    var findUser = Assert.IsType<User>(response?.Value);
    Assert.Equal(findUser.email, user?.email);
    Assert.Equal(findUser.name, user?.name);
  }

  [Fact]
  public void Post_ifEmptyEmail_ReturnsNotFoundResult()
  {
    //act
    var response = _controller.Post("");
    //assert
    Assert.IsType<NotFoundResult>(response as NotFoundResult);
  }

  [Fact]

  public void Post_ifBadEmail_ReturnsNotFoundResult()
  {
    //act
    var response = _controller.Post("aabbccddeeffgghhiihh");
    // assert
    Assert.IsType<NotFoundResult>(response as NotFoundResult);
  }
}