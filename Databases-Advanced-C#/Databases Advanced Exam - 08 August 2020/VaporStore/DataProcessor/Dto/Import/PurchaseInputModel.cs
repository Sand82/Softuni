﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;
using VaporStore.Data.Models.Enums;

namespace VaporStore.DataProcessor.Dto.Import
{
    [XmlType("Purchase")]
    public class PurchaseInputModel
    {
        [Required]
        [XmlAttribute("title")]
        public string Name { get; set; }

        [Required]
        [XmlElement("Type")]
        public PurchaseType? Type { get; set; }

        [Required]
        [RegularExpression(@"[A-Z0-9]{3}-[A-Z0-9]{3}-[A-Z0-9]{3}")]
        [XmlElement("Key")]
        public string Key { get; set; }

        [Required]
        [XmlElement("Card")]
        public string Card { get; set; }

        [Required]
        [XmlElement("Date")]
        public string Date { get; set; }
    }
}

//•	Id – integer, Primary Key
//•	Type – enumeration of type PurchaseType, with possible values (“Retail”, “Digital”) (required)
//•	ProductKey – text, which consists of 3 pairs of 4 uppercase Latin letters and digits, separated by dashes (ex. “ABCD-EFGH-1J3L”) (required)
//•	Date – Date(required)
//•	CardId – integer, foreign key(required)
//•	Card – the purchase’s card (required)
//•	GameId – integer, foreign key(required)
//•	Game – the purchase’s game (required)

//< Purchase title = "Dungeon Warfare 2" > 
//   < Type > Digital </ Type > 
//   < Key > ZTZ3 - 0D2S - G4TJ </ Key >      
//   < Card > 1833 5024 0553 6211 </ Card >         
//   < Date > 07 / 12 / 2016 05:49 </ Date >                
//</ Purchase >
