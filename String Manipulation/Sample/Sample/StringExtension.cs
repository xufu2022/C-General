using System.Text;

namespace Sample;

public static class StringExtension
{
    public static string RemoveExcessWhiteSpace(this string original)
    {
        original=original.Trim();
        StringBuilder sb = new();
        var isPrevWhiteSpace = false;
        foreach (char c in original)
        {
            bool isNextWhiteSpace = char.IsWhiteSpace(c);
            if (!isPrevWhiteSpace || !isNextWhiteSpace)
            {
                sb.Append(c);
            }

            isPrevWhiteSpace = isNextWhiteSpace;
        }

        return sb.ToString();
    }
}