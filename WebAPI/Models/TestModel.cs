﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class TestModel
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public DateTime dueDate { get; set; }

        public ICollection<QuestionModel> Questions { get; set; }
    }
}
