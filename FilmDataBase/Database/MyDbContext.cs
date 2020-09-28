using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmDataBase.Database
{
    public class MyDbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
    }
}
