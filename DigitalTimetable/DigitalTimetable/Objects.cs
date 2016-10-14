﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DigitalTimetable
{
    class Subject
    {
        // Foremost properties (most integral/obvious)

        private string _name; // backing field: we want custom behaviour on this accessor
        public string Name
        {
            get
            {
                return _name; // With custom behaviour the {get;set;} shortcut is unavailable, which normally includes an (invisible) backing field.
            }
            set
            {
                _name = value; // update backing field
                Abbreviation = value.GetSubjAbbreviation(); // Generate a new abbreviation automatically, reduces overhead in name changes
            }
        }

        // Miscellanious properties

        public string Abbreviation { get; private set; }
        public SubjectUIElement Element { get; private set; } // auto-generated 


        public Subject(string n)
        {
            Name = n;

        }
    }

    class Lesson : Subject
    {
        public Lesson(string n, int p, int d) : base(n)
        {
            Period = p; Day = d;
        }

        public int Period { get; set; }
        public int Day { get; set; }
    }

    //hierarchy: subject class spawns ui elements

    class SubjectUIElement
    {
        public Rectangle BG { get; set; }
        public Label Text { get; set; }
        public StackLayout Backbone { get; private set; }

        public Lesson Parent { get; set; }

        public SubjectUIElement(Lesson parent)
        {
            Parent = parent;
            Text.Text = parent.Abbreviation;

        }
    }
}