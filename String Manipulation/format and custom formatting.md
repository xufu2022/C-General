# Manipulating Strings

> Removing Excess Whitespace 
- Use string.Trim() to remove at beginning and end

> Extracting Characters

Single number gives the character at that position (zero-indexed)

    "curry"[0] ==> "c"
    "curry"[1] ==> "u"
    "curry"[^1] ==> "y"
    "curry"[^2] ==> "y"

> Extracting Substrings

    // Substring starts at character 1
    // Substring stops just BEFORE character 3
    "curry"[1..3] => "ur"

    //1st to last but one character
    "curry"[0..^1] "curr" //(since C# 8)
    //old code
    "curry".Substring(0, "curry".Length-1)


Split() to split a string into fields 
- Join () does the reverse

[x..y] notation to extract substrings

Excess whitespace
- Trim() to remove at beginning and end
- Write your own logic to remove in the middle

Equality
- == is case sensitive
- Equals() can optionally ignore the case

General principles
- String methods generally return new strings, because strings are immutable
- Work with strings in a standard, consistent format 
  - For example, lowercase, trimmed
- Combine techniques to perform useful higher level string processing

## Custom Formatting

virtual object.ToString() 

- Can only give one single representation
- No customizability
- But is sensitive to cultural settings

Type to store small lengths

```csharp
  public readonly record struct Length (double ValueCm){
      const int _mmInCm = 10;	// 10 mm = 1 cm
      const double _cmInInch = 2.54;  // 2.54 cm = 1 in 

      public double ValueMm => ValueCm * _mmInCm;
      public double ValueInches => ValueCm / _cmInInch;

      public override string ToString() => $"{ValueCm} cm";
  }
```

# Customizing strings

- Devising format strings
- IFormattable
- Custom formatters
- Custom interpolated string handlers

## Supporting Different Formats with IFormattable

| **Standard strings**| Desciption| example |
|:---------------------------------|------------|------------|
|C      |   Display in cm   |30 cm |
|M       |   Display in mm   |300 mm |
|I       |   Display in inches  |12 in |
|G      |   (‘General’ format) - same as C  |30 cm |


## Extending Formatting with a Custom Formatter

## Custom Interpolated String Handlers - Uses

Implement a custom interpolated string handler
- To detect when formatting a Length
  - And inject LengthFormatProvider
  - To allow feet + inches formatting
