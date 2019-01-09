using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SP.Models;

namespace SP.Infrastructure
{
    public class SPDbcontext : DbContext
    {
        public SPDbcontext(DbContextOptions<SPDbcontext> options) : base(options)
        {
           
        }
        public DbSet<AppUser> AppUser { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
       
    }
}
