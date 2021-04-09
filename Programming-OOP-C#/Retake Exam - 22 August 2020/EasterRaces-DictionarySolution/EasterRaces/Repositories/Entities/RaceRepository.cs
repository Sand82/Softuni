﻿using EasterRaces.Models.Races.Contracts;
using EasterRaces.Repositories.Contracts;
using EasterRaces.Utilities;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EasterRaces.Repositories.Entities
{
    public class RaceRepository : IRepository<IRace>
    {
        private IDictionary<string, IRace> raceByName;

        public RaceRepository()
        {
            raceByName = new Dictionary<string, IRace>();
        }

        public void Add(IRace model)
        {
            if (raceByName.ContainsKey(model.Name))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExists, model.Name));
            }

            raceByName.Add(model.Name, model);
        }

        public IReadOnlyCollection<IRace> GetAll()
        {
            return this.raceByName.Values.ToList();
        }

        public IRace GetByName(string name)
        {
            return this.raceByName.GetByKeyOrDefault(name);
        }

        public bool Remove(IRace model)
        {
            return this.raceByName.Remove(model.Name);
        }
    }
}
