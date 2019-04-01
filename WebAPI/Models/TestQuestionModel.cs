using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class TestQuestionModel
    {
        [Key]
        public int id { get; set; }
        public int testId { get; set; }
        public int questionId { get; set; }

        [ForeignKey("testId")]
        public virtual TestModel Test { get; set; }
        [ForeignKey("questionId")]
        public virtual QuestionModel Question { get; set; }
    }
}
