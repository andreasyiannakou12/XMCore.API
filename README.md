Project Name: XMCore.API
Description: The purpose of this API is to save fetch and delete bitcoin prices from different sources. 
Installation and running the project: It contains six endpoints and it requires authentication to access them. Authentication can be obtained by calling the "Login" endpoint using postman. While calling the endpoint from postman, you should select "Body" and then "Raw". Furthermore, in the dropdown next to it select "JSON" and add the following line in the raw body "{"Username": "TestUser", "Password": "TestPa$$"}". This is the test dummy user that exists in the core code for temporary testing. This will allow the API to send back a token that expires every 15 minutes. This token should be appended on each API call made, since all the endpoints need authentication. To add the token to the request you should go to the tab "Authorization" select "Bearer token" and paste the token to the input field. Before running the project, you should open appsettings.json and change the Jwt.Issuer and Jwt.Audience parameters to your own local ones (most probably change the port only to the one your IIS express uses to run the application). Finally the database needs to be generated with the models of the project. You should access the "Migrations" folder and delete and the .cs files but not the child folders.


Run the following commands using Package Manager Console for database generation after providing a valid "DefaultConnection" string on appsettings.json:
Add-Migration InitialCreate -Context PriceDataDbContext -o Migrations/PriceDataDb
Add-Migration InitialCreate -Context PriceSourceDbContext -o Migrations/PriceSourceDb
Add-Migration InitialCreate -Context UserDbContext -o Migrations/UserDb

Update-Database -Context PriceSourceDbContext
Update-Database -Context PriceDataDbContext
Update-Database -Context UserDbContext

