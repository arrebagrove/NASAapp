using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NASAapp.DAL
{
    public class ApplicationContext : DbContext
    {
        public DbSet<AstronomyPictureOfDayDAL> Pictures { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=nasaapp.db");
        }
    }
}
