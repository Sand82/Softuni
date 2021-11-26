﻿using SoftJail.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SoftJail.DataProcessor.ImportDto
{
    public class DepartmentCellInputModel
    {
        [Required]
        [StringLength(25, MinimumLength = 3)]
        public string Name { get; set; }

       
        public List<SellInputModel> Cells { get; set; }
    }

    public class SellInputModel
    {

        [Range(1, 1000)]
        public int CellNumber { get; set; }

        public bool HasWindow { get; set; }
    }
}

//{
//    "Name": "CSS",
//    "Cells": [
//      {
//        "CellNumber": 0,
//        "HasWindow": true
//      },
//      {
//        "CellNumber": 202,
//        "HasWindow": false
//      }
//    ]
//  },
