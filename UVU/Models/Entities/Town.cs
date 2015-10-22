using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Spatial;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UVU.Models.Entities
{
    [Table("tblTowns")]
    public class Town
    {
        [Key]
        public Int32 townId { get; set; }
        public String townName { get; set; }
        public DbGeometry townNameLocation { get; set; }
        public DbGeometry location { get; set; }
        public Decimal size { get; set; }
    }
}
