using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMS.Domain.Entities;

namespace EMS.Application.Services.Authentication;

public record AuthenticationResult(
    User User,
    string Token
);