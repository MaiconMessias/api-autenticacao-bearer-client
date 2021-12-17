using System;
using System.Threading.Tasks;
using api_autenticacao_bearer_client.Models;
using api_autenticacao_bearer_client.Repositories;
using Refit;

namespace api_autenticacao_bearer_client
{
    class Program
    {
        static async Task Main(string[] args)
        {
            
            string url = "https://localhost:5001";

            // obtem o token na API
            var loginAPI = RestService.For<ILogin>(url);
            var user = new Usuario()
            {
                Username = "admin",
                Password = "admin",
                Token = ""
            };

            var token = await loginAPI.GetTokenAsync(user);
            // armazena o token válido por duas horas 
            user.Token = token;
            Console.WriteLine($"Token Gerado:\n {token}");

            // acessando método com autenticação
            var pessoaAPI = RestService.For<IPessoaAutenticada>(url,
                    new RefitSettings()
                    {
                        AuthorizationHeaderValueGetter = () =>
                            Task.FromResult(token)
                    });
            
            string resposta = await pessoaAPI.TesteAutenticacao();
            Console.WriteLine($"\n\n************\nResposta: {resposta}");
        }
    }
}
