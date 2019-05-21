using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class QuestionModel
    {
        [Key]
        public int id { get; set; }
        public string question { get; set; }
        public string imgUrl { get; set; }
        public string topic { get; set; }
        public string dificulty { get; set; }
        public int subjectId { get; set; }
        public bool isActive { get; set; }

        public string alternative1 { get; set; }
        public string alternative2 { get; set; }
        public string alternative3 { get; set; }
        public string alternative4 { get; set; }
        public string alternative5 { get; set; }

        [ForeignKey("subjectId")]
        public virtual SubjectModel Subject { get; set; }


    }
}
