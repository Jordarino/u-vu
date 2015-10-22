using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace UVU
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var appXmlType = config.Formatters.XmlFormatter.SupportedMediaTypes.FirstOrDefault(x => x.MediaType == "application/xml");
            config.Formatters.XmlFormatter.SupportedMediaTypes.Remove(appXmlType);

            config.MapHttpAttributeRoutes();
        }
    }
}
