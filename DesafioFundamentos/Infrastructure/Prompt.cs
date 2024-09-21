namespace DesafioFundamentos.Infrastructure;

public static class Prompt
{
    public static T PerguntarUsuario<T>(string mensagem) where T : IConvertible
    {
        T resposta;
        bool conversaoOk;
        do
        {
            Console.WriteLine(mensagem);
            conversaoOk = TryParse(Console.ReadLine(), out resposta);
        } while (!conversaoOk);

        return resposta;
    }

    public static void Escrever(string mensagem)
    {
        Console.WriteLine(mensagem);
    }

    public static void Limpar()
    {
        Console.Clear();
    }

    private static bool TryParse<T>(string valor, out T retorno) where T : IConvertible
    {
        retorno = default;
        try
        {
            retorno = (T)Convert.ChangeType(valor, typeof(T));
            return true;
        }
        catch
        {
            return false;
        }
    }
}