using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Student_FAQ_BYUIS.Models
{
    public class DegreeCoordinatorQuestions
    {
        public Degrees Degrees { get; set; }
        public Coordinators Coordinators { get; set; }
        public IEnumerable<Questions> Questions { get; set; }
    }
}