# Cosmos .NET API

## Welcome to Cosmos .NET API project! 
This API is created for the .NET developers who would like to integrate with Cosmos blockchain. It allows interaction with the Cosmos blockchain node as a client through the RPC interface. For more details, see the [API documentation](docs/index.md)

This is a fork of the orginal Cosmos .NET API project that's already 3 years old. Most if not all of the API endpoints have changed and removed. This project will be an updated version using updated packages and using the current Cosmos SDK. I've also based it on the Chain that is scaffolded by Ignite CLI - https://github.com/ignite/cli

I've added a little console app project so you can check out how the API works. You can easily spin your own Cosmos blockchain by using Ignite CLI mentioned above. Rummage through the instructions and you can start using the .NET API after the "ignite chain serve" command. It should run your "http://localhost:1317" and you're ready to use the API by compiling the Console app (Set it as the startup project). I haven't fixed the Unit Tests yet, I'm still working fixing the API's methods. The console app pretty much has all the endpoints I've added and fixed.

I will continue to update this project as time allows. You're welcome to contribute as well.
