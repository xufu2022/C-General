using System.Globalization;

namespace Sample;

public class LengthFormatProvider: IFormatProvider,ICustomFormatter
{
    private CultureInfo _culture;
    public LengthFormatProvider(CultureInfo culture) => _culture = culture;
    public LengthFormatProvider() : this(CultureInfo.CurrentCulture) { }

    public object? GetFormat(Type? formatType)
    {
        return formatType == typeof(ICustomFormatter) ? this : null;
    }

    public string Format(string? format, object? arg, IFormatProvider? formatProvider)
    {
        if (arg is Length length)
            return FormatLength(format, length);

        else if (arg is IFormattable formattable)
            return formattable.ToString(format, _culture);
        else if (arg != null)
            return arg.ToString()!;
        else
            return string.Empty;
    }

    private string FormatLength(string? format, Length length)
    {
        return format switch
        {
            "FI" or "fi" => FormatFeetInches(format, length),
            _ => length.ToString(format, _culture),
        };
    }

    private string FormatFeetInches(string format, Length length)
    {
        double totalInches = length.ValueInches;
        int feet = ((int)totalInches) / 12;
        double inches = totalInches - 12 * feet;
        return feet.ToString("N", _culture) + " ft " + inches.ToString("N", _culture) + " in";
    }
}