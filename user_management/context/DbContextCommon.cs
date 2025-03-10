using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using user_management.module.user.model;


namespace user_management.context
{
   
        public class DbContextCommon : DbContext
        {
            public DbSet<User> Users { get; set; }

        


       
        public DbContextCommon(DbContextOptions<DbContextCommon> options)
                : base(options)
            {
            }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                //modelBuilder.HasDefaultSchema("user");
             
                modelBuilder.ApplyConfiguration(new UserConfig());    

                base.OnModelCreating(modelBuilder);
            }
        }
    
}
