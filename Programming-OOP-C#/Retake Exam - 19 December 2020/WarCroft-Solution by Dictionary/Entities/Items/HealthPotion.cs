﻿using System;
using System.Collections.Generic;
using System.Text;
using WarCroft.Entities.Characters.Contracts;

namespace WarCroft.Entities.Items
{
    public class HealthPotion : Item
    {
        private const int HealthPointWeight = 5;
        public HealthPotion()
            : base(HealthPointWeight)
        {

        }

        public override void AffectCharacter(Character character)
        {        
           
           character.Health += 20;
                        
        }
    }
}
