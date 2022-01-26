using Autofac;
using NLayer.Core.Repositories;
using NLayer.Core.Services;
using NLayer.Core.UnitOfWorks;
using NLayer.Repository.Efcore;
using NLayer.Repository.Efcore.Repositories;
using NLayer.Repository.UnitOfWorks;
using NLayer.Service.Mapping;
using NLayer.Service.Services;
using System.Reflection;
using NLayer.Caching;
using Module = Autofac.Module;
using NLayer.Service.Services.Abstract;

namespace NLayer.API.AutofacModule
{
    public class RepoServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(GenericRepository<>))
                .As(typeof(IGenericRepository<>))
                .SingleInstance();

            builder.RegisterGeneric(typeof(Service<>))
                .As(typeof(IService<>))
                .SingleInstance();

            builder.RegisterType<UnitOfWork>()
                .As<IUnitOfWork>()
                .SingleInstance();


            var apiAssmbly = Assembly.GetExecutingAssembly();
            var repoAssembly = Assembly.GetAssembly(typeof(NLayerDbContext));
            var serviceAssembly = Assembly.GetAssembly(typeof(MapProfile));

            builder.RegisterAssemblyTypes(apiAssmbly, repoAssembly, serviceAssembly)
                .Where(x => x.Name.EndsWith("Repository"))
                .AsImplementedInterfaces()
                .SingleInstance();

            builder.RegisterAssemblyTypes(apiAssmbly, repoAssembly, serviceAssembly)
                .Where(x => x.Name.EndsWith("Service"))
                .AsImplementedInterfaces()
                .SingleInstance();

            builder.RegisterType<ProductServiceWithCaching>().As<IProductService>().SingleInstance();
        }
    }
}
