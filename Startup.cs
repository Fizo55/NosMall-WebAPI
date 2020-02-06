using Owin;
using System.Linq;
using System.Net.Http.Headers;
using System.Web.Http;

namespace WebAPI
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            HttpConfiguration config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                "DefaultApi",
                "{controller}/{CharacterId}",
                new { CharacterId = RouteParameter.Optional }
            );
            MediaTypeHeaderValue appXmlType = config.Formatters.XmlFormatter.SupportedMediaTypes.FirstOrDefault(t => t.MediaType == "application/xml");
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
            config.Formatters.XmlFormatter.SupportedMediaTypes.Remove(appXmlType);
            appBuilder.UseWebApi(config);
        }
    }
}
