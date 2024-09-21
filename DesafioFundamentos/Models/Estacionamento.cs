using System.Text;
using DesafioFundamentos.Extensions;
using DesafioFundamentos.Infrastructure;

namespace DesafioFundamentos.Models;

public class Estacionamento(decimal precoInicial, decimal precoPorHora)
{
    private readonly List<string> _veiculos = [];

    public string AdicionarVeiculo()
    {
        string placa;
        do
        {
            placa = Prompt.PerguntarUsuario<string>("Digite a placa do veículo para estacionar:").ToUpper();
        } while (!placa.EhPlacaValida());
        
        _veiculos.Add(placa);
        return $"Veiculo placa {placa} foi estacionado com sucesso!";
    }

    public string RemoverVeiculo()
    {
        string placa;
        do
        {
            placa = Prompt.PerguntarUsuario<string>("Digite a placa do veículo para remover:").ToUpper();
        } while (!placa.EhPlacaValida());
        
        if (_veiculos.All(x => x != placa?.ToUpper()))
        {
            return "Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente";
        }
        var horas = Prompt.PerguntarUsuario<int>("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                
        var valorTotal = precoInicial + precoPorHora * horas; 
            
        _veiculos.Remove(placa);

        return $"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal:F2}";
    }

    public string ListarVeiculos()
    {
        if (_veiculos.Count == 0)
        {
            return "Não há veículos estacionados.";
        }

        var sb = new StringBuilder();
        sb.AppendLine("Os veículos estacionados são:");
        _veiculos.ForEach(v => sb.AppendLine(v));
        return sb.ToString();
    }
}