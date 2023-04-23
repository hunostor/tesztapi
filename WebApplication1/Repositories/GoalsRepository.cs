using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories
{
    public class GoalsRepository
    {
        private IEnumerable<Goal> _goals
            = new List<Goal>()
            {
                new Goal()
                {
                    Id = 1,
                    Name = "WeightGain",
                },
                new Goal()
                {
                    Id = 2,
                    Name = "WeightLoss",
                },
            };

        public IEnumerable<Goal> GetAll()
        {
            return _goals;
        }
    }
}
