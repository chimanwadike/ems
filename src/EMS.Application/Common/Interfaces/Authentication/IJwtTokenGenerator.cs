using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMS.Domain.Entities;

namespace EMS.Application.Common.Interfaces.Authentication
{
    public interface IJwtTokenGenerator
    {
        String GenerateToken(User user);
    }
}