// See https://aka.ms/new-console-template for more information
using Sample;
using System.Globalization;

//string noun = "skdfjie";

//var result = noun[^2];
//var result = noun[..^2];
//var withoutFirstChar = noun[1..];
//Console.WriteLine(withoutFirstChar);

//Length length = new(30.6);
//Console.WriteLine($"The length is {length}");

//Console.WriteLine($"The length in mm is {length.ValueMm} mm");
//Console.WriteLine($"The length in inches is {length.ValueInches} in");

//Length length = new(30.6);
//Console.WriteLine($"No format: The length is {length}");
//Console.WriteLine($"Format C:  The length is {length:C}");
//Console.WriteLine($"Format M:  The length is {length:M}");
//Console.WriteLine($"Format I:  The length is {length:I}");
//Console.WriteLine($"Format ##.000: The length is {length:##.000}");

//CultureInfo french = new("fr-FR");
//Console.WriteLine(string.Format(french, "In French, the length is {0:C}", length));

Length length = new(255.27);

Console.WriteLine($"The length is {length:i}");
Console.WriteLine($"The length is {length:m}");
Console.WriteLine($"The length is {length:fi}");

//LengthAwareInterpolatedStringHandler handler = $"Using interpolation: The length is {length:FI}";
//Console.WriteLine(handler.ToString());

Console.WriteLine(Helpers.FormatLengths($"Using interpolation: The length is {length:FI}"));


Console.ReadKey();


