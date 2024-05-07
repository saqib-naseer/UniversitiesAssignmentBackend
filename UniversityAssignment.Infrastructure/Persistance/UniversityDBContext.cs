using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityAssignment.Domain.Entities;

namespace UniversityAssignment.Infrastructure.Persistance
{
    public class UniversityDBContext(DbContextOptions<UniversityDBContext> options) : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string _connectionString = $"Server=localhost;Database=UniversityDB;Trusted_Connection=True;TrustServerCertificate=True";
            optionsBuilder.UseSqlServer(_connectionString, options => options.EnableRetryOnFailure());
        }

        public DbSet<University> University { get; set; }
        public DbSet<LK_Country> LK_Country { get; set; }
        public DbSet<Domains> Domains { get; set; }
        public DbSet<UniversityWebPages> WebPages { get; set; }

    }
}
