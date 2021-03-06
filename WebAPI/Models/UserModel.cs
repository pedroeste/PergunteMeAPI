﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class UserModel
    {
        [Key]
        public int id { get; set; }
        public string cpf { get; set; }
        public string name { get; set; }
        public string password { get; set; }
        public string ra { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public bool isAdmin { get; set; }
        public bool isActive { get; set; }
    }
}
