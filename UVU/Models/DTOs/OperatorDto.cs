using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UVU.Models.Entities;

namespace UVU.Models.DTOs
{
    public class OperatorDto
    {
        public Int32 operatorId { get; set; }
        public String name { get; set; }
        public String website { get; set; }
        public String colour { get; set; }
        public String twitter { get; set; }

        public Int32 Value { get { return operatorId; } }
        public override string ToString()
        {
            return name;
        }

        public OperatorDto() { }

        public OperatorDto(Operator item)
        {
            operatorId = item.operatorId;
            name = item.name;
            website = item.website;
            colour = item.colour;
            twitter = item.twitter;
        }

    }
}
