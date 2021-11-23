﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop.Dtos.Export
{
    [XmlType("Category")]
    public class CategoryOutputModels
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("count")]
        public int ProductsCount { get; set; }

        [XmlElement("averagePrice")]
        public decimal AveragePrice { get; set; }

        [XmlElement("totalRevenue")]
        public decimal TotalRevenue { get; set; }
    }
}

//< Category >
//    < name > Garden </ name >
//    < count > 23 </ count >
//    < averagePrice > 709.94739130434782608695652174 </ averagePrice >
//    < totalRevenue > 16328.79 </ totalRevenue >
//  </ Category >
