# Unleashing the Power of Pipelines

```csharp
    "10,5,0,8,10,1,4,0,10,1"
        .Split(',')
        .Select(int.Parse)
        .OrderBy(n => n)
        .Skip(3)
        .Sum()
```

## Chaining LINQ Extension Methods

Create a “pipeline”

> Many-to-One Methods
    IEnumerable<T> in, single value out


> Aggregate
General purpose LINQ extension method to apply a function to each element in an IEnumerable<T> to calculate a single value

**Enumerable.Repeat** : Repeats an item a specified number of times
**Regex.Matches** : Returns all the matches on a Regular Expression

> SelectMany
Turns each input element into zero or more output elements