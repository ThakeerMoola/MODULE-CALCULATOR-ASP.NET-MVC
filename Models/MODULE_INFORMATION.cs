//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace part3.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class MODULE_INFORMATION
    {
        public string MODULE_CODE { get; set; }
        public string MODUL_NAME { get; set; }
        public int CREDITS { get; set; }
        public int CLASS_HOURS { get; set; }
        public int NUMBER_OF_WEEKS { get; set; }
        public int HOURS_SPENT { get; set; }
        public Nullable<int> PlannedDayOfWeek { get; set; }
        public Nullable<System.DateTime> START_DATE { get; set; }
        public Nullable<System.DateTime> END_DATE { get; set; }
    }
}