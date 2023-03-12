# Date and Time Arithmetic

## Working with Periods of Time

```csharp
var period = TimeSpan.FromSeconds(45);
var extendedPeriod = period.Multiply(2); // 90 seconds

TimeSpan interval = new TimeSpan(60, 100, 200);
//Appends all units to create a new representation
//60 hours + 100 minutes + 200 seconds = 2 days, 13 hours, 43 minutes & 20 seconds

// Different Representations of the Entire TimeSpan
TimeSpan interval = new TimeSpan(60, 100, 200);
interval.TotalDays // 2.57175925925925..
interval.TotalHours // 61.722222... 
interval.TotalMinutes // 3703.33333333...
interval.TotalSeconds // 222200
interval.TotalMilliseconds // 222200000

//Changing a Date or TimeSpan
var date = DateTimeOffset.UtcNow;
date = date.AddDays(10);
date = date.AddMinutes(2);
date = date.AddSeconds(49);
var interval = new TimeSpan(60, 100, 200);
var newInterval = interval.Divide(2);

// Using the TimeSpan
TimeSpan interval = new TimeSpan(1, 1, 0);
interval.TotalMinutes // 61
interval.Minutes // 1

```

## Using ISOWeek

```csharp
var isoWeek = ISOWeek.GetWeekOfYear(date.DateTime);

//DateTimeOffset.CompareTo
var a = new DateTimeOffset(2024, 03, 28, 00, 01, 00, TimeSpan.FromHours(1));
var b = new DateTimeOffset(2024, 03, 28, 00, 01, 00, TimeSpan.FromHours(1));
int comparisonResult = a.CompareTo(b); //// Same = 0

int comparisonResult = a.AddDays(-1).CompareTo(b); // Earlier = -1
int comparisonResult = a.AddDays(1).CompareTo(b) // Later = 1

```

## Unix Timestamp

Elapsed seconds since January 1st, 1970 (UTC)
