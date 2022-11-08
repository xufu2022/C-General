# Optimizing Performance

LINQ pipelines can solve complex problems with a single C# expression

**LINQ Performance Pitfalls**

- Slow: var longest = books.First(b => b.Pages == books.Max(x => x.Pages))
- Better: 
          - var mostPages = books.Max(x => x.Pages);
          - var longest = books.First(b => b.Pages == mostPages);
- Best: var longest = books.MaxBy(x => x.Pages);

## Additional LINQ Performance Enhancements

There has been a huge focus on performance in recent .NET versions
Take advantage of .NET performance features (e.g. Span<T>)

foreach (int item in _items)
{
}
foreach (int item in CollectionsMarshal.AsSpan(_items))
{
}