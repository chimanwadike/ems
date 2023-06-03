using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.Application.Common.Interfaces.Authentication
{
    public interface IJwtTokenGenerator
    {
        String GenerateToken(Guid userId, string firstName, string lastName);
    }
}