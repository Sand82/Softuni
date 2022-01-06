﻿using MyFirstMvcApp.Controllers;
using SUS.HTTP;
using SUS.mvcFramework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyFirstMvcApp
{
    public class Program
    {
        static async Task Main(string[] args)
        {               
            
            await Host.CreateHostAsync(new StartUp(), 80);
        }       

    }  
}
