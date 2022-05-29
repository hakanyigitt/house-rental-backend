using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concreate;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concreate.EntityFramework;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBussinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>().SingleInstance();
            builder.RegisterType<CategoryManager>().As<ICategoryService>().SingleInstance();

            builder.RegisterType<EfHouseDal>().As<IHouseDal>().SingleInstance();
            builder.RegisterType<HouseManager>().As<IHouseService>().SingleInstance();

            builder.RegisterType<EfHouseImageDal>().As<IHouseImageDal>().SingleInstance();
            builder.RegisterType<HouseImageManager>().As<IHouseImageService>().SingleInstance();

            builder.RegisterType<EfHouseRentalDal>().As<IHouseRentalDal>().SingleInstance();
            builder.RegisterType<HouseRentalManager>().As<IHouseRentalService>().SingleInstance();

            builder.RegisterType<EfCityDal>().As<ICityDal>().SingleInstance();
            builder.RegisterType<CityManager>().As<ICityService>().SingleInstance();

            builder.RegisterType<EfUserDal>().As<IUserDal>().SingleInstance();
            builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();

            builder.RegisterType<LoggedUserManager>().As<ILoggedUserService>().SingleInstance();

            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
