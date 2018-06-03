using DatingAppDal.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;


namespace DatingAppDal.Context
{
    public class DatingAppDbContext:DbContext
    {
        public DatingAppDbContext(DbContextOptions<DatingAppDbContext>options):base(options)
        {

        }
        public DbSet<Value> Values { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
           
        }
    }
}
