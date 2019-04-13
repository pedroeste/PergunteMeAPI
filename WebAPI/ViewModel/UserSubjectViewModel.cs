using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.ViewModel
{
    public class UserSubjectViewModel
    {
        public IEnumerable<int> usersId { get; set; }
        public IEnumerable<int> subjectsId { get; set; }
    }
}
