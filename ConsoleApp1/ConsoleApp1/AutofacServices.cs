using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class AutofacServices : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            //  Su moduliu neveikia IEnumerable

            builder.RegisterType<RegistrationPreCheck1>().As<IRegistrationPreCheck>();
            builder.RegisterType<RegistrationPreCheck2>().As<IRegistrationPreCheck>();
            builder.RegisterType<RegistrationPreCheck3>().As<IRegistrationPreCheck>();
            builder.RegisterType<RegisterService>();
        }
    }
}
