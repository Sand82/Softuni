﻿using System;
using System.Collections.Generic;

namespace PersonsInfo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var lines = int.Parse(Console.ReadLine());
            var persons = new List<Person>();
            for (int i = 0; i < lines; i++)
            {
                var cmdArgs = Console.ReadLine().Split();
                var person = new Person(cmdArgs[0],
                                        cmdArgs[1],
                                        int.Parse(cmdArgs[2]),
                                        decimal.Parse(cmdArgs[3]));

                persons.Add(person);
            }       
            
            Team team = new Team("SoftUni");
            persons.ForEach(p => team.AddPlayer(p));

            Console.WriteLine($"First team: {team.FirstTeam.Count}");           
            Console.WriteLine($"Reserve team: {team.ReserveTeam.Count}");           

        }
    }
}
