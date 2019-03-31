﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class QuestionModel
    {
        [Key]
        public int id { get; set; }
        public string imgUrl { get; set; } // Azure Blob
        public string topic { get; set; }
        public string  dificulty { get; set; }
        public int alternativeId { get; set; }

        [ForeignKey("alternativeId")]
        public virtual AlternativeModel Alternative { get; set; }
    }
}
