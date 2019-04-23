using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class SchoolModel
    {
        [Key]
        public int id { get; set; }
        public string Name { get; set; }
        public bool isActive { get; set; }
    }
}
