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
    public IActionResult Login(LoginRequest request)
    {
        var authResult = _authenticationService.Login(request.EmailAddress, request.Password);

        var authResponse = new AuthenticationResponse(
            authResult.User.Id,
            authResult.User.FirstName,
            authResult.User.LastName,
            authResult.User.EmailAddress,
            authResult.User.PhoneNumber ?? string.Empty,
            authResult.Token);

        return Ok(authResponse);
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request)
    {
        var authResult = _authenticationService.Register(
            request.FirstName,
            request.LastName,
            request.EmailAddress,
            request.Password);

        var authResponse = new AuthenticationResponse(
            authResult.User.Id,
            authResult.User.FirstName,
            authResult.User.LastName,
            authResult.User.EmailAddress,
            authResult.User.PhoneNumber ?? string.Empty,
            authResult.Token);

        return Ok(authResponse);
    }
}