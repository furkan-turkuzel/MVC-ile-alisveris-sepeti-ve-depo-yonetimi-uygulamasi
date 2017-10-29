[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(MVC.UI.Repo.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(MVC.UI.Repo.App_Start.NinjectWebCommon), "Stop")]

namespace MVC.UI.Repo.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using BLL.Abstract;
    using BLL.Concrete;
    using DAL.Abstract;
    using DAL.Concrete.Management;
    using System.Data.Entity;
    using DAL.Concrete.DBContext;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IProductService>().To<ProductService>();
            kernel.Bind<ICategoryService>().To<CategoryService>();
            kernel.Bind<ICustomerService>().To<CustomerService>();
            kernel.Bind<IStoreService>().To<StoreService>();
            kernel.Bind<IOrderService>().To<OrderService>();
            kernel.Bind<IOrderDetailService>().To<OrderDetailService>();
            kernel.Bind<IBasketService>().To<BasketService>();


            kernel.Bind<IProductDAL>().To<EFProductDAL>();
            kernel.Bind<ICategoryDAL>().To<EFCategoryDAL>();
            kernel.Bind<ICustomerDAL>().To<EFCustomerDAL>();
            kernel.Bind<IStoreDAL>().To<EFStoreDAL>();
            kernel.Bind<IOrderDetailDAL>().To<EFOrderDetailDAL>();
            kernel.Bind<IOrderDAL>().To<EFOrderDAL>();

            kernel.Bind<DbContext>().To<TrendyolDBContext>();
        }        
    }
}
