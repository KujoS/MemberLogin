using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using System.Reflection;

namespace MemberLogin.App_Start
{
    public class AutofacConfig
    {
        public static void Run()
        {
            var builder = new ContainerBuilder();

            Assembly assembly = Assembly.GetExecutingAssembly();

            builder.RegisterControllers(assembly);
            builder.RegisterApiControllers(assembly);

            //註冊Service結尾的組件
            builder.RegisterAssemblyTypes(assembly)
                .Where(x => x.Name.EndsWith("Service", StringComparison.Ordinal))
                .AsImplementedInterfaces();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}