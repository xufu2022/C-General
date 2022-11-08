# Testing and Debugging Effectively

**IEnumerable<T>**
```csharp
interface IEnumerable<T>
{
    IEnumerator<T> 
    GetEnumerator();
}

interface IEnumerator<T>
{
    bool MoveNext();
    T Current { get; }
}
```

## IAsyncEnumerable<T>

```csharp 
interface IAsyncEnumerable<T>
{
    IAsyncEnumerator<T>
    GetAsyncEnumerator();
}

interface IAsyncEnumerator<T>
{
    ValueTask<bool> MoveNextAsync();
    T Current { get; }
}
```