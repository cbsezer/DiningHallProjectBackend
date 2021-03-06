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

            builder.RegisterType<MenuManager>().As<IMenuService>().SingleInstance();
            builder.RegisterType<EfMenuDal>().As<IMenuDal>().SingleInstance();

            builder.RegisterType<ProcessManager>().As<IProcessService>().SingleInstance();
            builder.RegisterType<EfProcessDal>().As<IProcessDal>().SingleInstance();

            builder.RegisterType<StaffManager>().As<IStaffService>().SingleInstance();
            builder.RegisterType<EfStaffDal>().As<IStaffDal>().SingleInstance();


            builder.RegisterType<UserTypeManager>().As<IUserTypeService>().SingleInstance();
            builder.RegisterType<EfUserTypeDal>().As<IUserTypeDal>().SingleInstance();

            builder.RegisterType<ShiftsManager>().As<IShiftsService>().SingleInstance();
            builder.RegisterType<EfShiftsDal>().As<IShiftsDal>().SingleInstance();
        }
    }
}
