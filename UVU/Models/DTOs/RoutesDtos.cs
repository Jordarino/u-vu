using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UVU.Models.Entities;

namespace UVU.Models.DTOs
{
    public class RouteDto
    {
        public Int32 routeId { get; set; }
        public Int32 operatorId { get; set; }
        public String allStopsUrl { get; set; }
        public String timingPointsUrl { get; set; }
        public List<RouteNumberDto> RouteNumbers { get; set; }
        public List<RoutePathDto> RoutePaths { get; set; }
        public OperatorDto operatorItem { get; set; }

        public RouteDto() { }
        public RouteDto(Route item) {
            routeId = item.routeId;
            operatorId = item.operatorId;
            operatorItem = new OperatorDto(item.operatorItem);
            allStopsUrl = item.allStopsUrl;
            timingPointsUrl = item.timingPointsUrl;
            if(item.routeNumbers!=null) RouteNumbers = item.routeNumbers.Select(x => new RouteNumberDto(x)).ToList();
            if(item.routePaths!=null) RoutePaths = item.routePaths.Select(x => new RoutePathDto(x)).ToList();
        }
    }

    public class RouteNumberDto
    {
        public String number { get; set; }
        public Double? x { get; set; }
        public Double? y { get; set; }

        public RouteNumberDto(RouteNumber item)
        {
            number = item.number;
            x = item.position.StartPoint.XCoordinate;
            y = item.position.StartPoint.YCoordinate;
        }
    }
    public class RoutePathDto
    {
        public String path { get; set; }
        public String type { get; set; }
        public Int32 weight { get; set; }

        public RoutePathDto(RoutePath item)
        {
            type = item.type;
            weight = item.weight;
            path = item.path;
        }
    }

}
