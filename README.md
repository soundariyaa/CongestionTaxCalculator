CongestionTaxCalculate

This project is developed using below tools and software libraries

Visual studio code
Azure Function API
C#
.Net 6.0
Postman

Dependencies:
.Net SDK:
Use below link for download and install .Net 6.0
https://dotnet.microsoft.com/en-us/download/dotnet/6.0

VS code Extensions:
C# Extensions
Azure Tools
Nuget package manager

PostMan:
Install the Postman desktop client, follow this link to install - https://www.postman.com/downloads/

City Tax rates:
TaxRates,TollFreeDates, and Exempt vehicle details of Gothenburg city is stores in a .json in this fpath "CongestionTaxCalculator\Files".

How to run?
1. Open the project in VS code
2. Pre install the extension and .Net SDK mentioned above in dependencies section
3. Press F5 to run the project, build and run will be executed
4. Open Postman client and load the Postman collection located in this path "CongestionTaxCalculator\Test"
5. Execute the test collection from Postman, the response will be visulized in PostMan

Improvements needed:
1.FluentValidation installed but not done validations
2.Exceptions need to handled
3.Use database to store City tax datails and create post method to instert city datails and call get method to fetch tax details by city.
4.Unit test(Nunit) has be added to test fake data
5.Create web api and follow clean architecture Instead of function API 


