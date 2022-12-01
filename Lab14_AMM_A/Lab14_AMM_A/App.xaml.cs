using Lab14_AMM_A.DataContext;
using Lab14_AMM_A.Interfaces;
using Lab14_AMM_A.Services;
using Lab14_AMM_A.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lab14_AMM_A
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            GetContext().Database.EnsureCreated();
            //MainPage = new PeopleView();
            MainPage = new EstudianteView();
        }


        public static AppDbContext GetContext()
        {
            string DbPath = DependencyService.Get<IConfigDataBase>().GetFullPath("efCore.db");

            return new AppDbContext(DbPath);
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
