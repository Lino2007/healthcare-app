
# healthcare-app
ASP.NET MVC core aplikacija za manju kliniku.

## Tehnologije korištene
- [ASP.NET MVC core (.NET 6)](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)
- Entity Framework core (code-first metoda)
- Bootstrap 5

## Instrukcije za postavku projekta lokalno
1. Instalirati [.NET 6 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)
2. Potreban MS-SQL server, preporučljivo koristiti [Docker MS-SQL image](https://hub.docker.com/_/microsoft-mssql-server). Sačuvajte konekcioni string koji budete koristili za pristup bazi.
3. Klonirati projekt i otvoriti sln u VS Studio
4. U VS Studio developer terminalu se pozicionirati na root projekta. Za postavku konekcionog stringa (iz koraka 2) u projektu za SQL bazu koristiti komande:

        dotnet user-secrets init

        dotnet user-secrets set "ConnectionStrings:HealthcareApp" "Data Source=localhost,1433;Initial Catalog=Healthcare;Password=VasPassword;User Id=SA;Encrypt=false;"
     
5. Pokrenuti komandu: dotnet ef database update

6. Pokrenuti projekt.

## Organizacija koda
Uz standardne direktorije MVC projekta, uvedeni su dodatni za organizaciju.

 - Migrations - auto-generirani Entity Framework kod za generiranje baze i popunjavanje inicijalnih podataka u bazi
 - Repository - klase koje enkapsuliraju database CRUD operacije. Generična implementacija CRUD operacija se nalazi u [CrudRepository klasi](./HealthcareApp/Repository/Implementation/CrudRepository.cs). A operacije koje su specifične za pojedine klase se nalaze u istoimenim \<ImeKlase\>Repository klasama.
 - Utils - različite pomoćne klase, atributi i exception klase
 - Unutar Model direktorija se nalaze *Data* klase u sklopu *DataModels* direktorija, dok se pomoćne view klase nalaze u *ViewModels* direktoriju.
 - wwwroot - su ubačene pomoćne javascript klase i css

Povezivanje repozitorij sloja sa kontrolerima realiziran je putem Dependency Injection sistema.



