# asynchronous-programming

> Threading (Low-level)

> Background worker (Event-based asynchronous pattern)

> Task Parallel Library

> Async and await

## Synchronous vs Asynchronous

An asynchronous operation occurs in parallel and relieves the calling thread of the work

Suited for I/O Operations

-   Disk
-   Memory
-   Database
-   Web/API

## When to Use Parallel Programming

- CPU bound operations
- Independent chunks of data

## An asynchronous operation occurs in parallel

    await Task.Run(() => {
    // I’m an asynchronous operation that is awaited
    });

    Parallel.Invoke(
        () => { /* Parallel Thread 1 */ },
        () => { /* Parallel Thread 2 */ },
        () => { /* Parallel Thread 3 */ },
        () => { /* Parallel Thread 4 */ },
    );

## Calling Result or Wait() may cause a deadlock

Using async and await in ASP.NET means the web server can handle other requests

    Task<string> asynchronousOperation = GetStringAsync();
    string result = await asynchronousOperation;

## Understanding a Continuation

### The Await Keyword

- Gives you a potential result
- Validates the success of the operation
- Continuation is back on calling thread

The await keyword introduces a continuation, allowing you to get back to the original context (thread)

    var response = await client.GetAsync(URL); 
    var content = await response.Content.ReadAsStringAsync();
    var data = JsonConvert.DeserializeObject(...)

### Creating Your Own Asynchronous Method

> Only use async void for event handlers

> Exceptions occurring in an async void method cannot be caught

> Always use await to validate your asynchronous operations

## Best Practices

    async Task Download()
    {
        var client = new HttpClient();

        // Task<HttpResponseMessage>
        // await => Validates the Task<HttpResponseMessage> any exceptions will be re-thrown

        var response = await client.GetAsync(URL); 

        // HttpResponseMessage
        var content = await response.Content.ReadAsStringAsync();
    }


- Always use async and await together
- Always return a Task from an asynchronous method
- Always await an asynchronous method to validate the operation
- Use async and await all the way up the chain
- Never use async void unless it’s an event handler or delegate
- Never block an asynchronous operation by calling Result or Wait()

## Different types of continuations

    var response = await client.GetAsync(URL); 

    // different continuations
    
    client.GetAsync(URL).ContinueWith((response) => {
    });