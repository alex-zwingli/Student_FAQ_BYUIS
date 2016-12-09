using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Student_FAQ_BYUIS.Models
{
    [Table("Question")]
    public class Questions
    {
        [Key]
        public int QuestionID { get; set; }
        public int DegreeID { get; set; }
        public int UserID { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
    }
}