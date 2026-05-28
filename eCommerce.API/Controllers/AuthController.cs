using eCommerce.Core.DTOs;
using eCommerce.Core.ServiceContracts;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{

    private readonly IUsersService _usersService;

    public AuthController(IUsersService usersService)
    {
        this._usersService = usersService ?? throw new ArgumentNullException(nameof(usersService));
    }

    [HttpGet("login")]
    public async Task<IActionResult> Login(eCommerce.Core.DTOs.LoginRequest loginRequest)
    {

        if(loginRequest == null) {

            return BadRequest("Login request cannot be null.");
        }

        AuthenticationResponse? authenticationResponse = await _usersService.Login(loginRequest);

        if (authenticationResponse == null || authenticationResponse.Success == false)
        {
            return BadRequest("Invalid email or password.");
        }

        return Ok(authenticationResponse);
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(eCommerce.Core.DTOs.RegisterRequest registerRequest)
    {
        if(registerRequest == null) {
            return BadRequest("Register request cannot be null.");
        }

        AuthenticationResponse? authenticationResponse = await _usersService.Register(registerRequest);

        if (authenticationResponse == null || authenticationResponse.Success == false)
        {
            return BadRequest("Invalid request.");
        }

        return Ok(authenticationResponse);
    }

    [HttpGet("search/{userId}")]
    public async Task<IActionResult> CheckUserExist(Guid userId)
    {
        if (userId == Guid.Empty)
        {
            return BadRequest("User ID cannot be empty.");
        }

        bool userExists = await _usersService.UserByIdExistsAsync(userId);

        if (!userExists)
        {
            return NotFound("User not found.");
        }

        return Ok(userExists);
    }
}
