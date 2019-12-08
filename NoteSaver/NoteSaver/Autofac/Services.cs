using Autofac;
using DataBaseModel;
using NoteSaver.Services;
using NoteSaver.Services.Concrete;
using System.Windows.Forms;

namespace NoteSaver.Autofac
{
    public class Services : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            //DbContext
            builder.Register(t => new NoteSaverEntities()).AsSelf();

            //Services
            builder.RegisterType<ConstructTreeList>().As<IConstructTreeList>();

            //Forms
            builder.RegisterAssemblyTypes(System.Reflection.Assembly.GetExecutingAssembly()).AssignableTo<Form>();
        }
    }
}
