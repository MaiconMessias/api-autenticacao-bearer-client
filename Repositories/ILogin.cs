using System.Threading.Tasks;
using api_autenticacao_bearer_client.Models;
using Refit;

namespace api_autenticacao_bearer_client.Repositories
{
    public interface ILogin
    {
        [Post("/v1/obtertoken")]
        Task<string> GetTokenAsync(Usuario user);

    }
}