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
            Subject FM = new Subject("Further Maths");
            Lesson FM1 = FM.CreateLesson(4, 4, "a", "b");
            LessonUIElement FM1_UI = FM1.GenerateUIElement();
            
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
