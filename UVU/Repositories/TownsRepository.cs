using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UVU.Models.Entities;

namespace UVU.Repositories
{
    public class TownsRepository : DbContext
    {
        public TownsRepository(String connectionString="DefaultConnection") : base(connectionString) { }

        public DbSet<Town> Towns { get; set; }

    }
}
