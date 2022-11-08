# discovering-the-power-of-linq

## Language Features

- Lambda Expressions
- Extension Methods
- Anonymous Types
- Query Expression Syntax
- Generics
- yield and var Keywords

```csharp
// statement lambdas can contain several lines of code
customers.Where(c => {
    var hasEmail = c.Email != null;
    return hasEmail; })

customers.Where(c => c.Email != null)
```

### Lambda Expressions
Easily pass anonymous functions to methods

```csharp
static class StringExtensions
{
    public static string Shout(this string s)
    {
        return s.ToUpper() + "!!!!";
    }
}
```

### Extension Methods

Extend any type with additional methods
LINQ provides extension methods on IEnumerable<T>
Connect these extension methods together into “pipelines”

### Misconception: “LINQ pipelines are for show-offs”
LINQ should make your code more readable, not less

```csharp
var x = new { Author = "Mark Seemann", Title = "Dependency Injection in .NET" };
var y = new { Author = "Martin Fowler", Title = "Patterns of Enterprise Architecture" };
var books = new[] { x, y };

```

### Anonymous Types
Create new types without explicitly declaring a class
```csharp
var author = "Elton Stoneman";
var title = "Docker on Windows";
var book = new { Author = author, Title = title };
// inferred property names:
var book = new { author, title };
```

- Can infer property names
- Great for passing state through LINQ pipelines
- Often preferable to tuples

## Query Expression Syntax

- Similar to SQL
- Many new keywords

```csharp
var query = from c in customers
            group c by c.Country into countryGroup
            orderby countryGroup.Key
            select countryGroup;
```
> Misconception
- LINQ is just for database queries
- There are several LINQ “providers”.
e.g. LINQ to Entities LINQ to Objects

## Query Expression Syntax
Can be used with any LINQ provider, including LINQ to objects
Sometimes easier to read than chained extension methods

> Generics and the yield Keyword

Create classes and methods that can work with any type
```csharp
public static IEnumerable<T> DoubleUp<T>(this IEnumerable<T> source)
{
    foreach (var s in source)
    {
        yield return s;
        yield return s;
    }
}
```

- Create classes and methods that can work with any type
- The LINQ extension methods are generic
- You can create your own generic methods

## LINQ and Functional Programming

LINQ applies many powerful functional programming techniques in C#
Learning LINQ will increase your understanding of functional programming

