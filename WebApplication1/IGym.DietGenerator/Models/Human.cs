using IGym.DietGenerator.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace IGym.DietGenerator.Models
{
    public class Human
    {
        public Genders Gender { get; set; }
        public int Age { get; set; }
        public int Heigth { get; set; }
        public int Weight { get; set; }

    }
}
