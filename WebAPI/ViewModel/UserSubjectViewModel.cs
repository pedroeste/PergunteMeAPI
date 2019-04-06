using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.ViewModel
{
    public class UserSubjectViewModel
    {
        public int userId { get; set; }
        public IEnumerable<int> subjectsId { get; set; }
    }
}
