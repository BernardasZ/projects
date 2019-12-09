using Autofac;
using Autofac.Extras.CommonServiceLocator;
using CommonServiceLocator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new Autofac.ContainerBuilder();
            builder.RegisterModule(new AutofacServices());
            var container = builder.Build();
            ServiceLocator.SetLocatorProvider(() => new AutofacServiceLocator(container));

            ServiceLocator.Current.GetInstance<RegisterService>().Validation();

            Console.ReadLine();
        }        
    }

    public class RegisterService
    {
        private readonly IEnumerable<IRegistrationPreCheck> _registrationPreChecks;

        public RegisterService(IEnumerable<IRegistrationPreCheck> registrationPreChecks)
        {
            _registrationPreChecks = registrationPreChecks;
        }

        public void Validation()
        {
            // Puiki validacija, kai reikia patikrinti daug sąlygų!!!!!!

            _registrationPreChecks.ToList().ForEach(x => x.Check());
        }
    }


    public interface IRegistrationPreCheck
    {
        void Check();
    }

    public class RegistrationPreCheck1 : IRegistrationPreCheck
    {
        public RegistrationPreCheck1()
        {
        }

        public void Check()
        {
            Console.WriteLine("1");
        }
    }

    public class RegistrationPreCheck2 : IRegistrationPreCheck
    {
        public RegistrationPreCheck2()
        {
        }

        public void Check()
        {
            Console.WriteLine("2");
        }
    }

    public class RegistrationPreCheck3 : IRegistrationPreCheck
    {
        public RegistrationPreCheck3()
        {
        }

        public void Check()
        {
            Console.WriteLine("3");
        }
    }
}
