# tesztapi

## base url
https://webapplication120230326124150.azurewebsites.net

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
    "label": "Szárnyasok(csirke, pulyka)"
  },
  {
    "id": 5,
    "label": "Vörös húsok(marha, sertés)"
  },
  {
    "id": 6,
    "label": "Belsőségek(máj, aprólék)"
  },
  {
    "id": 7,
    "label": "Nem eszem húst"
  },
  {
    "id": 8,
    "label": "Édesvízi- és tengeri halfilék"
  },
  {
    "id": 9,
    "label": "Olajos tonhalak"
  },
  {
    "id": 10,
    "label": "Rák, kagyló"
  }
]
```

### /options/exclusiondontlike/sides
method: GET
```json
[
  {
    "id": 11,
    "label": "Burgonya, édesburgonya"
  },
  {
    "id": 12,
    "label": "Rizs, barnarizs"
  },
  {
    "id": 13,
    "label": "Köles"
  },
  {
    "id": 14,
    "label": "Quinoa"
  },
  {
    "id": 15,
    "label": "Bulgur"
  },
  {
    "id": 16,
    "label": "Tészta, durumtészta"
  },
  {
    "id": 17,
    "label": "Amaránt"
  },
  {
    "id": 18,
    "label": "Kuszkusz"
  }
]
````

### /options/exclusiondontlike/fruits
method: GET
```json
[
  {
    "id": 19,
    "label": "Alma"
  },
  {
    "id": 20,
    "label": "Körte"
  },
  {
    "id": 21,
    "label": "Banán"
  },
  {
    "id": 22,
    "label": "Erdei bogyós gyümölcsök(áfonya, málna, eper, szeder, ribizli)"
  },
  {
    "id": 23,
    "label": "Narancs"
  },
  {
    "id": 24,
    "label": "Mandarin"
  },
  {
    "id": 25,
    "label": "Ananász"
  },
  {
    "id": 26,
    "label": "Dinnye"
  },
  {
    "id": 27,
    "label": "Szőlő"
  },
  {
    "id": 28,
    "label": "Kivi"
  }
]
````


### /options/exclusiondontlike/vegetables
method: GET
```json
[
  {
    "id": 29,
    "label": "Paradicsom(hagyományos, koktél)"
  },
  {
    "id": 30,
    "label": "Paprika(zöld-, kalifornia-, kápia-,)"
  },
  {
    "id": 31,
    "label": "Uborka(kovászos-, csemege-, kígyó-,)"
  },
  {
    "id": 32,
    "label": "Retek(vaj-, hónapos-, fekete-, jég-,)"
  },
  {
    "id": 33,
    "label": "Tökfélék(cukkíni, padlizsán, sütőtök)"
  },
  {
    "id": 34,
    "label": "Sárgarépa"
  },
  {
    "id": 35,
    "label": "Brokkoli"
  },
  {
    "id": 36,
    "label": "Spenót"
  },
  {
    "id": 37,
    "label": "Avokádó"
  },
  {
    "id": 38,
    "label": "Saláták(jég-, madár-, radicchio-, rukkola-,)"
  }
]
````

### /options/exclusiondontlike/ingredients
method: GET
```json
[
  {
    "id": 39,
    "label": "Tej, növényi italok(szója-, mandula-, kókusz-, rizsital)"
  },
  {
    "id": 39,
    "label": "Tej, növényi italok(szója-, mandula-, kókusz-, rizsital)"
  },
  {
    "id": 40,
    "label": "Tojás"
  },
  {
    "id": 41,
    "label": "Joghurt(natúr, görög, zsírszegény)"
  },
  {
    "id": 42,
    "label": "Tejföl"
  },
  {
    "id": 43,
    "label": "Túró, Cottage cheese"
  },
  {
    "id": 44,
    "label": "Sajtfélék"
  },
  {
    "id": 45,
    "label": "Gombafélék"
  },
  {
    "id": 46,
    "label": "Hüvelyesek(bab, borsó, lencse)"
  },
  {
    "id": 47,
    "label": "Olajos magvak(mandula, kesudió, mogyoró)"
  },
  {
    "id": 48,
    "label": "Húspótlók(tofu, szejtán, tempeh)"
  }
]
````

## Form Input
### /form/input
method: POST
```json
{
    "gender": "Male",
    "age": 45,
    "heigth": 180,
    "weight": 75,
    "weeklyWorkout": {
        "hard": 3,
        "light": 3
    },
    "goal": "WeightGain",
    "exclusionConditions": [
        23, 2, 12
    ]
}

```
