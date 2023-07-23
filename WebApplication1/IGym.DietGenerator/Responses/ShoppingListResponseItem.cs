using System;
using System.Collections.Generic;
using System.Text;

namespace IGym.DietGenerator.Responses
{
    public class ShoppingListResponseItem
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public IList<ShoppingListCategory> Categories { get; set; }
            = new List<ShoppingListCategory>();
    }
}
