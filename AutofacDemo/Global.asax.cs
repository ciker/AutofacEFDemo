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
            //注册方式一（自动注册）：所有的接口都继承自IDependency，从而实现自动注册
            //获取当前所有的程序集合
            var assemblys = AppDomain.CurrentDomain.GetAssemblies().ToList();
            var baseType = typeof(IDependency);
            //注册当前程序集
            builder.RegisterAssemblyTypes(assemblys.ToArray());
            builder.RegisterAssemblyTypes(assemblys.ToArray())
                .Where(t => baseType.IsAssignableFrom(t) && t != baseType)
                .AsImplementedInterfaces().InstancePerLifetimeScope();


            //****************************************
            //注册方式二（手动注册）：手动添加接口的注册信息
            ////获取当前所有的程序集合
            //var assemblys = AppDomain.CurrentDomain.GetAssemblies().ToList();
            ////注册当前程序集
            //builder.RegisterAssemblyTypes(assemblys.ToArray());
            //builder.RegisterType<LogService>().As<ILogService>();
            //builder.RegisterType<UserService>().As<IUserService>();
            //builder.RegisterControllers(Assembly.GetExecutingAssembly());
            //****************************************

            //注册泛型
            builder.RegisterGeneric(typeof(EfRepository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
