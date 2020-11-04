Run Migrations

cd .\Entities
dotnet ef --startup-project ..\SeleniumBot migrations add ProjectScafolding
dotnet ef --startup-project ..\SeleniumBot database update
dotnet ef --startup-project ..\SeleniumBot migrations script


[OR]


dotnet ef --startup-project .\SeleniumBot --project .\Entities migrations add ProjectScafolding
dotnet ef --startup-project .\SeleniumBot --project .\Entities database update
dotnet ef --startup-project .\SeleniumBot --project .\Entities migrations script




PM> dotnet ef -s .\LargeWebStore.DWH.Api.csproj -p ..\LargeWebStore.Common migrations add AddedProductInfra

