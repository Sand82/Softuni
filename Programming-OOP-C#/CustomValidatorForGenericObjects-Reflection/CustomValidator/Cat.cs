﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CustomValidator
{
    public class Cat : IValidatable
    {
        [Required]
        [StringLength(20, MinimumLength = 2)]
        public string Name { get; set; } = "Unknown";
        [Range(1,20)]
        public int Age { get; set; }
        [StringLength (10)]
        [Color("Black", "White", "Red")]
        public string Color { get; set; }

        public IDictionary<string, List<string>> Validate()
        {
            var result = new Dictionary<string, List<string>>();
            if (this.Age < 2 && this.Name != "Unknown")
            {
                result[this.GetType().Name] = new List<string>
                {"this cat is too young to have a name"};               
            }

            return result;
        }
    }
}
