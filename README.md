# JsonStorage

I started this as an alternative to my [SessionData](https://github.com/adamosoftware/SessionData) project to be another way to save user and session data in a web app because I got concerned about added database traffic. Even fast queries can bog down an app if there are lots and lots of executions.

I realize my solution here is a bit redundant to Azure Table Storage and Cosmos DB, but my issue with Table Storage is that your entities must inherit from `TableEntity`. This would be okay if I were starting from scratch. But for apps in use today, it might not be feasible to change inheritance of objects I need to store. Moreover, I wanted to take advantage of Newtonsoft Json.NET for serialization because it's such a pleasure to use, and has tons of options.

I haven't spent enough time with Cosmos DB to know if I should really be using that instead. Bottom line is I really like blob storage today and can work with it. Microsoft seems really proud of Cosmos DB, but I had some concerns about cost and learning curve. With this solution, I wanted to build on something I already knew well.
