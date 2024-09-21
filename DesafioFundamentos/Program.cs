using System.Text;
using DesafioFundamentos.Infrastructure;
using DesafioFundamentos.Models;

Console.OutputEncoding = Encoding.UTF8;

Prompt.Escrever("Seja bem vindo ao sistema de estacionamento!");
var precoInicial = Prompt.PerguntarUsuario<decimal>("Digite o preço inicial:");
Prompt.Limpar();
var precoPorHora = Prompt.PerguntarUsuario<decimal>("Agora digite o preço por hora:");
var es = new Estacionamento(precoInicial, precoPorHora);

int opcao;
var sb = new StringBuilder();
sb.AppendLine("1 - Cadastrar veículo");
sb.AppendLine("2 - Remover veículo");
sb.AppendLine("3 - Listar veículos");
sb.AppendLine("4 - Encerrar");
var menu = sb.ToString();

do
{
    Prompt.Limpar();
    Prompt.Escrever(menu);
    opcao = Prompt.PerguntarUsuario<int>("Digite a sua opção:");

    var retorno = opcao switch
    {
        1 => es.AdicionarVeiculo(),
        2 => es.RemoverVeiculo(),
        3 => es.ListarVeiculos(),
        4 => "O programa será encerrado!",
        _ => "Opção inválida"
    };
    
    Prompt.Escrever(retorno);
    _ = Prompt.PerguntarUsuario<string>("Digite qualquer tecla para continuar:");
} while (opcao != 4);

Prompt.Escrever("Programa finalizado!");
