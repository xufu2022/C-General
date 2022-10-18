# Storing Date and Time Information

The Date and Time Types

| **Type**    | **Description** |
|:---------------------------------------------------|------------|
| DateTime | A point in time – including date and time |
| DateOnly  | A date |
| TimeOnly  | A time of day between 00:00 and 23:59 |
| TimeSpan | A period of time |
| DateTimeOffset | An absolute point in time – including, date, time and timezone information |

```csharp
    TimeOnly time = new TimeOnly(7, 0);// 07:00 AM
    TimeSpan timeSpan = new TimeSpan(7, 0, 0);// A period of 7 hours
```

> Standard Date-Time Formats 
- ToString(string formatString)

| **Format string**    | **In UK English** | 
|:------------------------------------|------------|
|   "D"  |   08 May 2023   |
|   "T"  |   11:30:00   |
|   "G"  |   08/05/2023 11:30:00   |
|   "F"  |   08 May 2023 11:30:00   |
|   "d"  |   08/05/2023   |
|   "t"  |   11:30   |
|   "g"  |   08/05/2023 11:30:00   |
|   "f"  |   08 May 2023 11:30:00   |

## Timezone Offsets

- UTC = Coordinated Universal Time
    - Time in London, UK, without daylight savings time
- +1 means an hour ahead of UTC 
- If UTC is 12pm, UTC +1 is 1pm
- +1 is the offset

> Timezone Offsets
UTC -8 (Timezone in California in winter (no daylight savings))

- If UTC is 6pm, then UTC - 8 is 10am
  - (8 hours behind 6pm)
- -8 is the offset
- In many countries/states, daylight savings adds 1 to the offset, so -8 becomes -7

```csharp
    // 1 Feb 2023 at 6 pm (18:00)
    DateTime date = new (2023, 2, 1, 18, 0, 0);

    // DateTimeOffset stores a date, time, and offset:
    // 1 Feb 2023 at 6 pm (18:00) in the timezone UTC -8
    DateTimeOffset dateOffset = new (2023, 2, 1, 18, 0, 0, TimeSpan.FromHours(-8));
```