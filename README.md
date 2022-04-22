# HesabuPOS
HesabuPOS aims to be an all-in-one POS.

Tech-Stack:
- C# / HTML (& cshtml)
- ASP.NET CORE
- .NET 6.0
- MongoDB
- SwaggerUI
- Backend Server
- Webinterface (included in the backend, for easy data import and more information)

Requirements:
- .NET Framework 6.0 Runtime
- Local MongoDB: https://www.mongodb.com/try/download/community

IN DEVELOPMENT, IN DEVELOPMENT, IN DEVELOPMENT, IN DEVELOPMENT, IN DEVELOPMENT, IN DEVELOPMENT, IN DEVELOPMENT, IN DEVELOPMENT, IN DEVELOPMENT, IN DEVELOPMENT

Current Features:
- Backend Server can [Get] and [Post] Product Data
- Webinterface created, has a link to swagger for testing
- Webinterface can list all current products inside the mongoDB

What I am working on:
- Backend Controller to use for ProductsData
- Keep MongoDB Clean
- Installer Application that sets up the mongoDB
- Application to test Backend Endpoints (HesabuPOS-Storefront)

Stuff thats needed in the future:
- authentication
- gateway service that routes the requests
- un-coupled controllers (controller should live in its own project, and only get loaded by the aspnet service upon start)
- (aspnet service should not have ANY controllers inside)
- security measures (not allowing anyone to make requests, and MUCH more)

Workflow:
- Install local mongoDB instance
- Run the HesabuPOS-Installer once

This will create the needed database with dummy data inside the needed collections
- Run HesabuPOS-Webinterface

This acts as the backend-Server and enables the user to access Data without any hassle

