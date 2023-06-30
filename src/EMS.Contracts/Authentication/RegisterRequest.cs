namespace EMS.Contracts.Authentication;

public record RegisterRequest(
    string FirstName,
    string LastName,
    string EmailAddress,
    string PhoneNumber,
    string Password);