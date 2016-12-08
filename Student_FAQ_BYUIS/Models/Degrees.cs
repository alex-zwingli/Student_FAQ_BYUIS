using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace Student_FAQ_BYUIS.Models
{
    [Table("Degree")]
    public class Degrees
    {
        [Key]
        [ScaffoldColumn(false)]
        public int DegreeID { get; set; }

        [Required(ErrorMessage = "Please enter a name.")]
        [StringLength(50, ErrorMessage = "Name is too long for data entry.")]
        public string Name { get; set; }

        
        public int? CoordinatorID { get; set; }
    }
}