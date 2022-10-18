using System.Runtime.CompilerServices;

namespace Sample;

[InterpolatedStringHandler]
public ref struct LengthAwareInterpolatedStringHandler
{
    DefaultInterpolatedStringHandler _underlying;
    public LengthAwareInterpolatedStringHandler(int literalLength, int formattedCount)
    {
        _underlying = new DefaultInterpolatedStringHandler(literalLength, formattedCount);
    }
    public void AppendLiteral(string s)
    {
        _underlying.AppendLiteral(s);
    }

    public void AppendFormatted<T>(T t)
    {
        _underlying.AppendFormatted(t);
    }

    public void AppendFormatted<T>(T t, string format) where T : IFormattable
    {
        _underlying.AppendFormatted(t, format);
    }

    public void AppendFormatted(Length length, string format)
    {
        LengthFormatProvider formatter = new();
        string result = formatter.Format(format, length, null);
        _underlying.AppendLiteral(result);
    }

    public override string ToString() => _underlying.ToString();

    public string ToStringAndClear() => _underlying.ToStringAndClear();
}