using Autofac;
using Autofac.Integration.Mvc;
using AutofacDemo.Controllers;
using AutofacDemo.Core;
using AutofacDemo.Data;
using AutofacDemo.Services;
using AutofacDemo.Services.Log;
using AutofacDemo.Services.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace AutofacDemo
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static IContainer container;
        protected void Application_Start()
        {
            //其它的初始化过程
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //Autofac初始化过程
            RegisterService();
        }

        private void RegisterService()
        {
            ContainerBuilder builder = new ContainerBuilder();
            //var baseType = typeof(IDependency);

            //var assemblys = AppDomain.CurrentDomain.GetAssemblies().ToList();
            //var AllServices =
            //    assemblys.SelectMany(s => s.GetTypes())
            //    .Where(p => baseType.IsAssignableFrom(p) && p != baseType);

            //builder.RegisterAssemblyTypes(assemblys.ToArray());

            //builder.RegisterAssemblyTypes(assemblys.ToArray())
            //    .Where(t => baseType.IsAssignableFrom(t) && t != baseType)
            //    .AsImplementedInterfaces().InstancePerLifetimeScope();
            

            //builder.RegisterGeneric(typeof(EfRepository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();
            builder.RegisterType<LogService>().As<ILogService>();
            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
