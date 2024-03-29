﻿using SOLID_Exercise.Layout;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID_Exercise.Core.Factories
{
    public interface ILayoutFactory
    {
        ILayout CreateLayout(string type);
    }
}
