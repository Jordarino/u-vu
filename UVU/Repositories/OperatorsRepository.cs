using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using UVU.Models.Entities;

namespace UVU.Repositories
{
    public class OperatorsRepository : DbContext
    {
        public OperatorsRepository(String connectionString = "DefaultConnection") : base(connectionString) { }


        public DbSet<Operator> Operators { get; set; }

    }
}
