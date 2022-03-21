using Infraestructure.Model.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Core.Context
{
    public class ContextSql : DbContext
    {
        public ContextSql(DbContextOptions<ContextSql> options)
            : base(options)
        {
        }

        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserToRol> UserToRol { get; set; }

    }
}
