# Parallel Programming and Multithreading in C#

Using the Task from the Task Parallel Library

    Task.Run(() => {
        // Only executes on one thread
        // This code will execute on a different context
    });

Break down a large problem and compute each piece independently

    //Task Parallel Library

    await Task.Run(() => {
        // I’m an asynchronous operation that is awaited
    });

    Parallel.Invoke(
        () => { /* Parallel Thread 1 */ },
        () => { /* Parallel Thread 2 */ },
        () => { /* Parallel Thread 3 */ },
        () => { /* Parallel Thread 4 */ },
    );

Running Work on Another Thread

    Task.Run(() => {

        // Goal is to run these on 4 different threads

        var msft = Calculate(“MSFT”);
        var googl = Calculate(“GOOGL”);
        var ps = Calculate(“PS”);
        var amaz = Calculate(“AMAZ”);
        return new [] { msft, googl, ps, amaz };
    });

Get help from the framework to optimize the parallel operation

- Parallel Programming in .NET
    - Thread
    - Task Parallel Library

Task Parallel Library and its Task should be the preferred way to introduce parallel programming

    Task.Run(() => {
    });

No need to care about lower-level threads

Work may be scheduled on a new, or reused thread.

    Parallel.Invoke(
        () => {}, 
        () => {}, 
        () => {} 
    );

    Parallel.For(0, 10, (index) => {});

    Parallel.ForEach(source, (element) => {});

Task Parallel Library provides a way to write Parallel LINQ (PLINQ)

**Parallel (Extensions)**

Built on-top of the Task in the Task Parallel Library

Parallel will ensure that work is distributed efficiently on the system that runs the application

