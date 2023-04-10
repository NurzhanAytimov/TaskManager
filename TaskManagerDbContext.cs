using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace TaskManager
{
    public class TaskManagerDbContext : DbContext
    {
        public DbSet<Task> Tasks { get; set; }

        public TaskManagerDbContext()
        {
            Database.EnsureCreated();   
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-DALM8A8;Database=TaskManager;Trusted_Connection=True;");
        }

    }
}




