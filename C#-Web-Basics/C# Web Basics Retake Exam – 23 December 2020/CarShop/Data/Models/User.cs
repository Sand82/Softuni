﻿using System;
using System.ComponentModel.DataAnnotations;

using static CarShop.Data.Constants;

namespace CarShop.Data.Models
{
    public class User
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(UserMaxLenght)]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]       
        public string Password { get; set; }

        public bool IsMechanic { get; set; }
    }
}
