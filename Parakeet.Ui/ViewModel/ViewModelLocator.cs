﻿/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocatorTemplate xmlns:vm="clr-namespace:HelloWorld.ViewModel"
                                   x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"
*/

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using Parakeet.Data;
using Parakeet.Data.Repositories;
using Parakeet.Services;
using Parakeet.Ui.Model;

namespace Parakeet.Ui.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// <para>
    /// See http://www.mvvmlight.net
    /// </para>
    /// </summary>
    public class ViewModelLocator
    {
        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            if (ViewModelBase.IsInDesignModeStatic)
            {
                SimpleIoc.Default.Register<IDataService, Design.DesignDataService>();
                SimpleIoc.Default.Register<IEmployeeService, Design.EmployeeService>();
                SimpleIoc.Default.Register<IDatabaseFileManager, Design.DatabaseFileManager>();
                SimpleIoc.Default.Register<IConfigurationService, Design.ConfigurationService>();
                SimpleIoc.Default.Register<IPeopleRepository, Design.PeopleRepository>();
                SimpleIoc.Default.Register<IRoleService, Design.RoleService>();
            }
            else
            {
                SimpleIoc.Default.Register<IDataService, DataService>();
                SimpleIoc.Default.Register<IDatabaseFileManager, DatabaseFileManager>();
                SimpleIoc.Default.Register<IEmployeeService, EmployeeService>();
                SimpleIoc.Default.Register<IRoleService, RoleService>();
                SimpleIoc.Default.Register<IConfigurationService, ConfigurationService>();
                SimpleIoc.Default.Register<IPeopleRepository, PeopleRepository>();
                SimpleIoc.Default.Register<IRoleRepository, RoleRepository>();
            }

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<EmployeeCenterViewModel>();
            SimpleIoc.Default.Register<HomeViewModel>();
            SimpleIoc.Default.Register<RoleCenterViewModel>();
        }

        /// <summary>
        /// Gets the Main property.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        /// <summary>
        /// Gets the Main property.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public EmployeeCenterViewModel EmployeeCenter
        {
            get
            {
                return ServiceLocator.Current.GetInstance<EmployeeCenterViewModel>();
            }
        }

        /// <summary>
        /// Gets the Main property.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public HomeViewModel Home
        {
            get
            {
                return ServiceLocator.Current.GetInstance<HomeViewModel>();
            }
        }

        /// <summary>
        /// Gets the RoleCenter property.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public RoleCenterViewModel RoleCenter
        {
            get
            {
                return ServiceLocator.Current.GetInstance<RoleCenterViewModel>();
            }
        }

        /// <summary>
        /// Cleans up all the resources.
        /// </summary>
        public static void Cleanup()
        {
        }
    }
}