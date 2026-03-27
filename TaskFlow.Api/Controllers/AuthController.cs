using Microsoft.AspNetCore.Mvc;
using TaskFlow.Business.Interfaces;
using TaskFlow.Entities.DTOs.Auth;
using TaskFlow.Entities.Models;

namespace TaskFlow.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController:ControllerBase
{
    private readonly IAuthService _service;

    public AuthController(IAuthService service)
    {
        _service = service;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterDto dto)
    {
        try
        {
            var token = await _service.RegisterAsync(dto);
            return Ok(new { token = token });
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto dto)
    {
        try
        {
            var token = await _service.LoginAsync(dto);
            return Ok(new { token = token });
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}