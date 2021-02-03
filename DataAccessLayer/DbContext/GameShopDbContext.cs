using Entities.BaseEntities;
using Entities.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DbContext
{
    public class GameShopDbContext:IdentityDbContext<User>
    {
        public GameShopDbContext(DbContextOptions options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(GameShopDbContext).Assembly);
            var assembly = Assembly.Load("Entities");
            foreach(var classType in assembly.GetTypes().Where(c => c.IsClass == true))
            {
                if (typeof(IFinderEntity).IsAssignableFrom(classType))
                {
                    builder.Entity(classType);
                }
            }
           
            base.OnModelCreating(builder);
        }
    }
}
