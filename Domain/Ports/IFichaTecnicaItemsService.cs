using Domain.Dtos;
using Domain.Model;

namespace Domain.Ports
{
    public interface IFichaTecnicaItemsService
    {
        Task<Response<FichaTecnicaItems>> Criar(FichaTecnicaItems entidade);
        Task<Response<FichaTecnicaItems>> Atualizar(FichaTecnicaItems entidade);
        Task<Response<FichaTecnicaItems>> Deletar(Guid id);
        Task<Response<FichaTecnicaItems>> ObterPorId(Guid id);
    }
}
