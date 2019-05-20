using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.ViewModel
{
    public class TestViewModel
    {
        public TestModel  test { get; set; }
        public IEnumerable<SubjectQuestionViewModel> subjectsList { get; set; }
    }
}
