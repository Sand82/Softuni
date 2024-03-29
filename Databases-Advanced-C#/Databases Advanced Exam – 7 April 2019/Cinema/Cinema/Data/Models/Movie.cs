﻿using Cinema.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Cinema.Data.Models
{
    public class Movie
    {
        public Movie()
        {
            this.Projections = new HashSet<Projection>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Title { get; set; }

        [Required]
        [Range(0, 9)] // ??? error 
        public Genre Genre { get; set; }

        public TimeSpan Duration { get; set; }

        [MaxLength(10)]
        public double Rating { get; set; }

        [Required]
        [MaxLength(20)]
        public string Director { get; set; }

        public ICollection<Projection> Projections { get; set; }        
    }
}

//•	Id – integer, Primary Key
//•	Title – text with length [3, 20] (required)
//•	Genre – enumeration of type Genre, with possible values (Action, Drama, Comedy, Crime, Western, Romance, Documentary, Children, Animation, Musical) (required)
//•	Duration – TimeSpan(required)
//•	Rating – double in the range[1, 10] (required)
//•	Director – text with length [3, 20] (required)
//•	Projections - collection of type Projection
