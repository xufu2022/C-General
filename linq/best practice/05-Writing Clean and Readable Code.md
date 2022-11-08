# Writing Clean and Readable Code

Does LINQ Make Code More or Less Readable?

> Declarative (LINQ)
```csharp
    orders.Max(o => o.Amount)
```
> Imperative
```csharp
decimal maxAmount = 0M;
foreach (var order in orders)
{
    if (order.Amount > maxAmount)
        maxAmount = order.Amount;
}
```

> LINQ Query Expression Syntax
- Not just for database queries
- Great for pipelines containing SelectMany
- Can avoid the need for anonymous objects