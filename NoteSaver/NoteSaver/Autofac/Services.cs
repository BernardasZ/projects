using Autofac;
using System.Windows.Forms;

namespace NoteSaver.Autofac
{
    public class Services : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            //Services




            //Forms
            builder.RegisterAssemblyTypes(System.Reflection.Assembly.GetExecutingAssembly()).AssignableTo<Form>();
        }
    }
}
