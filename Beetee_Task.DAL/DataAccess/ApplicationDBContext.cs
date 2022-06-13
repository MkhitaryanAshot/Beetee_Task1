using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Beetee_Task.Domain.Entities;

namespace Beetee_Task.DAL.DataAccess
{
    public class ApplicationDBContext : DbContext, IApplicationDbContext
    {
        public DbSet<HR_Data> HR_Data { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDBContext).Assembly);

            base.OnModelCreating(modelBuilder);

        }
    }
}
