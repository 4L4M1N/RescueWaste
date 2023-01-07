using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Identity.Application.Common;
using Microsoft.EntityFrameworkCore;

namespace Identity.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        
    }
}