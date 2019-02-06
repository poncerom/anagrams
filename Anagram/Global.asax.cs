using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using AnagramRepository;
using System.Reflection;

namespace Anagram
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var configuration = GlobalConfiguration.Configuration;
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<AnagramRepository.AnagramRepository>().As<IAnagramRepository>()
                .SingleInstance();
            builder.RegisterType<Anagram.Business.AnagramCalculatorBusiness>().As<Business.IAnagramCalculatorBusiness>();


            var resolver = new AutofacWebApiDependencyResolver(builder.Build());
            GlobalConfiguration.Configuration.DependencyResolver = resolver;

            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
