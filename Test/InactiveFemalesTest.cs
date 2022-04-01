using Xunit;
using ApiTest.Controller;
using ApiTest;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Test;

public class InactiveFemalesTest
{
  private InActiveFemalesController _controller;

  public InactiveFemalesTest()
  {
    _controller = new InActiveFemalesController();
  }

  [Fact]
  public void Get_InactiveFemales_ReturnsOkResult()
  {
    // act
    var response = _controller.Get();
    // assert
    Assert.IsType<OkObjectResult>(response as OkObjectResult);
  }

  [Fact]
  public void Get_InactiveFemales_ReturnInactiveFemales()
  {
    // act
    var response = _controller.Get() as OkObjectResult;
    // assert
    var inactiveFemales = Assert.IsType<List<User>>(response?.Value);
    Assert.Equal(inactiveFemales[0].status, "inactive");
  }
}