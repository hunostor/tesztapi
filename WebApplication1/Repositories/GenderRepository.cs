using Repositories.Models;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Repositories
{
    public class GenderRepository
    {
        private IEnumerable<Gender> _genders { get; set; }
            = new List<Gender>()
            {
                new Gender()
                {
                    Id = 1,
                    Name = "Male"
                },
                new Gender()
                {
                    Id = 2,
                    Name = "Female"
                }
            };

        public IEnumerable<Gender> GetAll()
        {
            return _genders;
        }
    }
}
