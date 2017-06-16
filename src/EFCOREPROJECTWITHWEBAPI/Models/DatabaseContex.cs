using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCOREPROJECTWITHWEBAPI.Models
{
    public class DatabaseContex:DbContext
    {
        public DatabaseContex(DbContextOptions<DatabaseContex> options):base(options)
        {

        }
        public DbSet<MovieModel> Movies { get; set; }
    }
}
