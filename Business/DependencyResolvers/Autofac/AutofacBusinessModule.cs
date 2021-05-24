using Autofac;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();
            builder.RegisterType<EfUserDal>().As<IUserDal>().SingleInstance();

            builder.RegisterType<FoodManager>().As<IFoodService>().SingleInstance();
            builder.RegisterType<EfFoodDal>().As<IFoodDal>().SingleInstance();

            builder.RegisterType<ProcessManager>().As<IProcessService>().SingleInstance();
            builder.RegisterType<EfProcessDal>().As<IProcessDal>().SingleInstance();
        }
    }
}
