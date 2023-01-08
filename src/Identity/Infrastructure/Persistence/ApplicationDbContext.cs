using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Identity.Application.Common;
using Identity.Domain.Entities;
using Identity.Infrastructure.Persistence.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Identity.Infrastructure.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, int,
      UserClaim, UserRole, UserLogin,
      RoleClaim, UserToken>, IApplicationDbContext
    {
        #region ctor
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        #endregion

        #region methods
        protected override void OnModelCreating(ModelBuilder builder)
        {
            
            base.OnModelCreating(builder);
            //builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            builder.ApplyConfiguration( new RoleConfiguration());
            builder.ApplyConfiguration( new UserConfiguration());
            builder.ApplyConfiguration( new RoleClaimConfiguration());
            builder.ApplyConfiguration( new UserClaimConfiguration());
            builder.ApplyConfiguration( new UserLoginConfiguration());
            builder.ApplyConfiguration( new UserRoleConfiguration());
            builder.ApplyConfiguration( new UserTokenConfiguration());

        }
        #endregion
    }
}