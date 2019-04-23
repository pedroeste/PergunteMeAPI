using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class AlternativeModel
    {
        [Key]
        public int id { get; set; }
        public string alternative1 { get; set; }
        public string alternative2 { get; set; }
        public string alternative3 { get; set; }
        public string alternative4 { get; set; }
        public string alternative5 { get; set; }
        public bool isActive { get; set; }
    }
}
