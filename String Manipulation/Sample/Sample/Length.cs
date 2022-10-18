using System.Globalization;

namespace Sample;

public readonly record struct Length(double ValueCm): IFormattable
{
    const double _mmInCm = 10;  // 10 mm = 1 cm
    const double _cmInInch = 2.54;  // 2.54 cm = 1 in 

    public double ValueMm => ValueCm * _mmInCm;
    public double ValueInches => ValueCm / _cmInInch;

    public override string ToString() => $"{ValueCm} cm";
    public string ToString(string? format, IFormatProvider? formatProvider)
    {
        if (string.IsNullOrEmpty(format))
            format = "G";
        if (formatProvider == null)
            formatProvider = CultureInfo.CurrentCulture;
        return LengthFormatter.LengthToString(this, format, formatProvider);
    }

    private static class LengthFormatter
    {
        internal static string LengthToString(Length value, string format, IFormatProvider provider)
        {
            string? result = ToStandardString(value, format, provider);
            return result ?? value.ValueCm.ToString(format, provider) + " cm";
        }

        private static string? ToStandardString(Length value, string format, IFormatProvider? formatProvider)
        {
            return format switch
            {
                "G" or "C" or "g" or "c" => value.ValueCm.ToString("G", formatProvider) + " cm",
                "M" or "m" => value.ValueMm.ToString("G", formatProvider) + " mm",
                "I" or "i" => value.ValueInches.ToString("G", formatProvider) + " in",
                _ => null
            };
        }
    }
}

