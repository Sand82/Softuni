﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Cinema.Data.Models
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }

        public decimal Price { get; set; }

        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        public int ProjectionId { get; set; }

        public Projection Projection { get; set; }
    }
}
//•	Id – integer, Primary Key
//•	Price – decimal (non-negative, minimum value: 0.01) (required)
//•	CustomerId – integer, foreign key(required)
//•	Customer – the customer’s ticket 
//•	ProjectionId – integer, foreign key (required)
//•	Projection – the projection’s ticket
