using IGym.DietGenerator.Models;
using IGym.DietGenerator.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace IGym.DietGenerator.Repositories
{
    public class UnitOfMeasurementRepository : Interfaces.IRepository<UnitOfMeasure>
    {
        private readonly IEnumerable<UnitOfMeasure> _unitOfMeasures
            = new List<UnitOfMeasure>()
            {
                new UnitOfMeasure()
                {
                    Name = "gramm",
                    Shortcut = "g",
                    LanguageCode = "hu-HU"
                },
                new UnitOfMeasure()
                {
                    Name = "darab",
                    Shortcut = "db",
                    LanguageCode = "hu-HU"
                },
                new UnitOfMeasure()
                {
                    Name = "kiskanál",
                    Shortcut = "kisk.",
                    LanguageCode = "hu-HU"
                },
                new UnitOfMeasure()
                {
                    Name = "csipet",
                    Shortcut = "cs",
                    LanguageCode = "hu-HU"
                },
                new UnitOfMeasure()
                {
                    Name = "deciliter",
                    Shortcut = "dl",
                    LanguageCode = "hu-HU"
                },
                new UnitOfMeasure()
                {
                    Name = "centiliter",
                    Shortcut = "cl",
                    LanguageCode = "hu-HU"
                },
                new UnitOfMeasure()
                {
                    Name = "milliliter",
                    Shortcut = "dl",
                    LanguageCode = "hu-HU"
                },
                new UnitOfMeasure()
                {
                    Name = "evőkanál",
                    Shortcut = "evők.",
                    LanguageCode = "hu-HU"
                },
                new UnitOfMeasure()
                {
                    Name = "teáskanál",
                    Shortcut = "teásk.",
                    LanguageCode = "hu-HU"
                },
            };

        public IEnumerable<UnitOfMeasure> GetAll()
        {
            return _unitOfMeasures;
        }
    }
}
