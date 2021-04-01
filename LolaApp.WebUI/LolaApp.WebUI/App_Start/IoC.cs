using Autofac;
using Autofac.Core.Lifetime;
using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace LolaApp.WebUI.App_Start
{
    public static class IoC
    {
        public static void RegisterDependencies() {
            var builder = new ContainerBuilder();
            var asm = Assembly.GetExecutingAssembly();
            var requestTag = MatchingScopeLifetimeTags.RequestLifetimeScopeTag;
            
            // Register your MVC controllers.
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            // OPTIONAL: Register model binders that require DI.
            builder.RegisterModelBinders(asm);
            builder.RegisterModelBinderProvider();
            

            // OPTIONAL: Register web abstractions like HttpContextBase.
            builder.RegisterModule<AutofacWebTypesModule>();

            // OPTIONAL: Enable property injection in view pages.
            builder.RegisterSource(new ViewRegistrationSource());

            // OPTIONAL: Enable property injection into action filters.
            builder.RegisterFilterProvider();

            //builder.RegisterAssemblyTypes(asm)
            //       .Where(t => t.Name.EndsWith("Repository"))
            //       .AsImplementedInterfaces();

            //var asmSrvc = Assembly.GetAssembly(typeof(LolaApp.DataAccess));
            builder.RegisterAssemblyTypes(asm)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerMatchingLifetimeScope(requestTag);


            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}