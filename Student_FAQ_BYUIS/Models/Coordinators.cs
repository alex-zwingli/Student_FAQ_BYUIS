using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.ComponentModel.DataAnnotations.Schema;

namespace Student_FAQ_BYUIS.Models
{
    [Table("Coordinator")]
    public class Coordinators
    {
        [Key]
        public int CoordinatorID { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string OfficeAddress { get; set; }
        public string Education_PhD { get; set; }
        public string Education_Masters { get; set; }
        public string Education_Bachelors { get; set; }
        public Image MyProperty { get; set; }
    }
}