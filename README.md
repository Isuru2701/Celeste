# Celeste

ASP.NET C#

## A journal app

Celeste is a prototype for a journal app that helps users keep track of their mental health.
Users make daily entries, as if it were a diary.
The writer's input is analyzed using some NPL techniques, and assigned a 'mood score'.
The API also tries to check if a the words used match any words associated with common illnesses such as depression, anxiety, etc.
Emphasis on *tries*. :)

You can find the API over [here](https://github.com/Isuru2701/API)

### before you run
- generate a local copy of the database by running scripts.sql 
- place your connection string to the database in App.config
- go get an youtube API key and plug it into APIkey variable in the APIHandler class in Model
