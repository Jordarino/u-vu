using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UVU.Models.DTOs;

namespace UVU.Controllers.Api
{
    [RoutePrefix("api/routes")]
    public class RoutesController : ApiController
    {
        [HttpGet]
        [Route("gettowns")]
        public List<TownDto> Towns()
        {
            var repo = new Repositories.TownsRepository();
            var list = repo.Towns.ToList();
            return list.Select(x => new TownDto(x)).ToList();
        }

        [HttpGet]
        [Route("getroutes")]
        public List<RouteDto> Routes()
        {
            var repo = new Repositories.RoutesRepository();
            var list = repo.Routes.ToList();
            return list.Select(x => new RouteDto(x)).ToList();
        }
    }
}
