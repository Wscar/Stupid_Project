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
        public DbSet<Forum> Forum { get; set; }
        public DbSet<Post> Post { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<SpArea> SpArea { get; set; }
       
    }
}
