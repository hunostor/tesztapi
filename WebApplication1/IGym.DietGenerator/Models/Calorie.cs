using System;
using System.Collections.Generic;
using System.Text;

namespace IGym.DietGenerator.Models
{
    public class Calorie
    {
        public decimal Value { get; }        

        public Calorie(decimal calorie)
        {
            this.Value = calorie;
        }

        public static bool operator > (Calorie a, Calorie b)
        {
            if(a.Value > b.Value)
                return true;

            return false;
        }

        public static bool operator < (Calorie a, Calorie b)
        {
            if (a.Value < b.Value)
                return true;

            return false;
        }

        public static bool operator == (Calorie a, Calorie b)
        {
            return a.Value == b.Value;
        }

        public static bool operator != (Calorie a, Calorie b)
        {
            return a.Value != b.Value; ;
        }

        public static Calorie operator +(Calorie a, Calorie b)
        {
            return new Calorie(a.Value + b.Value);
        }

        public static Calorie operator -(Calorie a, Calorie b)
        {
            return new Calorie(a.Value - b.Value);
        }

    }
}
