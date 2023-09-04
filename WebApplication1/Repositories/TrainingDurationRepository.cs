using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories
{
    public class TrainingDurationRepository
    {
        private IEnumerable<TrainingDuration> _durations { get; set; }
            = new List<TrainingDuration>()
            {
                new TrainingDuration()
                {
                    Id = 1,
                    Duration = "20-35 perc"
                },
                new TrainingDuration()
                {
                    Id = 2,
                    Duration = "40-60 perc"
                },
                new TrainingDuration()
                {
                    Id = 3,
                    Duration = "60+ perc"
                }
            };

        public IEnumerable<TrainingDuration> GetAll()
        {
            return _durations;
        }
    }
}
