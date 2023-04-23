﻿using IGym.DietGenerator.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace IGym.DietGenerator.Models
{
    public class Ingredient
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public UnitOfMeasurements Unit { get; set; }
    }
}
