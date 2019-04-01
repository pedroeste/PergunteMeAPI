using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class SubjectModel
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
    }
}
