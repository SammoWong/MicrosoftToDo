using System;
using ToDoApp.Core;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDoApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            AutofacLocator autofac = new AutofacLocator();
            autofac.Register();
            ServiceProvider.RegisterServiceLocator(autofac);
            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
