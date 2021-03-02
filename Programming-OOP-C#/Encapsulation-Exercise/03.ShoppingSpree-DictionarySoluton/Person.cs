﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03.ShoppingSpree_DictionarySoluton
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> products;

        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;

            products = new List<Product>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                Validator.ThtowIfStringIsNullOrEmpty(value, "Name cannot be empty");
                this.name = value;
            }
        }

        public decimal Money 
        {
            get => this.money;
            private set 
            {
                Validator.ThrowIfValueIsLessThanNull(value, "Money cannot be negative");
                this.money = value;
            }         
        }
        public void AddProduct(Product product) 
        {
            if (product.Cost > this.Money)
            {
                throw new InvalidOperationException($"{this.Name} can't afford {product.Name}");
            }
            this.products.Add(product);
            this.Money -= product.Cost;  
        }

        public override string ToString()
        {
            if (this.products.Count == 0)
            {
                return $"{this.Name} - Nothing bought ";
            }

            return $"{this.Name} - {string.Join(", ", this.products.Select(p => p.Name))}";
        }

    }
}
