using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace DigitalTimetable
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new DigitalTimetable.MainPage();
        }

        protected override void OnStart()
        {
            
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        void TestButton_Click(object sender, EventArgs args)
        {
            Button b = (Button)sender;
            
        }
    }
}
