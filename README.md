# tesztapi

## base url
https://webapplication120230326124150.azurewebsites.net/

## Options
### /options/genders
method: GET
```json
[
  "man",
  "woman"
]
````

### /options/goals
method: GET
```json
[
  "weightGain",
  "weightLoss"
]
````

### /options/exclusionconditions
method: GET
```json
[
  "glutént tartalmaz",
  "tejet tartalmaz",
  "mogyoró tartalmú",
  "húst tartalmaz",
  "állati eredetüt tartalmaz",
  "diót tartalmaz",
  "epret tartalmaz",
  "szója tartalmaz",
  "mustár tartalmaz",
  "zeller tartalmaz",
  "szezámmag tartalmaz"
]
````

## Form Input
### /form/input
method: POST
```json
{
    "gender": "man",
    "age": 45,
    "heigth": 180,
    "weight": 75,
    "weeklyWorkout": {
        "hard": 3,
        "light": 3
    },
    "goal": "weightGain",
    "exclusionConditions": [
        "diót tartalmaz",
        "mustár tartalmaz"
    ]
}
```
