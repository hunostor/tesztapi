using IGym.DietGenerator.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IGym.DietGenerator.Responses
{
    public class ShoppingListResponse
    {
        public IList<ShoppingListResponseItem> Weeks { get; set; } = new List<ShoppingListResponseItem>();
    }

}
