using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.Application.Common.Interfaces.Providers
{
    public interface IDateTimeProvider
    {
        DateTime UtcNow { get; }
    }
}