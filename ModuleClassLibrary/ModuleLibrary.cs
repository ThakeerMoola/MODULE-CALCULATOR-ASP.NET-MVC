using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleClassLibrary
{
    public class Module
    {
        // Properties for a module
        public string Code { get; set; } // Unique code for the module
        public string Name { get; set; } // Name of the module
        public int Credits { get; set; } // Number of credits associated with the module
        public int ClassHoursPerWeek { get; set; } // Number of class hours per week

        // Properties related to self-study hours
        public double SelfStudyHoursPerWeek { get; set; } // Number of self-study hours per week
        public double RemainingHoursThisWeek { get; set; } // Remaining self-study hours for the week

        // List to store study records for the module
        public List<StudyRecord> RecordedHours { get; set; } = new List<StudyRecord>();

        // Constructor for the Module class
        public Module()
        {
            // Initialize the list of study records
            RecordedHours = new List<StudyRecord>();
        }
    }

    // Class to represent a study record
    public class StudyRecord
    {
        public DateTime Date { get; set; } // Date of the study record
        public double Hours { get; set; } // Number of hours studied on the given date
    }
}
