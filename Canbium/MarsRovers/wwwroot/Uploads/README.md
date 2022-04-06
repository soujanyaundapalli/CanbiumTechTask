**Vodafone Coding Exercise**

Pre-reqs: .NET Core 3.1, IDE of choice (Visual Studio, Visual Studio Code etc)

To run the code see below. You can of course also build and run the example in Visual Studio.

1. Update appsettings.json with full path for local Sqlite file
1. Build the code base "dotnet build"
1. Install EntityFrameworkCore: "dotnet tool install --global dotnet-ef --version 3.1.21"
1. Run EntityFrameworkCore Code First: "dotnet ef --startup-project Vodafone.Device.API --project Vodafone.Device.Data migrations add InitialCreate"
1. And then: "dotnet ef --startup-project Vodafone.Device.API --project Vodafone.Device.Data database update"
1. To run the tests use: "dotnet test"
1. Run the application using "dotnet run --project Vodafone.Device.API"

Once the API is running, it can be consumed:

`GET localhost:5000/device/v1/devices/1` - to get a specific device

`POST localhost:5000/device/v1/devices` - POST to add a new device to embedded DB.

All tests will be executed as part of build but can also be run independently if need be.

**Tasks:**

You will be provided the tasks at the start of the interview.