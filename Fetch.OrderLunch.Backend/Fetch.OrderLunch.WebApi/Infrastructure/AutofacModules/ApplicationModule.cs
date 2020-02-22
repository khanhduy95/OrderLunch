using Autofac;
using Fetch.OrderLunch.Core.Entities.SupplierAggregate;
using Fetch.OrderLunch.Core.Interfaces;
using Fetch.OrderLunch.Infrastructure.Data;
using Fetch.OrderLunch.Infrastructure.Idempotency;
using Fetch.OrderLunch.Infrastructure.Repository;
using Fetch.OrderLunch.WebApi.Application.Commands;
using Fetch.OrderLunch.WebApi.Application.Interfaces;
using Fetch.OrderLunch.WebApi.Application.Queries;
using Fetch.OrderLunch.WebApi.Application.Services;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Fetch.OrderLunch.WebApi.Infrastructure.AutofacModules
{
    public class ApplicationModule : Autofac.Module
    {
        public string QueriesConnectionString { get; }

        public ApplicationModule(string qconstr)
        {
            QueriesConnectionString = qconstr;

        }
        
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new OrderQueries(QueriesConnectionString))
                .As<IOrderQueries>()
                .InstancePerLifetimeScope();

            builder.RegisterType<BuyerRepository>()
                 .As<IBuyerRepository>()
                 .InstancePerLifetimeScope();

            builder.RegisterType<MenuRepository>()
               .As<IMenuRepository>()
               .InstancePerLifetimeScope();

            builder.RegisterType<DailyMenuRepository>()
               .As<IDailyMenuRepository>()
               .InstancePerLifetimeScope();

            builder.RegisterType<BasketRepository>()
               .As<IBasketRepository>()
               .InstancePerLifetimeScope();

            builder.RegisterType<SupplierRepository>()
               .As<ISupplierRepository>()
               .InstancePerLifetimeScope();

            builder.RegisterType<OrderRepository>()
                .As<IOrderRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<RequestManager>()
               .As<IRequestManager>()
               .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(typeof(CreateOrderCommandHandler).GetTypeInfo().Assembly);
               
        }
    }
}
