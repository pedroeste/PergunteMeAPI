using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.ViewModel
{
    public class SubjectQuestionViewModel
    {
        public SubjectModel subject { get; set; }
        public int questionsNumber { get; set; }
    }
}
