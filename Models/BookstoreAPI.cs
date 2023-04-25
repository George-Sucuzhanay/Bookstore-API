using System;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using BookstoreAPI.Models;


namespace BookstoreAPI.Models
{
    public class BookstoreAPIDBContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public BookstoreAPIDBContext(DbContextOptions<BookstoreAPIDBContext> options, IConfiguration configuration)
            : base(options)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var connectionString = Configuration.GetConnectionString("BookstoreDatabase");
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

        }

        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<Book> Books { get; set; } = null!;
    }
}

