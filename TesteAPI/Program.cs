using Refit;
using System;
using System.Threading.Tasks;

namespace TesteAPI
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            { 
                var cepClient = RestService.For<ICepApiService>("http://viacep.com.br");
                Console.WriteLine("Informe seu cep: ");
                string cepInformado = Console.ReadLine().ToString();
                Console.WriteLine("Consultando informações do CEP: " + cepInformado);

                var address = await cepClient.GetAddressAsync(cepInformado);

                Console.WriteLine($"\nLougradouro: {address.Logradouro} \nBairro:{address.Bairro} \nCidade: {address.Localidade}");
                Console.ReadKey();
            }
            catch(Exception e)
            {
                Console.WriteLine("Erro na consulta de cep: " + e.Message);
            }
        }
    }
}
