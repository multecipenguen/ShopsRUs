ShopsRUs Retail Store Discounts
This project provides discounts to customers of ShopsRUs over web or mobile. It has sets of endpoints which are calculate discounts and crates invoices.

Start:
Clone project from https://github.com/multecipenguen/shopsrus.git
Run it on visual studio or goto project folder "ShopsRUs.Api" then build with "dotnet build" after dotnet run.
Go to http://localhost:5000/swagger for quick look.

After any change on db run you can run "add-migration" on Package Manager Console.

DB:Sqlite
Microsoft Entity Framework
Patterns:CQRS/Repository
Validation:Fluetn Validation
Mapper:AutoMapper
For Union Match (Result and NotFound or Error): OneOf Library

For Tests:
	FluentAssertions
	Moq
	XUnit

