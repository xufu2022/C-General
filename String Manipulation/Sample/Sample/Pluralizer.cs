namespace Sample;

public class Pluralizer
{
    private static HashSet<string> dontPluralizeInOrders = new() { "bread", "flour", "cereal" };

    private static Dictionary<string, string> unusualPlurals = new()
    {
        ["loaf"] = "loaves",
        ["mouse"] = "mice",
        ["child"] = "children",
    };

    public static string MakeNounPlural(string noun)
    {
        if (dontPluralizeInOrders.Contains(noun))
        {
            return noun;

        }

        else if (unusualPlurals.ContainsKey(noun))
        {
            return unusualPlurals[noun];
        }
        else if(EndsWithConsonantY(noun))
            return noun[..^1] + "ies";
        else
            return noun + "s";

    }
    public static string MakeNounPlural(string noun, int count)
        => count == 1 ? noun : MakeNounPlural(noun);

    private static bool EndsWithConsonantY(string noun)
    {
        if (noun.Length < 2)
            return false;
        if (noun[^1] != 'y')
            return false;
        char lastButOneLetter = noun[^2];
        return lastButOneLetter switch
        {
            'a' or 'e' or 'i' or 'o' or 'u' => false,
            _ => true
        };
    }
}