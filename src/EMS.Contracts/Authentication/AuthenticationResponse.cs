namespace EMS.Contracts.Authentication;

public record AuthenticationResponse
(Guid Id, string FirstName, string LastName, string EmailAddress, string PhoneNumber, string Token);