using System.Linq.Expressions;
using Domain.Dtos;
using Domain.Ports;


namespace Business.Services
{
    public class Service<T> : IService<T> where T : class
    {
        protected readonly IRepository<T> _repository;
        protected readonly IUnitOfWork _unitOfWork;

        public Service(IRepository<T> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public virtual async Task<Response<T>> ObterPorIdAsync(Guid id)
        {
            return await _repository.ObterPorIdAsync(id);
        }

        public virtual async Task<ListResponse<T>> ObterPaginadoAsync(
            Expression<Func<T, bool>>? predicado = null, 
            string? filter = null, 
            int? limit = null, 
            int? offset = null)
        {
            return await _repository.ObterPaginadoAsync(filter, limit, offset);
        }

        public virtual async Task<Response<T>> AdicionarAsync(T entidade)
        {
           
            var repoResponse = await _repository.AdicionarAsync(entidade);
            
            if (!repoResponse.Success)
                return repoResponse;

            var commitResponse = await _unitOfWork.CommitAsync();

            if (!commitResponse.Success)
                return Response<T>.Fail($"Erro ao salvar no banco: {commitResponse.Message}");

            return Response<T>.Ok(entidade);
        }

        public virtual async Task<Response<T>> AtualizarAsync(Guid id, T entidade)
        {   
            _repository.Atualizar(entidade);

            var commitResponse = await _unitOfWork.CommitAsync();

            if (!commitResponse.Success)
                return Response<T>.Fail($"Erro ao atualizar no banco: {commitResponse.Message}");

            return Response<T>.Ok(entidade);
        }

        public virtual async Task<Response<bool>> RemoverAsync(Guid id)
        {
            var buscaResponse = await _repository.ObterPorIdAsync(id);
            
            if (!buscaResponse.Success)
                return Response<bool>.Fail("Registro não encontrado para exclusão.");

            _repository.Remover(buscaResponse.Data);

            var commitResponse = await _unitOfWork.CommitAsync();

            if (!commitResponse.Success)
                return Response<bool>.Fail($"Erro ao excluir no banco: {commitResponse.Message}");

            return Response<bool>.Ok(true);
        }
    }
}