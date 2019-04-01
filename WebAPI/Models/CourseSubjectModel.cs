using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class CourseSubjectModel
    {
        [Key]
        public int id { get; set; }
        public int courseId { get; set; }
        public int subjectId { get; set; }

        [ForeignKey("courseId")]
        public virtual CourseModel Course { get; set; }
        [ForeignKey("subjectId")]
        public virtual SubjectModel Subject { get; set; }
    }
}
