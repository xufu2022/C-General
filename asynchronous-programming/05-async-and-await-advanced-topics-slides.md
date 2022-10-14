# Async & Await Advanced Topics

## Asynchronous Streams & Disposables

Asynchronous streams requires at least C# 8.0 and .NET Core 3.0

> IAsyncEnumerable<T>

“Exposes an enumerator that provides asynchronous iteration over values of 
a specified type.”

> Asynchronous Stream

- Producing a Stream

        public async IAsyncEnumerable<string> Get()
        {
            await Task.Delay(2000);
            yield return “Hello”;
            await Task.Delay(2000);
            yield return “World”;
        }
- Consuming a Stream

        await foreach(var word in Get())
        {
        }

- Consuming an Asynchronous Stream

        await foreach(var price in GetAllStockPrices())
        {
            // Consume the price as soon as it’s returned
            // by the stream
            // Each item is retrieved asynchronously!
        }

- Allowing you to asynchronously retrieve each item

- Producing an Asynchronous Stream

        public async IAsyncEnumerable<StockPrice> GetAllStockPrices()
        {
            using var stream = new StreamReader(...);
            await stream.ReadLineAsync();
            while(await stream.ReadLineAsync() is string line) 
            {
                // Producing an Asynchronous Stream
                // The object is returned to the foreach loop as soon as it’s parsed!

                yield return StockPrice.FromCSV(line);
            }
        }

## Asynchronous Disposable

Clean up resources asynchronously by implementing the interface IAsyncDisposable

    public class Service : IAsyncDisposable
    {
        public async ValueTask DisposeAsync()
        {
            await Task.Delay(500);
        }
    }
    
    public class Consumer
    {
        public async Task Run() 
        {
            await using var service = new Service();
            // Use service
            // service is asynchronously disposed at the end of the method
        }
    }

## The Implications of Async and Await

## The State Machine

- Keeping track of tasks
- Executes the continuation
- Provides the continuation with a result
- Handles context switching
- Report errors

> Reduce the Amount of State Machines : With the same method signatures

    // Generates a lot of state machines

    public async Task<string> Run() 
    {
        return await Compute();
    } 
    public async Task<string> Compute()
    {
        return await Load();
    } 
    public async Task<string> Load()
    {
        return await Task.Run(() => ...);
    }    

    //No state machines

    public Task<string> Run() 
    {
    return Compute();
    } 
    public Task<string> Compute()
    {
    return Load();
    } 
    public Task<string> Load()
    {
    return Task.Run(() => ...);
    }

## Next: Deadlocking

A deadlock may occur if two threads depend on each other and one is blocked

The state machine runs on the same thread (UI) that we are blocking!

    var task = Task.Run(() => {

        // Needs to invoke the UI thread before the task can be marked as completed

        Dispatcher.Invoke(() => { });
    });

    // Blocks the UI thread
    // Don’t use Wait()
    task.Wait();

The state machine runs on the calling thread

## Asynchronous Streams & Disposables

    //Streams

    async IAsyncEnumerable<StockPrice> Get()
    {
        while(...) 
        {
            yield return item;
        }
    }

    //Disposables

    class Service : IAsyncDisposable
    {
        public async ValueTask DisposeAsync()
        {
            await Task.Delay(500);
        }
    }

    class Consumer
    {
        public async Task Run() 
        {
            await using var service = new Service();
        }
    }

    