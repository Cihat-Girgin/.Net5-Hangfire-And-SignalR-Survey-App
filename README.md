# .Net5 Hangfire and SignalR Survey Application

Application that show the survey results for backend frameworks to the user in real time.

![signal-r](https://user-images.githubusercontent.com/73026903/136753430-11efcd03-b72d-4278-9b78-5c8fc97b62ef.gif)

The hangfire job running in the API layer runs every minute and saves 60 random survey data to the database.(The survey table is reset when the number of records exceeds 200)
Via Signalr, the client presents the data live to the user.

# Installation

1-First for database connection edit the connectionstring field in the appsettings.json file in the api layer.

![coon](https://user-images.githubusercontent.com/73026903/136757358-9e2d7579-9167-4f3e-9a97-1c2d11fe9b17.png)  

2-Then run the following command in the package manager console to mirror the migrations to the database.
```sh
update-database
```
3-Run api and web project

4-Send a get request to the https://localhost:44310/api/survey endpoint to start the hangfire job.(You can also use swagger instead of postman)

![swagger](https://user-images.githubusercontent.com/73026903/136768079-a7efe36f-795d-4e46-bce6-852c5d50c200.png)


It's that simple!
