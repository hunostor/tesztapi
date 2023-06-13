using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories
{
    public class TrainersRepository
    {
        private List<Trainer> _trainers = new List<Trainer>()
        {
            new Trainer()
            {
                Id = 1,
                Name = "Trainer 1",
            },
            new Trainer()
            {
                Id = 2,
                Name = "Trainer 2",
            },
            new Trainer()
            {
                Id = 3,
                Name = "Trainer 3",
            },
            new Trainer()
            {
                Id = 4,
                Name = "Trainer 4",
            },
            new Trainer()
            {
                Id = 5,
                Name = "Trainer 5",
            },
        };

        public IEnumerable<Trainer> GetAll()
        {
            return _trainers;
        }
    }
}
