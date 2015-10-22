using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UVU.Models.Entities;

namespace UVU.Repositories
{
    public class RoutesRepository : DbContext
    {
        public RoutesRepository(String connectionString = "DefaultConnection") : base(connectionString) { }


        public DbSet<Route> Routes { get; set; }
        public DbSet<RouteNumber> RouteNumbers { get; set; }
        public DbSet<RoutePath> RoutePaths { get; set; }

    }
}
