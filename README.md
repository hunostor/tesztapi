# tesztapi

## base url
https://webapplication120230326124150.azurewebsites.net

## Options
### /options/days
method: GET
```json
[
  {
    "id": 1,
    "label": "Hétfő"
  },
  {
    "id": 2,
    "label": "Kedd"
  },
  {
    "id": 3,
    "label": "Szerda"
  },
  {
    "id": 4,
    "label": "Csütörtök"
  },
  {
    "id": 5,
    "label": "Péntek"
  },
  {
    "id": 6,
    "label": "Szombat"
  },
  {
    "id": 7,
    "label": "Vasárnap"
  }
]
````

## Options
### /options/trainingdurations
method: GET
```json
[
  {
    "id": 1,
    "label": "20-35 perc"
  },
  {
    "id": 2,
    "label": "40-60 perc"
  },
  {
    "id": 3,
    "label": "60+ perc"
  }
]
````

## Options
### /options/trainers
method: GET
```json
[
  {
    "id": 0,
    "label": "None"
  },
  {
    "id": 1,
    "label": "Trainer 1"
  },
  {
    "id": 2,
    "label": "Trainer 2"
  },
  {
    "id": 3,
    "label": "Trainer 3"
  },
  {
    "id": 4,
    "label": "Trainer 4"
  },
  {
    "id": 5,
    "label": "Trainer 5"
  }
]
````

## Options
### /options/genders
method: GET
```json
[
  {
    "id": 1,
    "label": "Male"
  },
  {
    "id": 2,
    "label": "Female"
  }
]
````

### /options/goals
method: GET
```json
[
  {
    "id": 1,
    "label": "WeightGain"
  },
  {
    "id": 2,
    "label": "WeightLoss"
  }
]
````

### /options/exclusionintolerance
method: GET
```json
[
  {
    "id": 1,
    "label": "Gluténérzékeny vagyok"
  },
  {
    "id": 2,
    "label": "Laktózérzékeny vagyok"
  }
]
````

### /options/exclusiondontlike/foods
method: GET
```json
[
  {
    "id": 3,
    "label": "Szárnyasok(csirke, pulyka)"
  },
  {
    "id": 4,
    "label": "Vörös húsok(marha, sertés)"
  },
  {
    "id": 5,
    "label": "Belsőségek(máj, aprólék)"
  },
  {
    "id": 6,
    "label": "Nem eszem húst"
  },
  {
    "id": 7,
    "label": "Édesvízi- és tengeri halfilék"
  },
  {
    "id": 8,
    "label": "Olajos tonhalak"
  },
  {
    "id": 9,
    "label": "Rák, kagyló"
  }
]
```

### /options/exclusiondontlike/sides
method: GET
```json
[
  {
    "id": 10,
    "label": "Burgonya, édesburgonya"
  },
  {
    "id": 11,
    "label": "Rizs, barnarizs"
  },
  {
    "id": 12,
    "label": "Köles"
  },
  {
    "id": 13,
    "label": "Quinoa"
  },
  {
    "id": 14,
    "label": "Bulgur"
  },
  {
    "id": 15,
    "label": "Tészta, durumtészta"
  },
  {
    "id": 16,
    "label": "Amaránt"
  },
  {
    "id": 17,
    "label": "Kuszkusz"
  }
]
````

### /options/exclusiondontlike/fruits
method: GET
```json
[
  {
    "id": 18,
    "label": "Alma"
  },
  {
    "id": 19,
    "label": "Körte"
  },
  {
    "id": 20,
    "label": "Banán"
  },
  {
    "id": 21,
    "label": "Erdei bogyós gyümölcsök(áfonya, málna, eper, szeder, ribizli)"
  },
  {
    "id": 22,
    "label": "Narancs"
  },
  {
    "id": 23,
    "label": "Mandarin"
  },
  {
    "id": 24,
    "label": "Ananász"
  },
  {
    "id": 25,
    "label": "Dinnye"
  },
  {
    "id": 26,
    "label": "Szőlő"
  },
  {
    "id": 27,
    "label": "Kivi"
  }
]
````


### /options/exclusiondontlike/vegetables
method: GET
```json
[
  
    "id": 28,
    "label": "Paradicsom(hagyományos, koktél)"
  },
  {
    "id": 29,
    "label": "Paprika(zöld-, kalifornia-, kápia-,)"
  },
  {
    "id": 30,
    "label": "Uborka(kovászos-, csemege-, kígyó-,)"
  },
  {
    "id": 31,
    "label": "Retek(vaj-, hónapos-, fekete-, jég-,)"
  },
  {
    "id": 32,
    "label": "Tökfélék(cukkíni, padlizsán, sütőtök)"
  },
  {
    "id": 33,
    "label": "Sárgarépa"
  },
  {
    "id": 34,
    "label": "Brokkoli"
  },
  {
    "id": 35,
    "label": "Spenót"
  },
  {
    "id": 36,
    "label": "Avokádó"
  },
  {
    "id": 37,
    "label": "Saláták(jég-, madár-, radicchio-, rukkola-,)"
  }
]
````

### /options/exclusiondontlike/ingredients
method: GET
```json
[
  {
    "id": 38,
    "label": "Tej, növényi italok(szója-, mandula-, kókusz-, rizsital)"
  },
  {
    "id": 39,
    "label": "Tojás"
  },
  {
    "id": 40,
    "label": "Joghurt(natúr, görög, zsírszegény)"
  },
  {
    "id": 41,
    "label": "Tejföl"
  },
  {
    "id": 42,
    "label": "Túró, Cottage cheese"
  },
  {
    "id": 43,
    "label": "Sajtfélék"
  },
  {
    "id": 44,
    "label": "Gombafélék"
  },
  {
    "id": 45,
    "label": "Hüvelyesek(bab, borsó, lencse)"
  },
  {
    "id": 46,
    "label": "Olajos magvak(mandula, kesudió, mogyoró)"
  },
  {
    "id": 47,
    "label": "Húspótlók(tofu, szejtán, tempeh)"
  }
]
````

## Form Input
### /form/input
method: POST
```json
{
    "userId": "dfgdgd4534", // random
    "gender": 1, // 0 = Female, 1 = Male
    "age": 45,
    "heigth": 180,
    "weight": 75,
    "weeklyWorkout": {
        "hard": 3,
        "light": 3
    },
    "goal": 2,
    "exclusionConditions": [
        1, 2, 3, 4, 5
    ],
    "startday": {
        "year": 2023,
        "month": 6,
        "day": 30
    },
    "preferredTrainingDuration": 2,
    "trainers": [
      3, 5
    ],
    "availableDays": [
      1, 5, 6
    ]
}

```
