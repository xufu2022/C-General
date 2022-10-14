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

When to Use Parallel Programming

- CPU bound operations
- Independent chunks of data

There’s no guarantee that the operations will run in parallel

The Parallel Methods Blocks the Calling Thread

    // Block the calling thread until all the 
    // parallel operations completed

    Parallel.Invoke(...);

    Parallel.For(...);

    Parallel.ForEach(...);


Deadlocking with the Parallel Class

    Parallel.For(0, 4, (index) => {
        Dispatcher.Invoke(() => {
            // Run on the UI Thread
        });
    });

By default calling these Parallel methods will consume as much computer power as possible

Parallel Invoke (with Max Degree of Parallelism)

    Parallel.Invoke(
        new ParallelOptions { MaxDegreeOfParallelism = 2 }
        () => { /* Parallel Thread 1 */ }, 
        () => { /* Parallel Thread 2 */ }, 
        () => { /* Parallel Thread 3 */ }, 
        () => { /* Parallel Thread 4 */ }
    );

Misusing Parallel in ASP.NET can cause bad performance for all users!

Using Parallel and Asynchronous Principles Together

    await Task.Run(() => {
        // I’m an asynchronous operation that is awaited
    });
    Parallel.Invoke(
        () => { /* Parallel Thread 1 */ },
        () => { /* Parallel Thread 2 */ },
        () => { /* Parallel Thread 3 */ },
        () => { /* Parallel Thread 4 */ },
    );

Don’t reinvent this, use the Task Parallel Library!

### Handling Exceptions

    // Automatically validates the parallel operations.

    Parallel.Invoke(...);

    Parallel.For(...);

    Parallel.ForEach(...);

    Parallel.Invoke(
        () => { throw new Exception(“1”); },
        () => { throw new Exception(“2”); },
        () => { throw new Exception(“3”); },
        () => { throw new Exception(“4”); },
    );

Not yet executed parallel operations will not be cancelled just because one operation fails

### Processing a Collection of Data in Parallel

    foreach(var element in source) 
    { 
        // Execute sequentially
    }

    Parallel.ForEach(source, (element) => {
        // Execute in parallel
        // Automatically distributed work that runs in parallel

    });

    // Normal Foreach vs Parallel.ForEach

    Parallel.ForEach(source, (element) => {
        // Execute in parallel Automatically distributed work that runs in parallel

    });

    //0 Inclusive, 10 Exclusive

    Parallel.For(0, 10, (i) => {
        // Execute in parallel
    });

The performance benefits will be more obvious with larger collections to process

Break won’t automatically stop running operations

    Parallel.For(0, 100, (i, state) => {

        // Scheduled iterations for indices lower than 50 will still start!

        if(i == 50) 
        { 
            // Only operations for indices over 50 won’t be scheduled to start

            state.Break(); 
        }
    });

Parallel + Asynchronous

    await Task.Run(() => { Parallel.Invoke(...); });
    await Task.Run(() => { Parallel.For(...); });
    await Task.Run(() => { Parallel.ForEach(...); });