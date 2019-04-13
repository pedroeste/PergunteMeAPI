using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.ViewModel
{
    public class CourseSubjectViewModel
    {
        public IEnumerable<int> subjectsId { get; set; }
        public IEnumerable<int> coursesId { get; set; }
    }
}
