using System.Text.RegularExpressions;

namespace DesafioFundamentos.Extensions;

public static partial class StringExtensions
{
    public static bool EhPlacaValida(this string texto)
    {
        if (string.IsNullOrWhiteSpace(texto))
        {
            return false;
        }

        var conferidorPlaca = MyRegex();
        return conferidorPlaca.IsMatch(texto.ToUpper());
    }

    [GeneratedRegex("^[A-Z]{3}[0-9][A-Z0-9][0-9]{2}$")]
    private static partial Regex MyRegex();
}