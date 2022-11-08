# Avoiding Unnecessary Work with Laziness

Avoid doing any more work than necessary

Three ways to be lazy
- Don’t start iterating until you need to
- Don’t iterate through more elements than you need to
- Avoid iterating through more than once

## Deferred Execution

## Breaking Out Early

The “any” pattern:

```csharp
bool anyRefunded = false;
foreach (var order in orders)
{
    if (order.Status == "Refunded")
    {
        anyRefunded = true;
        break;
    }
}

orders.Any(o => o.Status == "Refunded")
```

## Avoiding Multiple Enumeration

Reasons to avoid iterating through an IEnumerable<T> more than once:

**Performance**
Especially if the pipeline contains long-running methods

**Correctness**
You can get different results each time you iterate

## Should I Use ToList?

- Only if you know you need the entire sequence cached in memory
- If you want to safely enumerate multiple times
- Avoid if you have a huge data set

## Multiple Enumeration and Databases

## Multiple Enumeration and Correctness

**Returning IEnumerable<T>**
public ??? GetOrdersForDelivery()

| **Return Type**| **Implications** |
|:---------------------------------|------------|
|Order[]     |  The results are already in memory and we can safely enumerate multiple times.   |
|List<Order>      | In memory but … do we own this list? May wish to call ToList again. |
|IReadOnlyCollection<Order>       |  An in-memory list that we know won’t change.  |
|IEnumerable<Order>  | Might take advantage of deferred execution. Not safe to enumerate multiple times. |
|IQueryable<Order>   |   Might take advantage of deferred execution. Not safe to enumerate multiple times.|

**IEnumerable<T> Function Parameters**

Make it easy for the caller by accepting IEnumerable<T>
Don’t require them to pass an Array or List<T>

```csharp
void ShipOrders(IEnumerable<Order> orders)
{
    // can cache for ourselves if we want to
    orders.ToList()
}
```