using System.Linq;
using EFCoreSqliteCollation.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCoreSqliteCollation.DataAccess
{
    public class EntitiesContext : DbContext
    {
        public DbSet<MyEntity> Entities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("filename=myDatabase.db3");
        }

        public void Seed()
        {
            if (!Entities.Any())
            {
                Entities.AddRange(
                    new MyEntity {Name = "aaa"},
                    new MyEntity {Name = "AAA"},
                    new MyEntity {Name = "bbb"},
                    new MyEntity {Name = "BBB"}
                    );

                SaveChanges();
            }
        }
    }
}