# Coding Assesment

Backend API Rest (.Net 6) + Front End (Angular) coding assesment for HealthEquity.
The SQL challenge is in a .sql file inside the "SQLChallenge" folder.

# Stack

Backend: .Net 6 + xUnit for Unit Testing examples.
FrontEnd: Angular 15.

## How to execute

First execute from Visual Studio 2022 the backend. Please run it using the integrated WebServer and not IISExpress.

After having the backend server running, the front-end built in Angular can now be executed.
To do this, first install the dependencies with the "npm i" command and then use the "ng serve" command to run the front-end.

## How to test

The angular front-end is intuitive, and allows you to guess the price of a car. If you are within 5,000 of the guess, displays a great job message in green. The list of cars and their data are retrieved with an HTTP call to the backend server built on .Net 6

The backend exposes five endpoints, which can do the basic CRUD operations on the car list. These endpoints are documented in swagger, which automatically opens in a browser window when you run the project.
Anyway, just in case, there is a postman collection in the repo to test the backend endpoints. The collection is inside the "Postman" folder.

## Unit Testing

In the backend project, 2 unit tests were included as an example, they were written using the xUnit framework and the FakeItEasy and FluentAssertions libraries.