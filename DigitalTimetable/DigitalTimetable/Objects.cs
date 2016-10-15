using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DigitalTimetable
{
    class Subject
    {
        

        private string _name; // backing field. See below for explanation.
        public string Name
        {
            get
            {
                return _name; // With custom behaviour the {get;set;} shortcut is unavailable, which normally includes an (invisible) backing field.
                // Without a backing field, attempting to access the current variable in a return statement will produce infinite recursion.
            }
            set
            {
                _name = value; // update backing field
                Abbreviation = value.GetSubjAbbreviation(); // Generate a new abbreviation automatically, saves hassle
            }
        }

        // Miscellanious properties

        public string Abbreviation { get; private set; } // Since we auto-generate the abbreviation, there should be no need to change it manually.

        public Subject(string n)
        {
            Name = n; // Initialize properties.
        }
    }

    class Lesson : Subject // Extends subject class by adding times/dates
    {

        public int Period { get; set; }
        public int Day { get; set; }

        public string Location { get; set; }
        public string Teacher { get; set; }

        public Lesson(string name, int period, int day, string where, string teacher) : base(name)
        {
            Period = period; Day = day; Location = where; Teacher = teacher;
        }

        public SubjectUIElement GenerateUIElement()
        {
            return new SubjectUIElement(this);
            // We have a method that generates UI elements rather than a simple property because this means that
            // the UI elements are not tied to any given instance of a Lesson. This could be helpful if we were to
            // implement multiple ways to view a timetable, for instance.
        }
    }

    //hierarchy: subject class spawns ui elements

    class SubjectUIElement
    {
        
        public Label MainLabel { get; set; }
        public StackLayout Backbone { get; private set; }

        public Lesson Parent { get; set; }

        public SubjectUIElement(Lesson parent)
        {
            Parent = parent;
            MainLabel.Text = parent.Abbreviation;
            Backbone.BackgroundColor = parent.Abbreviation.GetSubjColor();
        }
    }
}
