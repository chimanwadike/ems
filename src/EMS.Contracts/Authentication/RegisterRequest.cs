using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.Contracts.Authentication;

public record RegisterRequest(
    string FirstName,
    string LastName,
    string EmailAddress,
    string PhoneNumber,
    string Password
);
