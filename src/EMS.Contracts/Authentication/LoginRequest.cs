namespace EMS.Contracts.Authentication;

public record LoginRequest(
    string EmailAddress,
    string Password);