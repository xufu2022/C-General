# Advanced Parallel Programming: Understanding Locking and Shared Variables

Working with Shared Variables : ConcurrentBag<T>

    var bag = new ConcurrentBag<string>();
    Parallel.Invoke(
        () => { bag.Add(“Hello”); }, 
        () => { bag.Add(“World”); }, 
        () => { bag.Add(“from”); }, 
        () => { bag.Add(“Pluralsight”); } 
    );

Be careful when sharing variables and resources in a parallel process as you will run into race conditions

Always prefer atomic operations over lock when possible as its less overhead and performs faster

## Introducing a Lock

    Parallel.For(0, 100, (i) => {
        // Lock object is often referred to as sync root

        lock(...)
        {
            // If another thread has locked the “door” the thread will be blocked until the “door” is opened

            // Only one thread at a time please..
        }
    });

Use a lock to access resources in a thread-safe manner
- Be careful when adding a lock
- Nested locks can lead to deadlocks
- Only lock in short periods of time
- Do as little work as possible in the lock statement

> Interlocked from System.Threading : “Provides atomic operations for variables that are shared by multiple threads.”

Using Interlocked

    Interlocked.Increment(ref int thisValue)
    Interlocked.Decrement(ref int thisValue)
    Interlocked.Add(ref int toBeUpdated, int withValue)
    Interlocked.Add(ref long toBeUpdated, long withValue)

Incrementing a Variable

    static object syncRoot = new object();
    int result = 0;

    Parallel.For(0, 100, (i) => {
        Interlocked.Increment(ref result)
    });

Interlocked.Increment

    int result = 0;
    Parallel.For(0, 100, (i) => {

        // Only one thread performs the read & write at a given time. This is faster than using a lock()

        Interlocked.Increment(ref result)
    });

Interlocked vs Lock

Interlocked 

    int result = 0;
    Parallel.For(0, 100, (i) => {
        Interlocked.Increment(ref result)
    });

Lock

    static object syncRoot = new object();
    int result = 0;
    Parallel.For(0, 100, (i) => {
        lock(syncRoot)
        {
            result += 1;
        }
    });

Interlocked.Decrement

    int result = 0;
    Parallel.For(0, 100, (i) => {
        Interlocked.Decrement(ref result)
    });

Interlocked uses less instructions and is faster than a lock

Bitwise Operations with Interlocked

    //Returns the original value of “thisValue”

    int Interlocked.Or(ref int thisValue, int withThis)
    int Interlocked.And(ref int thisValue, int withThis)

Set a New Value

    // Returns the “source” value
    T Interlocked.Exchange<T>(ref T source, T newValue)

Interlocked.Exchange

    int Interlocked.Exchange(ref int source, int newValue)

Exercise: Use Interlocked.Exchange as a Gate Keep

    var gate = 0;
    // Try locking the gate
    var state = Interlocked.Exchange(ref gate, 1);
    if(state == 0)
    {
        // Gate was previously locked
    }
    else
    {
        // Gate was already locked
        // Back-off for a while
        // Retry
    }

## Next: Deadlocks with Nested Locks

    Locked? Thread Will Be Blocked Until Opened

    Task.Run(() => {
        lock(syncRoot)
        {
            Thread.Sleep(5000);
        }
    });

    Task.Run(() => {

        // This thread will be locked until “syncRoot” is released (5 seconds)

        lock(syncRoot) 
        {
        }
    });

Deadlock: Fighting over the Same Resource

Avoiding a Deadlock

- Don’t share lock objects for multiple shared resources
- Use one lock object for each shared resource
- Give you lock object a meaningful name
- Don’t use a string as a lock
- Don’t use a type instance from typeof() as a lock
- Don’t use “this” as a lock

Nested locks may result in a deadlock

    lock(lock1)
    {
        Parallel.For(0, 100, (i) => {
            Deadlock();
        });
    }

    void Deadlock()
    {
        lock(lock1)
        {
            Thread.Sleep(1);
        }
    }

Avoid nested locks and shared locks!

## Cancel Parallel Operations

Cancellation

    CancellationTokenSource cts = new CancellationTokenSource();
    var options = new ParallelOptions
    {
        CancellationToken = cts.Token
    };
    Parallel.For(0, 100, options, _ => {});
    Parallel.ForEach(source, options, _ => {});
    Parallel.Invoke(options, () => {}, () => {});

When a cancellation is detected: No further iterations/operations will start!

Parallel Methods

- Built on the Task Parallel Library
- Monitors for Cancellation
- A task doesn’t start when a cancellation token is cancelled

It won’t stop executing already started operations

Monitor the Cancellation Token

    CancellationTokenSource cts = new CancellationTokenSource();

    var options = new ParallelOptions
    {
        CancellationToken = cts.Token
    };

    Parallel.For(0, 100, options, _ => {
        if(cts.Token.IsCancellationRequested)
        {
            // Roll back?
        }
    });

When to Monitor the Cancellation Token

    Parallel.For(0, 100, options, _ => {

        FirstExpensiveOperation();

        if(cts.Token.IsCancellationRequested)
        {
        }
        else
        {
            SecondExpensiveOperation();
        }
    });

Each system executing the code might complete it faster, or slower!

## ThreadLocal and AsyncLocal Variables

> ThreadLocal<T> : Provides storage that is local to a thread

Note: Task in the Task Parallel Library reuse threads!

Thread Local/Static data may be shared between multiple tasks that uses the same thread

    ThreadLocal<decimal?> data = new ThreadLocal<decimal?>();
    data.Value = 100m;

    var values = data.Values; 
    // All values for all threads

> AsyncLocal<T> : “Represents ambient data that is local to a given asynchronous control flow, 
such as an asynchronous method.”

When you write to AsyncLocal a local copy will be created. 

The outer contexts value will not be overwritten!

    AsyncLocal<decimal?> data = new AsyncLocal<decimal?>();
    data.Value = 100m;
    Task.Run(() => {
        // Local copy created
        data.Value = 200m;
    });

    // data.Value is stil 100 after the Task.Run!
