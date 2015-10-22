using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Spatial;
using UVU.Models.Entities;

namespace UVU.Models.DTOs
{
    public class TownDto
    {
        public Int32 townId { get; set; }
        public String townName { get; set; }
        public String townNameLocation { get; set; }
        public String location { get; set; }
        public Decimal size { get; set; }

        public TownDto() { }
        public TownDto(Town item)
        {
            townId = item.townId;
            townName = item.townName;
            townNameLocation = item.townNameLocation.StartPoint.XCoordinate + " " + item.townNameLocation.StartPoint.YCoordinate;
            location = item.location.StartPoint.XCoordinate + " " + item.location.StartPoint.YCoordinate;
            size = item.size;
        }
        //<text transform="matrix(1 0 0 1 2715.1274 6028.625)" fill="#AFAFAF" font-family="'ArialMT'" font-size="6.0001">Osmington</text>
    }
}
