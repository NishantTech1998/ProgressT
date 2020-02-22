using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace Services
{
    public class TaskProgressContext:DbContext
    {
        public DbSet<Tasks> Tasks { get; set; }

        private static bool _created;
        public TaskProgressContext()
        {
            if (File.Exists("Sample.db"))
                _created = true;
            else
                _created = false;
            if (!_created)
            {
                _created = true;
                Database.EnsureDeleted();
                Database.EnsureCreated();
            }
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionbuilder)
        {
            optionbuilder.UseSqlite(@"Data Source=Sample.db");
        }
    }
}
