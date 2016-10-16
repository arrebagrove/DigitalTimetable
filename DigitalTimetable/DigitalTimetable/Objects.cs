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
                if (!ColourOverriden)
                    Colour = value.GetSubjColor(); // see above
            }
        }

        // Miscellanious properties

        public string Abbreviation { get; private set; } // Since we auto-generate the abbreviation, there should be no need to change it manually.

        public Color Colour { get; private set; }
        // This was also auto-generated, but is in the base class as I want users to be able to change subject colours.
        // Also, my British spelling finally came in handy as I can name it something useful without it being a type. Yay!

        private bool ColourOverriden; // We can use this to not update colours in Name accessors if the user has specified another colour.

        // Constructors

        public Subject(string n)
        {
            Name = n; // Initialize properties.
        }     

        public Subject (string name, Color overrideColour)
        {
            Name = name; Colour = overrideColour;
            ColourOverriden = true;
        }

        // Methods

        public Lesson CreateLesson(int period, int day, string location, string teacher)
        {
            return new Lesson(this, period, day, location, teacher);
            // Create a lesson given some extra information
        }
    }

    class Lesson // Extends subject class by adding times/dates
    {

        public int Period { get; set; }
        public int Day { get; set; }

        public string Location { get; set; }
        public string Teacher { get; set; }

        public Subject Parent { get; set; }

        public Lesson(Subject parent, int period, int day, string where, string teacher)
        {
            Period = period; Day = day; Location = where; Teacher = teacher;
            Parent = parent;
        }

        public LessonUIElement GenerateUIElement()
        {
            return new LessonUIElement(this);
            // We have a method that generates UI elements rather than a simple property because this means that
            // the UI elements are not tied to any given instance of a Lesson. This could be helpful if we were to
            // implement multiple ways to view a timetable, for instance.
        }
    }

    //hierarchy: subject class spawns ui elements

    class LessonUIElement
    {
        
        public Label MainLabel { get; set; }
        public StackLayout Backbone { get; private set; }

        public Lesson LParent { get; set; }
        public Subject SParent { get; set; } // to avoid calls such as Parent.Parent which are confusing

        public LessonUIElement(Lesson parent)
        {
            LParent = parent;
            SParent = parent.Parent; // well, you have to do it once but it's a necessary sacrifice.

            MainLabel.Text = SParent.Abbreviation;
            Backbone.BackgroundColor = SParent.Colour;
        }
    }
}
