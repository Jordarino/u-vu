using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Spatial;

namespace UVU.Models.Entities
{
    [Table("tblRoutes")]
    public class Route
    {
        [Key]
        public Int32 routeId { get; set; }
        public Int32 operatorId { get; set; }
        public String allStopsUrl { get; set; }
        public String timingPointsUrl { get; set; }

        public virtual ICollection<RouteNumber> routeNumbers { get; set; }
        public virtual ICollection<RoutePath> routePaths { get; set; }
        public virtual Operator operatorItem { get; set; }

    }

    [Table("tblRouteNumbers")]
    public class RouteNumber
    {
        [Key]
        public Int32 routeNumberId { get; set; }
        public Int32 routeId { get; set; }
        public String number { get; set; }
        public DbGeometry position { get; set; }
    }

    [Table("tblRoutePaths")]
    public class RoutePath
    {
        [Key]
        public Int32 routePathId { get; set; }
        public Int32 routeId { get; set; }
        public String path { get; set; }
        public String type { get; set; }
        public Int32 weight { get; set; }
    }

}
