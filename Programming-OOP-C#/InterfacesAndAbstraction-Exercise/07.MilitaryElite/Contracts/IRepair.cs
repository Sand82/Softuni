﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _07.MilitaryElite.Contracts
{
    public interface IRepair 
    {
        string PartName { get; }

        int HourdWorked { get; }
    }
}
