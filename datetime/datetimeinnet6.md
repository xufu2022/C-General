# Date and Time in .NET

## Date and Time Fundamentals

Date ambiguity is a common cause of errors and can lead to confusion

Date ambiguity is solved with ISO 8601

**ISO 8601**

ISO 8601 tackles this uncertainty by setting out an internationally agreed way to represent dates: YYYY-MM-DD

Year-Month-DayTHour-Minute-Second
2024-06-10T18:00:00+00:00

**T** : Time Delimiter
**(+00:00)** Time zone offset or Zulu time (Z)


Avoid choosing a custom format even if you own both ends of the system

## Using DateTime

```csharp
    var filipsBirthday = new DateTime(2024, 01, 29);
    var currentLocalTime = DateTime.Now;
    var currentUtcTime = DateTime.UtcNow;
```

## DateTimeKind

```csharp
//DateTimeKind.Local 
var currentLocalTime = DateTime.Now;
//DateTimeKind.Utc
var currentUtcTime = DateTime.UtcNow;
```

DateTime does not contain time zone specific information

When to Use DateTime

Store the offset to UTC

DateTime.Now is a common cause of errors 
It returns a local representation of the date and time without offset information

## TimeZoneInfo

“Represents any time zone in the world.
A time zone is a geographical region in which the same time is used.
TimeZoneInfo class can be used to convert the time in one time zone to the corresponding time in any other time zone”

```csharp
TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.Now, "E. Australia Standard Time")

// Using IANA Instead

    // Will not work during daylight saving!
    TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.Now, "E. Australia Standard Time")
    // Automatically looks up the correct time zone
    TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.Now, "Australia/Sydney")

```

Always use DateTime.UtcNow instead of Now!

Store data in UTC and convert it the users local time when presenting it in the application.

## DateTimeOffset

“Represents a point in time, typically expressed as a date and time of day, relative to Coordinated Universal Time (UTC)”

```csharp
new DateTimeOffset(2024, 06, 01, 13, 37, 0,  TimeSpan.FromHours(2))
```

DateTimeOffset should be preferred over using DateTime

TimeZoneInfo contains information about the UTC offset

```csharp

    var input = "07/01/2024 10:00:00 PM";
    DateTime.Parse(input, CultureInfo.GetCultureInfo("en-US"));
    DateTime.Parse(input, CultureInfo.GetCultureInfo("en-GB"));

// Parse the Date and Time with Exact Format

    var input = "07/01/2024 10:00:00 PM";
    var format = "M/d/yyy h:mm:ss tt";
    DateTime.ParseExact(input, format);
    DateTime.ParseExact(input, format, CultureInfo.GetCultureInfo("en-US"));
    DateTime.ParseExact(input, format, CultureInfo.GetCultureInfo("en-GB"));

// Parsing a Date
    var input = "07/01/2024 10:00:00 PM";
    var format = "M/d/yyy h:mm:ss tt";
    DateTime date = DateTime.ParseExact(input, format, CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal);

// Get Current Time Adjusted to UTC

// Offset: +02:00
DateTimeOffset.Now

// Offset: +00:00
DateTimeOffset.Now.ToUniversalTime()
```

## DateOnly and TimeOnly

```csharp
// Using DateOnly
var date = new DateOnly(2024, 07, 01);
var dateAsIso8601 = date.ToString("O");

// Constructing a DateOnly
var input = "2024-07-01";
var format = "O";
DateOnly.ParseExact(input, format, CultureInfo.InvariantCulture);
DateOnly.FromDateTime(DateTime.UtcNow);

// Using TimeOnly
var time = new TimeOnly(23, 59);
time = TimeOnly.FromDateTime(DateTime.UtcNow);
var timeAsIso8601 = time.ToString("O");

// Using NodaTime

using NodaTime;
var now = SystemClock.Instance.GetCurrentInstant();
var stockholmTimeZone = DateTimeZoneProviders.Tzdb["Europe/Stockholm"];
var swedenTime = now.InZone(stockholm);
```