using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories
{
    public class DayRepository
    {
        private IEnumerable<Day> _days
            = new List<Day>()
            {
                new Day() { Id = 1, Name = "Hétfő" },
                new Day() { Id = 2, Name = "Kedd" },
                new Day() { Id = 3, Name = "Szerda" },
                new Day() { Id = 4, Name = "Csütörtök" },
                new Day() { Id = 5, Name = "Péntek" },
                new Day() { Id = 6, Name = "Szombat" },
                new Day() { Id = 7, Name = "Vasárnap" },
            };


        public IEnumerable<Day> GetAll()
        {
            return _days;
        }
    }
}
