using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class CourseModel
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public int schoolId { get; set; }

        [ForeignKey("schoolId")]
        public virtual SchoolModel School { get; set; } // virtual       
    }
}
