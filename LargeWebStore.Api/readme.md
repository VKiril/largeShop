Run Migrations

cd .\LargeWebStore.DWH.Api
dotnet ef -s .\LargeWebStore.DWH.Api.csproj -p ..\LargeWebStore.Common migrations add UpdateProduct
dotnet ef -s .\LargeWebStore.DWH.Api.csproj -p ..\LargeWebStore.Common database update 
dotnet ef --startup-project ..\SeleniumBot migrations script


[OR]


dotnet ef --startup-project .\SeleniumBot --project .\Entities migrations add ProjectScafolding
dotnet ef --startup-project .\SeleniumBot --project .\Entities database update
dotnet ef --startup-project .\SeleniumBot --project .\Entities migrations script




PM> dotnet ef -s .\LargeWebStore.DWH.Api.csproj -p ..\LargeWebStore.Common migrations add AddedProductInfra


http://localhost:4000/admin/
kiril.vasilita@mail.ru
test

http://localhost:4000/
test@test.test
test
