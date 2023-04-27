﻿using System.Collections.Generic;

namespace Exam.MovieDatabase
{
    public class Actor
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public List<Movie> Movies = new List<Movie>();

        public Actor(string id, string name, int age)
        {
            Id = id;
            Name = name;
            Age = age;
        }
    }
}
