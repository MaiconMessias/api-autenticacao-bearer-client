using System.Threading.Tasks;
using Refit;

namespace api_autenticacao_bearer_client.Repositories
{
    public interface IPessoaAutenticada
    {
        [Get("/v1/autenticacao")]
        [Headers("Authorization: Bearer")]
        Task<string> TesteAutenticacao();
    }
}