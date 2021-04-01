using SürücuKursu.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SürücüKursu.DataAccessLayer
{
    public class DatabaseContext : DbContext
    {
        public DbSet<SürücüKursuUser> SürücuKursuUser { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public DatabaseContext()
        {
            Database.SetInitializer(new Initializer());
        }
    }
}
