using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.ViewModel
{
    public class CreateQuestionAlternative
    {
        public QuestionModel question { get; set; }
        public AlternativeModel alternatives { get; set; }
    }
}
