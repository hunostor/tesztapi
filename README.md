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

### /options/exclusionconditions
method: GET
```json
[
  {
    "id": 1,
    "label": "Laktóz allergia"
  },
  {
    "id": 2,
    "label": "Gluténmentes"
  },
  {
    "id": 3,
    "label": "Tojásallergia"
  },
  {
    "id": 4,
    "label": "Húsmentes"
  },
  {
    "id": 5,
    "label": "Tejtermék mentes"
  },
  {
    "id": 6,
    "label": "Mogyoró allergia"
  },
  {
    "id": 7,
    "label": "Zellert tartalmaz"
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
        "diót tartalmaz",
        "mustár tartalmaz"
    ]
}

```
