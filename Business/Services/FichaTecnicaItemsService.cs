using Domain.Dtos;
using Domain.Model;
using Domain.Ports;

namespace Business.Services
{
    public class FichaTecnicaItemsService : IFichaTecnicaItemsService
    {
        private readonly IRepository<FichaTecnicaItems> _repository;
        private readonly IRepository<FichaTecnica> _fichaTecnicaRepository;
        private readonly IRepository<ProdutoDomain> _produtoRepository;
        private readonly IRepository<UnidadeMedidaDomain> _unidadeMedidaRepository;
        private readonly IUnitOfWork _unitOfWork;

        public FichaTecnicaItemsService(
            IRepository<FichaTecnicaItems> repository,
            IRepository<FichaTecnica> fichaTecnicaRepository,
            IRepository<ProdutoDomain> produtoRepository,
            IRepository<UnidadeMedidaDomain> unidadeMedidaRepository,
            IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _fichaTecnicaRepository = fichaTecnicaRepository;
            _produtoRepository = produtoRepository;
            _unidadeMedidaRepository = unidadeMedidaRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<FichaTecnicaItems>> Criar(FichaTecnicaItems entidade)
        {
            var validation = await ValidateReferences(entidade);
            if (!validation.Success)
                return Response<FichaTecnicaItems>.Fail(validation.Message);

            var duplicated = await _repository.ObterPaginadoAsync($"FichaTecnicaId:{entidade.FichaTecnicaId}", limit: 200, offset: 0);
            var duplicatedItem = duplicated.Data.FirstOrDefault(i => i.ProdutoId == entidade.ProdutoId);
            if (duplicatedItem != null)
                return Response<FichaTecnicaItems>.Fail("Este produto já foi adicionado na ficha técnica");

            var result = await _repository.AdicionarAsync(new FichaTecnicaItems
            {
                FichaTecnicaId = entidade.FichaTecnicaId,
                ProdutoId = entidade.ProdutoId,
                UnidadeMedidaId = entidade.UnidadeMedidaId,
                Quantidade = entidade.Quantidade
            });

            var commit = await _unitOfWork.CommitAsync();
            if (!commit.Success)
                return Response<FichaTecnicaItems>.Fail(commit.Message);

            return Response<FichaTecnicaItems>.Ok(result.Data);
        }

        public async Task<Response<FichaTecnicaItems>> Atualizar(FichaTecnicaItems entidade)
        {
            var currentResponse = await _repository.ObterPorIdAsync(entidade.Id);
            if (!currentResponse.Success)
                return Response<FichaTecnicaItems>.Fail("Item da ficha técnica não encontrado");

            var current = currentResponse.Data;
            if (current == null)
                return Response<FichaTecnicaItems>.Fail("Item da ficha técnica não encontrado");

            var validation = await ValidateReferences(entidade);
            if (!validation.Success)
                return Response<FichaTecnicaItems>.Fail(validation.Message);

            var duplicated = await _repository.ObterPaginadoAsync($"FichaTecnicaId:{entidade.FichaTecnicaId}", limit: 200, offset: 0);
            var duplicatedItem = duplicated.Data.FirstOrDefault(i => i.ProdutoId == entidade.ProdutoId && i.Id != entidade.Id);
            if (duplicatedItem != null)
                return Response<FichaTecnicaItems>.Fail("Este produto já foi adicionado na ficha técnica");

            current.FichaTecnicaId = entidade.FichaTecnicaId;
            current.ProdutoId = entidade.ProdutoId;
            current.UnidadeMedidaId = entidade.UnidadeMedidaId;
            current.Quantidade = entidade.Quantidade;

            _repository.Atualizar(current);

            var commit = await _unitOfWork.CommitAsync();
            if (!commit.Success)
                return Response<FichaTecnicaItems>.Fail(commit.Message);

            return Response<FichaTecnicaItems>.Ok(current);
        }

        public async Task<Response<FichaTecnicaItems>> Deletar(Guid id)
        {
            var currentResponse = await _repository.ObterPorIdAsync(id);
            if (!currentResponse.Success)
                return Response<FichaTecnicaItems>.Fail("Item da ficha técnica não encontrado");

            var current = currentResponse.Data;
            if (current == null)
                return Response<FichaTecnicaItems>.Fail("Item da ficha técnica não encontrado");

            _repository.Remover(current);
            var commit = await _unitOfWork.CommitAsync();

            if (!commit.Success)
                return Response<FichaTecnicaItems>.Fail(commit.Message);

            return Response<FichaTecnicaItems>.Ok(current);
        }

        public async Task<Response<FichaTecnicaItems>> ObterPorId(Guid id)
        {
            var response = await _repository.ObterPorIdAsync(id);
            if (!response.Success || response.Data == null)
                return Response<FichaTecnicaItems>.Fail("Item da ficha técnica não encontrado");

            return Response<FichaTecnicaItems>.Ok(response.Data);
        }

        private async Task<Response<bool>> ValidateReferences(FichaTecnicaItems entidade)
        {
            if (entidade.Quantidade <= 0)
                return Response<bool>.Fail("Quantidade deve ser maior que zero");

            var fichaResponse = await _fichaTecnicaRepository.ObterPorIdAsync(entidade.FichaTecnicaId);
            if (!fichaResponse.Success)
                return Response<bool>.Fail("Ficha técnica não encontrada");

            var produtoResponse = await _produtoRepository.ObterPorIdAsync(entidade.ProdutoId);
            if (!produtoResponse.Success)
                return Response<bool>.Fail("Produto não encontrado");

            var unidadeResponse = await _unidadeMedidaRepository.ObterPorIdAsync(entidade.UnidadeMedidaId);
            if (!unidadeResponse.Success)
                return Response<bool>.Fail("Unidade de medida não encontrada");

            return Response<bool>.Ok(true);
        }
    }
}
