using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class UserSubjectModel
    {
        [Key]
        public int id { get; set; }
        public int userId { get; set; }
        public int subjectId { get; set; }

        [ForeignKey("userId")]
        public virtual UserModel User { get; set; }
        [ForeignKey("subjectId")]
        public virtual SubjectModel Subject { get; set; }
    }
}
