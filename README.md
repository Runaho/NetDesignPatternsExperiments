# Project Details for .NET Design Patterns Experiments `NDPE`
---------------------------------------------------------
Greetings! In this repo, we will be testing various .NET Core web design patterns to evaluate their pros and cons. For our experiment, we will create a ToDo project.

Our aim is to test a project that connects to a database with a simple ORM and performs CRUD operations using different web design patterns. We want to find out which pattern is best suited for a particular project size and how easily we can achieve our goals using that pattern.

### Purpose of This Experiment

This experiment has been developed to find out what can be done in each design pattern with minimal effort while developing projects. We aim to evaluate the development process and workload of each pattern and conclude which pattern supports the fastest and easiest method for performing CRUD operations.

Our main objective is to create a project that allows us to add, remove, and update ToDo items in the fastest and simplest way possible. We prefer to perform all these tasks on a single page to simplify the user experience.

### Technologies and Frameworks Used in This Experiment

*   [ASP.NET Core](https://dotnet.microsoft.com/apps/aspnet)
*   [Razor Pages Page Model](https://docs.microsoft.com/en-us/aspnet/core/razor-pages/?view=aspnetcore-6.0&tabs=visual-studio#page-models)
*   [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/)
*   [Bootstrap .NET Starter Layouts](https://getbootstrap.com/docs/4.0/getting-started/introduction/)
*   [Minimal API](https://docs.microsoft.com/en-us/aspnet/core/web-api/minimal-apis?view=aspnetcore-6.0)
*   [In-Memory Database Provider](https://docs.microsoft.com/en-us/ef/core/providers/in-memory/?tabs=dotnet-core-cli)

### Project Setup

Our project will use a simple ToDo model with in-memory Entity Framework Core. We will also use a shared project to reduce code repetition and shorten the development process. The shared project will include the web service request methods and the database.

For the Web API, we will be using the Minimal API design pattern with the following endpoints:

*   GET /todoitems
*   POST /todoitems
*   GET /todoitems/complete
*   PUT /todoitems/{id}
*   DELETE /todoitems/{id}

![API](https://user-images.githubusercontent.com/16222645/228525507-9d721bed-5c52-41da-8ab4-066312f40a7c.png)


### Conclusion

[You can access the blog post series from this link;](http://blog.guneskorkmaz.net/series/net-web-design-patterns/) 
