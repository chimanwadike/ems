using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMS.Application.Services.Authentication;
using EMS.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace EMS.Services.API.Controllers;
public class AuthenticationController : ApiController
{
    private readonly IAuthenticationService _authenticationService;

    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest loginRequest)
    {
        var authResult = _authenticationService.Login(loginRequest.EmailAddress, loginRequest.Password);

        var authResponse = new AuthenticationResponse(authResult.Id,
        authResult.FirstName,
        authResult.LastName,
        authResult.EmailAddress,
        authResult.Token
        );

        return Ok(authResponse);
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterRequest registerRequest)
    {
        var authResult = _authenticationService.Register(
            registerRequest.FirstName,
            registerRequest.LastName,
            registerRequest.EmailAddress,
            registerRequest.Password);

        var authResponse = new AuthenticationResponse(authResult.Id,
        registerRequest.FirstName,
        registerRequest.LastName,
        authResult.EmailAddress,
        authResult.Token
        );

        return Ok(authResponse);
    }
}