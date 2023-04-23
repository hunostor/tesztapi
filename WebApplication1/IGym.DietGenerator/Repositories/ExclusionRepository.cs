using IGym.DietGenerator.Models;
using IGym.DietGenerator.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace IGym.DietGenerator.Repositories
{
    public class ExclusionRepository : Interfaces.IRepository<ExclusionCondition>
    {
        private IEnumerable<ExclusionCondition> _list = new List<ExclusionCondition>()
        {
            new ExclusionCondition()
            {
                Id = 1,
                Name = "Laktóz allergia",
                Description = "",
                Type = Enums.ExclusionConditionTypes.allergies
            },
            new ExclusionCondition()
            {
                Id = 2,
                Name = "Gluténmentes",
                Description = "",
                Type = Enums.ExclusionConditionTypes.allergies
            },
            new ExclusionCondition()
            {
                Id = 3,
                Name = "Tojásallergia",
                Description = "",
                Type = Enums.ExclusionConditionTypes.allergies
            },
            new ExclusionCondition()
            {
                Id = 4,
                Name = "Húsmentes",
                Description = "",
                Type = Enums.ExclusionConditionTypes.component
            },
            new ExclusionCondition()
            {
                Id = 5,
                Name = "Tejtermék mentes",
                Description = "",
                Type = Enums.ExclusionConditionTypes.component
            },
            new ExclusionCondition()
            {
                Id = 6,
                Name = "Mogyoró allergia",
                Description = "",
                Type = Enums.ExclusionConditionTypes.allergies
            },
            new ExclusionCondition()
            {
                Id = 7,
                Name = "Zellert tartalmaz",
                Description = "",
                Type = Enums.ExclusionConditionTypes.component
            },
        };

        public IEnumerable<ExclusionCondition> GetAll()
        {
            return _list;
        }
    }
}
