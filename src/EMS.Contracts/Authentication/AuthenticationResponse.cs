using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.Contracts.Authentication;

public record AuthenticationResponse
(
    Guid Id,
    string FirstName,
    string LastName,
    string EmailAddress,
    string PhoneNumber,
    string Token
);