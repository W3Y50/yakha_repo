﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooClassLibrary.Models
{
    public class Species
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public string Diet { get; set; }
        public string Name { get; set; }
        public Guid Location { get; set; }
    }
}
