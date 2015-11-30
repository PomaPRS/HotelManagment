using System;
using System.Data.Entity;
using System.Web;
using Hotel.Database;
using Hotel.Database.Common;
using Hotel.Database.Model;
using Hotel.Web.Common;
using HotelInfo;
using HotelInfo.BuilderCommands;
using HotelInfo.ModelBuilders;
using HotelInfo.Models;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Ninject;
using Ninject.Web.Common;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethod(typeof(NinjectWebCommon), "Stop")]

namespace HotelInfo
{
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
            var kernel = new StandardKernel(new NinjectSettings {InjectNonPublic = true});
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
            kernel.Bind<DbContext>().To<HotelContext>();

            kernel.Bind<IRepository<Hotel.Database.Model.Hotel>>().To<Repository<Hotel.Database.Model.Hotel>>();
            kernel.Bind<IRepository<Worker>>().To<Repository<Worker>>();
            kernel.Bind<IRepository<Position>>().To<Repository<Position>>();

            kernel.Bind<IModelBuilder<HotelIndexViewModel, HotelFilterModel>>().To<HotelIndexViewBuilder>();
            kernel.Bind<IModelBuilder<HotelViewModel, Hotel.Database.Model.Hotel>>().To<HotelViewModelBuilder>();
            kernel.Bind<IModelBuilder<HotelEditModel, Hotel.Database.Model.Hotel>>().To<HotelEditModelBuilder>();
            kernel.Bind<IModelCommand<HotelEditModel, Hotel.Database.Model.Hotel>>().To<HotelEditCommand>();
            kernel.Bind<IModelCommand<HotelCreateModel, Hotel.Database.Model.Hotel>>().To<HotelCreateCommand>();

            kernel.Bind<IModelBuilder<WorkerIndexViewModel, WorkerFilterModel>>().To<WorkerIndexViewBuilder>();
            kernel.Bind<IModelBuilder<WorkerViewModel, Worker>>().To<WorkerViewModelBuilder>();
            kernel.Bind<IModelBuilder<WorkerEditModel, Worker>>().To<WorkerEditModelBuilder>();
            kernel.Bind<IModelCommand<WorkerEditModel, Worker>>().To<WorkerEditCommand>();
            kernel.Bind<IModelCommand<WorkerCreateModel, Worker>>().To<WorkerCreateCommand>();

            kernel.Bind<IModelBuilder<PositionIndexViewModel, PositionFilterModel>>().To<PositionIndexViewBuilder>();
            kernel.Bind<IModelBuilder<PositionViewModel, Position>>().To<PositionViewModelBuilder>();
            kernel.Bind<IModelBuilder<PositionEditModel, Position>>().To<PositionEditModelBuilder>();
            kernel.Bind<IModelCommand<PositionEditModel, Position>>().To<PositionEditCommand>();
            kernel.Bind<IModelCommand<PositionCreateModel, Position>>().To<PositionCreateCommand>();
        }
    }
}
