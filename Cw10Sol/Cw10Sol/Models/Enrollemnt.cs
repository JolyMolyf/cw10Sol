using System;
using System.Collections.Generic;

namespace Cw10Sol.Models
{

    
        public partial class Enrollment
        {
            public int IdEnrollment { get; set; }
            public int IdStudy { get; set; }
            public DateTime StartDate { get; set; }

            public virtual Studies IdStudyNavigation { get; set; }
            public virtual ICollection<Student> Student { get; set; }
        }
    
}