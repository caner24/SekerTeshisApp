﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SekerTeshisApp.Application.CQRS.Home.Responses
{
    public class CalculateSugarResponse
    {
        public DateTime DateTime { get; set; }
        public string Type { get; set; }
    }
}
