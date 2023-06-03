using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.Contracts.Authentication;

public record LoginRequest(
    string EmailAddress,
    string Password
);