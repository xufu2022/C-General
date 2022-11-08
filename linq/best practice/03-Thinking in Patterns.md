# Thinking in Patterns

> Looping Through Collections
- Just use a for or foreach loop?
- Maybe LINQ can help us?
- Learn to spot repeating patterns

> Declarative or Imperative Code?
- Declarative
    - Says what we want to do
    - Moves implementation details out of the way
    - Expresses our intent
- Imperative Code
    - Says how it should be done
    - Specifies implementation details
    - Can obscure our intent

```csharp
foreach (int item in _items)
{
}
foreach (int item in CollectionsMarshal.AsSpan(_items))
{
}
```

## Understanding the Implementation

> LINQ is an abstraction
- people.OrderBy(p => p.FirstName) 
- LINQ to objects – quicksort
- LINQ to entities – ORDER BY

> We don’t see the implementation details 
- Potential for sub-optimal performance

## Sub-optimal LINQ Performance

## More Performance Pitfalls

Some LINQ to Objects methods cache the entire sequence in memory e.g. OrderBy, GroupBy, Reverse

```csharp
var last = someSequence.Reverse().First();
// Also caches in memory (and enumerates twice!)
var last = someSequence.ToArray()[someSequence.Count() – 1];
// The right way to do it!
var last = someSequence.Last();
```

## Optimizing LINQ to Entities

Your LINQ pipeline will get turned into SQL
Optimizing SQL performance


- Define appropriate indexes and keys
- Don’t pull down more rows or columns than you need to
- Construct a single query rather than using many Optimizing SQL performance

