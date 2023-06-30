using EMS.Domain.Entities;

namespace EMS.Application.Services.Authentication;

public record AuthenticationResult(
    User User,
    string Token);