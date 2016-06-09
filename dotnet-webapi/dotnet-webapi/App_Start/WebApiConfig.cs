using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Dependencies;

namespace dotnet_webapi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.DependencyResolver = new MyDependencyResolver();
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

        }

        public class MyDependencyResolver : IDependencyResolver
        {
            public IDependencyScope BeginScope()
            {
                return this;
            }

            public void Dispose()
            {
            }

            public object GetService(Type serviceType)
            {
                if (serviceType == typeof(Controllers.FeedbackController))
                {
                    return new Controllers.FeedbackController(new Repositories.FeedbackRepository());
                }
                if (serviceType == typeof(Repositories.IFeedbackRepository))
                {
                    return new Repositories.FeedbackRepository();
                }

                return null;
            }

            public IEnumerable<object> GetServices(Type serviceType)
            {
                return (new object[] { GetService(serviceType) }).Where(x => x != null);
            }
        }
    }
}
