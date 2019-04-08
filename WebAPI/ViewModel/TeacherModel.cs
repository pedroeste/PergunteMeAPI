using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.ViewModel
{
    public class TeacherModel
    {
        public UserModel user { get; set; }
        public IEnumerable<SubjectModel> subjects { get; set; }
    }
}
