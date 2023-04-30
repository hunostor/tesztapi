using IGym.DietGenerator.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace IGym.DietGenerator.Models.Interfaces
{
    public interface IMealTag
    {
        /// <summary>
        /// Appears either in a menu e.g. options
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// appears in connection with a meal
        /// </summary>
        public string Tag { get; set; }

        /// <summary>
        /// detailed description of the conditioner
        /// </summary>
        public string Description { get; set; }
    }
}
