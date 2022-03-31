using System;
using Microsoft.EntityFrameworkCore;
using UsersApi.Entities;

namespace UsersApi.Contexts
{
    public class DbApiContext : DbContext
    {
        public DbApiContext()
        {
        }

        public DbApiContext(DbContextOptions<DbApiContext> options)
            :base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; }
    }
}
