# Docker
Run application using docker:
```
docker-compose up --build
```

# Backend Setup (ASP.NET Core API)
### For Development:
Edit Booking.API/appsettings.Development.json: 
```
{
  "ConnectionStrings": {
    "PostgresDb": "Host=localhost;Port=5432;Database=BookingDb;Username=postgres;Password=your_password"
  }
}
```
### For Production:
Create Booking.API/appsettings.json:
```
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "PostgresDb": "Host=localhost;Port=5432;Database=BookingDb;Username=postgres;Password=your_password"
  }
}
```
### Run:
```
dotnet restore
dotnet run
```
The API will be available at https://localhost:7140

# Frontend Setup (Angular)

### Install dependencies:
```
npm install
```
### Configure the API endpoint:
Update file in src/environments/:
- environment.development.ts:
```
export const environment = {
  baseUrl: 'https://localhost:7140/api'
};
```
### Start the development server:
```
ng serve
```
The frontend will be available at http://localhost:4200
