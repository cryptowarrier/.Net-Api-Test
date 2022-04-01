using Xunit;
using ApiTest.Controller;
using ApiTest;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Test;

public class ActiveUsersTest
{
    private readonly ActiveUserController _controller;

    public ActiveUsersTest()
    {
        _controller = new ActiveUserController();
    }
    [Fact]
    public void  Get_ActiveUsers_ReturnsOkResult()
    {
        // act
        var response = _controller.Get();
        // assert
        Assert.IsType<OkObjectResult>(response as OkObjectResult);
    }

    [Fact]
    public void Get_ActiveUsers_ReturnsActiveUsers()
    {
        // act
        var response = _controller.Get() as OkObjectResult;
        // assert
        var activeUsers = Assert.IsType<List<User>>(response?.Value);
    }
}