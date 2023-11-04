﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using TripleTwo.Entities;

namespace TripleTwo.Areas.Partner.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Enter UserName.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = ("Enter Password."))]
        public string Password { get; set; }
    }
}