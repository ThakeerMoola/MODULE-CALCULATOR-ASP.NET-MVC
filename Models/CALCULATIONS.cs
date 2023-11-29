using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace part3.Models
{
    public class CALCULATIONS
    {
        public string MODULE_CODE { get; set; }
        public string MODULE_NAME { get; set; }
        public int CREDITS { get; set; }
        public int CLASS_HOURS { get; set; }
        public int NUMBER_OF_WEEKS { get; set; }
        public int HOURS_SPENT { get; set; }

        public int PlannedDayOfWeek { get; set; }
        public DateTime START_DATE { get; set; }

        [Display(Name = "End Date")]
        public DateTime END_DATE { get; set; }





        public class MODULE_INFORM
        {
            // ... other properties ...

            [DataType(DataType.Date)]
            [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
            public DateTime StartDate { get; set; }

            [DataType(DataType.Date)]
            [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
            public DateTime EndDate { get; set; }
        }
    }
}

