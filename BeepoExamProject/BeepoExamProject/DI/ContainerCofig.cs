using Autofac;
using Autofac.Integration.WebApi;
using BeepoExamProject.BusinessLayer;
using BeepoExamProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;

namespace BeepoExamProject.DI
{
    public static class ContainerCofig
    {
        public static void Configure()
        {
            var configuration = GlobalConfiguration.Configuration;
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterWebApiFilterProvider(configuration);
            builder.RegisterWebApiModelBinderProvider();
            builder.RegisterType<ClientRepository>().As<IRepository<tblClient>>();
            builder.RegisterType<UserRepository>().As<IRepository<tblUser>>();
            builder.RegisterType<UserBl>().As<IBusinessLayer<tblUser>>();
            builder.RegisterType<ClientBl>().As<IBusinessLayer<tblClient>>();



            var container = builder.Build();
            var resolver = new AutofacWebApiDependencyResolver(container);

            configuration.DependencyResolver = resolver;
        }

    }
}