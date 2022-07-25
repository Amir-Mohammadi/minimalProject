using Autofac;
using minimalProject.Core;
using System.Reflection;

namespace minimalProject.Frameworks.Autofac
{
    public static class AutofacConfigurationExtensions
    {
        public static void AddAutofacDependencyServices(this ContainerBuilder containerBuilder)
        {
            var currentAssembly = Assembly.GetExecutingAssembly();

            containerBuilder.RegisterAssemblyTypes(currentAssembly)
                .AssignableTo<IScopedDependency>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            containerBuilder.RegisterAssemblyTypes(currentAssembly)
                .AssignableTo<ITransientDependency>()
                .AsImplementedInterfaces()
                .InstancePerDependency();

            containerBuilder.RegisterAssemblyTypes(currentAssembly)
                .AssignableTo<ISingletonDependency>()
                .AsImplementedInterfaces()
                .SingleInstance();

            containerBuilder.RegisterGeneric(typeof(Repository<>))
                .As(typeof(IRepository<>))
                .InstancePerLifetimeScope();
        }
    }
}
