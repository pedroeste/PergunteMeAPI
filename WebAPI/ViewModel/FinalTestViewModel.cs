using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.ViewModel
{
    public class FinalTestViewModel
    {
        public TestModel test { get; set; }
        public List<QuestionModel> questions { get; set; }
    }
}
