﻿using SOLID_Exercise.Layout;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID_Exercise.Core.Factories
{
    public class LayoutFactory : ILayoutFactory
    {
        public ILayout CreateLayout(string type)
        {
            ILayout layout = null;

            switch (type)
            {
                case nameof(SimpleLayout):
                    layout = new SimpleLayout();
                    break;
                case nameof(XmlLayout):
                    layout = new XmlLayout();
                    break;
                case nameof(JsonLayout):
                    layout = new JsonLayout();
                    break;
                default:
                    throw new ArgumentException($"{type} is invalide Layout type.");
            }
            return layout;
        }
    }
}
