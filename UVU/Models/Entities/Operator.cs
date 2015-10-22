using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UVU.Models.Entities
{
    [Table("tblOperators")]
    public class Operator
    {
        [Key]
        public Int32 operatorId { get; set; }
        public String name { get; set; }
        public String website { get; set; }
        public String colour { get; set; }
        public String twitter { get; set; }
    }
}
