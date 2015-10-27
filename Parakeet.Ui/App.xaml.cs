using System;
using System.Reflection;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Ninject.Modules;
using Ninject;
using Parakeet.Services;

namespace Parakeet.Ui
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            var kernel = new StandardKernel();
            kernel.Load(new NInjectConfiguration());


            var simpleService = kernel.Get<ISimpleService>();
            var simpleServiceTwo = kernel.Get<ISimpleServiceTwo>();

            Console.ReadLine();
        }
    }
}
