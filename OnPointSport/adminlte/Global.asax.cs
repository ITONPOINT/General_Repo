using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using OnPointSport.Core.Interfaces;
using OnPointSport.Data.DataAccess;
using OnPointSport.Data;


namespace adminlte
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly).PropertiesAutowired();
            builder.RegisterType<OnPointSportDbContext>().AsSelf().InstancePerDependency();

            builder.RegisterType<UserRepository>().As<IUserRepository>();
            builder.RegisterType<CustomerRepository>().As<ICustomerRepository>();
            builder.RegisterType<EmployeeRepository>().As<IEmployeeRepository>();
            builder.RegisterType<CategoryRepository>().As<ICategoryRepository>();
            builder.RegisterType<ExchangeRateRepository>().As<IExchangeRateRepository>();
            builder.RegisterType<ProductServiceRepository>().As<IProductServiceRepository>();
            builder.RegisterType<SupplierRepository>().As<ISupplierRepository>();
            builder.RegisterType<SalaryRepository>().As<ISalaryRepository>();
            builder.RegisterType<StockAdjustmentRepository>().As<IStockAdjustmentRepository>();
            builder.RegisterType<DiscountRepository>().As<IDiscountRepository>();
            builder.RegisterType<BookingRepository>().As<IBookingRepository>();
            builder.RegisterType<ImportRepository>().As<IImportRepository>();
            builder.RegisterType<SaleRepository>().As<ISaleReposity>();
            builder.RegisterType<ItemDetailRepository>().As<IItemDetailRepository>();

            
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

        }
    }
}
