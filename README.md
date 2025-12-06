CoureBe Practical Test – Country Lookup API
Author: Ifeanyi Okeke
Project Type: .NET 8, Clean Architecture, Unit of Work, Repository Pattern
Project Overview
This project implements a practical test in two parts:
1. Score Calculator – Calculates a total score based on integers in an array.
2. Country Lookup API – Returns country and operator details for a given phone number.

The project follows Clean Architecture principles:
- Core: Entities and Interfaces
- Application/Services: Business logic (CountryLookupService)
- Infrastructure: EF Core, Generic Repositories, Unit of Work
- API: Controllers with endpoints
- Tests: xUnit tests for services and API
Question 1 — Score Calculator
Rules
Condition	Points
Even number	+1
Odd number	+3
Number = 8	+5 (additional)
Implementation
Utilities/ScoreCalculator.cs
```csharp
namespace CoureBeTest.Utilities
{
    public static class ScoreCalculator
    {
        public static int CalculateScore(int[] numbers)
        {
            int score = 0;
            foreach (var n in numbers)
            {
                if (n % 2 == 0) score += 1;
                else score += 3;
                if (n == 8) score += 5;
            }
            return score;
        }
    }
}
```
Example Inputs and Outputs
Input	Output
[1,2,3,4,5]	11
[15,25,35]	9
[8,8]	12
Question 2 — Country Lookup API
Endpoint
GET /api/CountryLookup/{phoneNumber}
Description
Returns country and operator details for the given phone number. The first 3 digits are used to detect the country code.
Example Request
GET https://localhost:7060/api/CountryLookup/2348069323233
Sample Response (200 OK)
```json
{
  "number": "2348069323233",
  "country": {
    "countryCode": "234",
    "name": "Nigeria",
    "countryIso": "NG",
    "countryDetails": [
      { "operator": "MTN Nigeria", "operatorCode": "MTN NG" },
      { "operator": "Airtel Nigeria", "operatorCode": "ANG" },
      { "operator": "9 Mobile Nigeria", "operatorCode": "ETN" },
      { "operator": "Globacom Nigeria", "operatorCode": "GLO NG" }
    ]
  }
}
```
Example Error Responses
Status	Description	Example Response
404	Country code not recognized	{ "message": "Country code not recognized." }
400	Invalid phone number format	{ "message": "Invalid phone number format" }
500	Internal server error	{ "message": "An unexpected error occurred" }

How to Run the Project
1.Clone the repository from my profile 
2.Restore dependencies:
   dotnet restore
2. Run the API:
   dotnet run
3. Access Swagger or Postman at:
   https://localhost:7060/swagger
How to Run Tests
dotnet test
All tests should pass (Score Calculator + Country Lookup Service + Controller tests).
Dependency Injection Setup
```csharp
services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
services.AddScoped<IUnitOfWork, UnitOfWork>();
services.AddScoped<ICountryLookupService, CountryLookupService>();
```
Notes
- Built with .NET 8, Clean Architecture, EF Core, Unit of Work, Repository Pattern.
- Fully tested using xUnit and Moq.
- The first 3 digits of a phone number determine the country code.
- Operator details are preloaded using Include() in EF Core.
- Future API versioning can be supported using /api/v1/CountryLookup/{phoneNumber}.