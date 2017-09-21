﻿using System.ComponentModel.DataAnnotations;

namespace MusicLibrary.Web.Models.Identity
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "User name:")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Password:")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}