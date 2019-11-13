using System.Configuration;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using Api.Repositories;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;

namespace Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);


            var builder = new ContainerBuilder();


            // Register your MVC controllers. (MvcApplication is the name of
            // the class in Global.asax.)
            builder.RegisterControllers(typeof(WebApiApplication).Assembly);

            // OPTIONAL: Register model binders that require DI.
            builder.RegisterModelBinders(typeof(WebApiApplication).Assembly);
            builder.RegisterModelBinderProvider();

            // OPTIONAL: Register web abstractions like HttpContextBase.
            builder.RegisterModule<AutofacWebTypesModule>();

            // OPTIONAL: Enable property injection in view pages.
            builder.RegisterSource(new ViewRegistrationSource());

            // OPTIONAL: Enable property injection into action filters.
            builder.RegisterFilterProvider();

            //builder.RegisterGeneric(typeof(IRepository<>)).As(typeof(DapperRepository<>)).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(DapperRepository<>))
                .As(typeof(IRepository<>))
                .InstancePerLifetimeScope()
                .WithParameter(new TypedParameter(typeof(string),ConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString));


            var config = GlobalConfiguration.Configuration;

            // Register your Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            // OPTIONAL: Register the Autofac filter provider.
            builder.RegisterWebApiFilterProvider(config);

            // OPTIONAL: Register the Autofac model binder provider.
            builder.RegisterWebApiModelBinderProvider();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}
