
## Razor Pages Page Model  `NDPE`
In this experiment, we will create a todo project with the Razor Pages Page Model Design pattern and explore its advantages and disadvantages. The Razor Pages Page Model is a design pattern for developing web applications using the .NET framework.

If you started directly with this post, I strongly recommend you to read the first post.

[Testing .NET Core Web Design Patterns Details](https://blog.guneskorkmaz.net/experiments/net-web-design-patterns-project-setup/)

[Razor Pages](https://learn.microsoft.com/en-us/aspnet/core/razor-pages/?view=aspnetcore-7.0&tabs=visual-studio) is a popular web design pattern in .NET development, offering an easy-to-understand structure for building web applications.

Our first example is /todos/index, which demonstrates how to perform CRUD operations on a single page. This example is accessible from the main menu and is a great starting point for beginners.

Our second example, /todo, uses AJAX to perform the same CRUD operations. While this is a commonly used method in Razor and MVC, it does have some drawbacks. Interacting inside the page using forms can cause serious problems when trying to do everything on a single page. For example, finding the value of a checkbox in the list and reversing it instead of accessing it directly can create issues that are unacceptable when developing a complete product.

To avoid such problems, recommend the third example: the Model/Action pattern suggested by Microsoft. This pattern requires creating a separate cshtml for your model, your page, and for each operation. For instance, todo/add.cshtml, todo/update.cshtml, todo/remove.cshtml, todo/index.cshtml, and todo/list.cshtml. While this approach may not have a reactive structure, it is a more solid structure recommended in Razor Pages and MVC.

It is worth noting that using Razor Pages without controllers can have its advantages and disadvantages. While it offers a simple and intuitive structure, there are limitations to what can be accomplished on a single page. In addition, refreshing the page can result in the method name appearing directly in the URL.
Sure, here's an edited version of the section:

### Pros and Cons of the Tested Methods

#### 1. Creating a Structure Using Multiple Forms Inside a Page
![Todos Example](https://blog.guneskorkmaz.net/blogposts/experiments/ndpe-1/Todos.webp)
Pros:

*   Ability to perform CRUD operations on a single page
*   Properties defined on the Page Model can be accessed by other requests
*   No need to write Ajax requests
*   No need to worry about rendering HTML with JavaScript

Cons:

*   Managing and writing multiple form tags on the same page can be difficult
*   The page has to be refreshed, resulting in the page-handler being appended to the URL (e.g., /todos?handler=add)
*   Issues can arise when navigating back and forth in the browser, such as:
*   Resubmitting the form, which may lead to extra testing if the logic is corrupted in the calculated data
*   Rendering old HTML, which may result in requests being sent for non-existent data

Overall, this method can be useful for simple applications, but it may become cumbersome to manage as the application grows. Additionally, the need to refresh the page and the potential for issues with navigation make it less optimal compared to other methods.

I would like to add the following as a note on this subject.
One of the methods that can be done so that the digits do not appear in the url is to redirect the method back to get.
But when we do this, the objects defined on the page model will be set again, which causes the objects to not maintain their current values.
Again, it is a preferable subject.

![Todos Example](https://blog.guneskorkmaz.net/blogposts/experiments/ndpe-1/razor-page-structure.webp)


#### 2. Creating a structure using Ajax for performing operations on a single page

![Todos Ajax Example](https://blog.guneskorkmaz.net/blogposts/experiments/ndpe-1/Todo-List-Ajax.webp)

Pros:

*   The page is not refreshed, providing a smoother user experience.
*   Visual features such as loading indicators and click blocking can be added.
*   Changes in the data (such as addition, deletion, etc.) are reflected immediately.
*   The HTML code is cleaner and more concise.

Cons:

*   The use of JavaScript is necessary for rendering elements dynamically on the page, which requires additional coding and testing.
*   The development of a dynamic structure using Ajax requires significant amounts of code.
*   In order to pass data to the server-side, it must be converted to JSON or rendered using both Razor and JavaScript.
*   It is important to thoroughly test and validate Ajax requests to prevent errors such as duplicate requests or failed requests due to network issues.


![Todos Ajax Example CSHTML Html](https://blog.guneskorkmaz.net/blogposts/experiments/ndpe-1/todo-cshtml.webp)
![Todos Ajax Example CSHTML Scripts](https://blog.guneskorkmaz.net/blogposts/experiments/ndpe-1/todo-cshtml-scripts.webp)

#### 3. Using the Model/Action pattern
![Razor Pages Update Page](https://blog.guneskorkmaz.net/blogposts/experiments/ndpe-1/razor-project-update-page.webp)

Pros:

*   Organizes the project and reduces the amount of code to write by creating separate pages for each process.
*   Provides a solid structure and allows for safe error control and validation.
*   Once the structure is learned, it offers convenience as the same structure is used in all transactions.

Cons:

*   Cannot be used reactively from a single page.
*   Separation of everything can lead to longer user operations and extended learning time. Although this can become a plus once learned, it may be difficult to learn at first and can become tedious due to the amount of repetition over time.

![Razor Pages Model/Action pattern](https://blog.guneskorkmaz.net/blogposts/experiments/ndpe-1/razor-project-design.webp)

### Conclusion

Thank you for following our series on Razor Pages Page Model. In this post, we covered three different methods for creating a web application with Razor Pages: using multiple forms on a single page, using Ajax for dynamic updates, and separating each action into its own model/action page.

Each method has its own advantages and disadvantages, and we hope that this series has helped you understand which method is best for your specific needs. Regardless of the method you choose, creating a proper structure is important for efficient and maintainable development.

If you missed any of the previous posts, you can find them below:

I hope you found this series helpful and informative. If you have any questions or feedback, please don't hesitate to reach out. And stay tuned for our next series on .NET web development!

[Github - NDPE Razor Pages](https://github.com/Runaho/NetDesignPatternsExperiments/tree/main/NDPE.RazorPagesPageModel/) 
