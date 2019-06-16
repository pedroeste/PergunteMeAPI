using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.ViewModel
{
    public class AddQuestionViewModel
    {
        public QuestionModel question { get; set; }
        public IFormFile document { get; set; }
    }
}
