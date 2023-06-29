using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMS.Application.Common.Interfaces.Authentication;
using EMS.Application.Common.Interfaces.Persistence;
using EMS.Application.Services.Authentication;
using EMS.Domain.Entities;

namespace EMS.Infrastructure.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationService(
        IJwtTokenGenerator jwtTokenGenerator,
        IUserRepository userRepository
        )
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public AuthenticationResult Login(string emailAddress, string password)
    {
        // 1. Validate the user exists
        if (_userRepository.GetUserByEmail(emailAddress) is not User user)
        {
            throw new Exception("User with given email does not exist.");
        }

        // 2. Validate the password is correct
        if (user.Password != password)
        {
            throw new Exception("Invalid password.");
        }

        // 3. Create JWT token
        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user,
            token);
    }

    public AuthenticationResult Register(string firstName, string lastName, string emailAddress, string password)
    {
        // 1. Validate the user doesn't exist
        if (_userRepository.GetUserByEmail(emailAddress) is not null)
        {
            throw new Exception("User with given email already exists.");
        }

        // 2. Create user (generate unique ID) & Persist to DB
        var user = new User
        {
            FirstName = firstName,
            LastName = lastName,
            EmailAddress = emailAddress,
            Password = password
        };

        _userRepository.Add(user);

        // 3. Create JWT token
        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user,
            token);
    }
}