using System;
using System.Collections.Generic;
using System.Text;

namespace IGym.DietGenerator.Models.Interfaces
{
    public interface ICloneable<T> where T : class
    {
        T Clone();
    }
}
