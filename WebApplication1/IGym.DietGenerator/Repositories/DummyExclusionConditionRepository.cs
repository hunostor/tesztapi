using IGym.DietGenerator.Models;
using IGym.DietGenerator.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace IGym.DietGenerator.Repositories
{
    public class DummyExclusionConditionRepository : Interfaces.IRepository<ExclusionCondition>
    {
        private IEnumerable<ExclusionCondition> _list = new List<ExclusionCondition>()
        {
            new ExclusionCondition()
            {
                Id = 1,
                Label = "Gluténérzékeny vagyok",
                Tag = "Glutén",
                Description = "",
                Type = Enums.ExclusionConditionTypes.intolerance_or_food_allergy
            },
            new ExclusionCondition()
            {
                Id = 2,
                Label = "Laktózérzékeny vagyok",
                Tag = "Laktóz",
                Description = "",
                Type = Enums.ExclusionConditionTypes.intolerance_or_food_allergy
            },
            new ExclusionCondition()
            {
                Id = 3,
                Label = "Szárnyasok(csirke, pulyka)",
                Tag = "Szárnyasok",
                Description = "",
                Type = Enums.ExclusionConditionTypes.meat_and_fish
            },
            new ExclusionCondition()
            {
                Id = 4,
                Label = "Vörös húsok(marha, sertés)",
                Tag = "Vörös húsok",
                Description = "",
                Type = Enums.ExclusionConditionTypes.meat_and_fish
            },
            new ExclusionCondition()
            {
                Id = 5,
                Label = "Belsőségek(máj, aprólék)",
                Tag = "Belsőségek",
                Description = "",
                Type = Enums.ExclusionConditionTypes.meat_and_fish
            },
            new ExclusionCondition()
            {
                Id = 6,
                Label = "Nem eszem húst",
                Tag = "Hústartalom",
                Description = "",
                Type = Enums.ExclusionConditionTypes.meat_and_fish
            },
            new ExclusionCondition()
            {
                Id = 7,
                Label = "Édesvízi- és tengeri halfilék",
                Tag = "Haltartalom",
                Description = "",
                Type = Enums.ExclusionConditionTypes.meat_and_fish
            },
            new ExclusionCondition()
            {
                Id = 8,
                Label = "Olajos tonhalak",
                Tag = "Olajos tonhalak",
                Description = "",
                Type = Enums.ExclusionConditionTypes.meat_and_fish
            },
            new ExclusionCondition()
            {
                Id = 9,
                Label = "Rák, kagyló",
                Tag = "Rák, kagyló",
                Description = "",
                Type = Enums.ExclusionConditionTypes.meat_and_fish
            },
            new ExclusionCondition()
            {
                Id = 10,
                Label = "Burgonya, édesburgonya",
                Tag = "Burgonya, édesburgonya",
                Description = "",
                Type = Enums.ExclusionConditionTypes.side_dish
            },
            new ExclusionCondition()
            {
                Id = 11,
                Label = "Rizs, barnarizs",
                Tag = "Rizs, barnarizs",
                Description = "",
                Type = Enums.ExclusionConditionTypes.side_dish
            },
            new ExclusionCondition()
            {
                Id = 12,
                Label = "Köles",
                Tag = "Köles",
                Description = "",
                Type = Enums.ExclusionConditionTypes.side_dish
            },
            new ExclusionCondition()
            {
                Id = 13,
                Label = "Quinoa",
                Tag = "Quinoa",
                Description = "",
                Type = Enums.ExclusionConditionTypes.side_dish
            },
            new ExclusionCondition()
            {
                Id = 14,
                Label = "Bulgur",
                Tag = "Bulgur",
                Description = "",
                Type = Enums.ExclusionConditionTypes.side_dish
            },
            new ExclusionCondition()
            {
                Id = 15,
                Label = "Tészta, durumtészta",
                Tag = "Tészta, durumtészta",
                Description = "",
                Type = Enums.ExclusionConditionTypes.side_dish
            },
            new ExclusionCondition()
            {
                Id = 16,
                Label = "Amaránt",
                Tag = "Amaránt",
                Description = "",
                Type = Enums.ExclusionConditionTypes.side_dish
            },
            new ExclusionCondition()
            {
                Id = 17,
                Label = "Kuszkusz",
                Tag = "Kuszkusz",
                Description = "",
                Type = Enums.ExclusionConditionTypes.side_dish
            },
            new ExclusionCondition()
            {
                Id = 18,
                Label = "Alma",
                Tag = "Alma",
                Description = "",
                Type = Enums.ExclusionConditionTypes.fruit
            },
            new ExclusionCondition()
            {
                Id = 19,
                Label = "Körte",
                Tag = "Körte",
                Description = "",
                Type = Enums.ExclusionConditionTypes.fruit
            },
            new ExclusionCondition()
            {
                Id = 20,
                Label = "Banán",
                Tag = "Banán",
                Description = "",
                Type = Enums.ExclusionConditionTypes.fruit
            },
            new ExclusionCondition()
            {
                Id = 21,
                Label = "Erdei bogyós gyümölcsök(áfonya, málna, eper, szeder, ribizli)",
                Tag = "Erdei bogyós gyümölcsök",
                Description = "",
                Type = Enums.ExclusionConditionTypes.fruit
            },
            new ExclusionCondition()
            {
                Id = 22,
                Label = "Narancs",
                Tag = "Narancs",
                Description = "",
                Type = Enums.ExclusionConditionTypes.fruit
            },
            new ExclusionCondition()
            {
                Id = 23,
                Label = "Mandarin",
                Tag = "Mandarin",
                Description = "",
                Type = Enums.ExclusionConditionTypes.fruit
            },
            new ExclusionCondition()
            {
                Id = 24,
                Label = "Ananász",
                Tag = "Ananász",
                Description = "",
                Type = Enums.ExclusionConditionTypes.fruit
            },
            new ExclusionCondition()
            {
                Id = 25,
                Label = "Dinnye",
                Tag = "Dinnye",
                Description = "",
                Type = Enums.ExclusionConditionTypes.fruit
            },
            new ExclusionCondition()
            {
                Id = 26,
                Label = "Szőlő",
                Tag = "Szőlő",
                Description = "",
                Type = Enums.ExclusionConditionTypes.fruit
            },
            new ExclusionCondition()
            {
                Id = 27,
                Label = "Kivi",
                Tag = "Kivi",
                Description = "",
                Type = Enums.ExclusionConditionTypes.fruit
            },
            new ExclusionCondition()
            {
                Id = 28,
                Label = "Paradicsom(hagyományos, koktél)",
                Tag = "Paradicsom",
                Description = "",
                Type = Enums.ExclusionConditionTypes.vegetable
            },
            new ExclusionCondition()
            {
                Id = 29,
                Label = "Paprika(zöld-, kalifornia-, kápia-,)",
                Tag = "Paprika",
                Description = "",
                Type = Enums.ExclusionConditionTypes.vegetable
            },
            new ExclusionCondition()
            {
                Id = 30,
                Label = "Uborka(kovászos-, csemege-, kígyó-,)",
                Tag = "Uborka",
                Description = "",
                Type = Enums.ExclusionConditionTypes.vegetable
            },
            new ExclusionCondition()
            {
                Id = 31,
                Label = "Retek(vaj-, hónapos-, fekete-, jég-,)",
                Tag = "Retek",
                Description = "",
                Type = Enums.ExclusionConditionTypes.vegetable
            },
            new ExclusionCondition()
            {
                Id = 32,
                Label = "Tökfélék(cukkíni, padlizsán, sütőtök)",
                Tag = "Tökfélék(cukkíni, padlizsán, sütőtök)",
                Description = "",
                Type = Enums.ExclusionConditionTypes.vegetable
            },
            new ExclusionCondition()
            {
                Id = 33,
                Label = "Sárgarépa",
                Tag = "Sárgarépa",
                Description = "",
                Type = Enums.ExclusionConditionTypes.vegetable
            },
            new ExclusionCondition()
            {
                Id = 34,
                Label = "Brokkoli",
                Tag = "Brokkoli",
                Description = "",
                Type = Enums.ExclusionConditionTypes.vegetable
            },
            new ExclusionCondition()
            {
                Id = 35,
                Label = "Spenót",
                Tag = "Spenót",
                Description = "",
                Type = Enums.ExclusionConditionTypes.vegetable
            },
            new ExclusionCondition()
            {
                Id = 36,
                Label = "Avokádó",
                Tag = "Avokádó",
                Description = "",
                Type = Enums.ExclusionConditionTypes.vegetable
            },
            new ExclusionCondition()
            {
                Id = 37,
                Label = "Saláták(jég-, madár-, radicchio-, rukkola-,)",
                Tag = "Saláta",
                Description = "",
                Type = Enums.ExclusionConditionTypes.vegetable
            },
            new ExclusionCondition()
            {
                Id = 38,
                Label = "Tej, növényi italok(szója-, mandula-, kókusz-, rizsital)",
                Tag = "Tej, növényi italok",
                Description = "",
                Type = Enums.ExclusionConditionTypes.food_stuff
            },
            new ExclusionCondition()
            {
                Id = 39,
                Label = "Tojás",
                Tag = "Tojás",
                Description = "",
                Type = Enums.ExclusionConditionTypes.food_stuff
            },
            new ExclusionCondition()
            {
                Id = 40,
                Label = "Joghurt(natúr, görög, zsírszegény)",
                Tag = "Joghurt",
                Description = "",
                Type = Enums.ExclusionConditionTypes.food_stuff
            },
            new ExclusionCondition()
            {
                Id = 41,
                Label = "Tejföl",
                Tag = "Tejföl",
                Description = "",
                Type = Enums.ExclusionConditionTypes.food_stuff
            },
            new ExclusionCondition()
            {
                Id = 42,
                Label = "Túró, Cottage cheese",
                Tag = "Túró, Cottage cheese",
                Description = "",
                Type = Enums.ExclusionConditionTypes.food_stuff
            },
            new ExclusionCondition()
            {
                Id = 43,
                Label = "Sajtfélék",
                Tag = "Sajtfélék",
                Description = "",
                Type = Enums.ExclusionConditionTypes.food_stuff
            },
            new ExclusionCondition()
            {
                Id = 44,
                Label = "Gombafélék",
                Tag = "Gombafélék",
                Description = "",
                Type = Enums.ExclusionConditionTypes.food_stuff
            },
            new ExclusionCondition()
            {
                Id = 45,
                Label = "Hüvelyesek(bab, borsó, lencse)",
                Tag = "Hüvelyesek",
                Description = "",
                Type = Enums.ExclusionConditionTypes.food_stuff
            },
            new ExclusionCondition()
            {
                Id = 46,
                Label = "Olajos magvak(mandula, kesudió, mogyoró)",
                Tag = "Olajos magvak",
                Description = "",
                Type = Enums.ExclusionConditionTypes.food_stuff
            },
            new ExclusionCondition()
            {
                Id = 47,
                Label = "Húspótlók(tofu, szejtán, tempeh)",
                Tag = "Húspótlók",
                Description = "",
                Type = Enums.ExclusionConditionTypes.food_stuff
            },
        };

        public IEnumerable<ExclusionCondition> GetAll()
        {
            return _list;
        }
    }
}
