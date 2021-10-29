﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EfCodeFirstDemo.Models
{
    [Index(nameof(QuestionId), Name = "XI_QuestionId123)")]
    public class Comment
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Content { get; set; }

        public int QuestionId { get; set; }

        public Question Question { get; set; }
    }
}
