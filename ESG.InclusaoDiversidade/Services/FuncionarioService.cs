using System;
using ESG.InclusaoDiversidade.Models;
using ESG.InclusaoDiversidade.Repositories.Interfaces;
using ESG.InclusaoDiversidade.Services.Interfaces;

namespace ESG.InclusaoDiversidade.Services
{
    public class FuncionarioService : IFuncionarioService
    {
        private readonly IFuncionarioRepository _repository;

        public FuncionarioService(IFuncionarioRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<FuncionarioModel>> ListarTodosAsync(int pagina, int tamanho)
        {
            return await _repository.BuscarTodosAsync(pagina, tamanho);
        }

        public async Task<int> ContarTotalAsync()
        {
            return await _repository.ContarTotalAsync();
        }

        public async Task<FuncionarioModel?> BuscarPorIdAsync(int id)
        {
            return await _repository.BuscarPorIdAsync(id);
        }

        public async Task<IEnumerable<FuncionarioModel>> FiltrarAsync(string? genero, string? etnia, decimal? salarioMin)
        {
            return await _repository.BuscarPorFiltroAsync(genero, etnia, salarioMin);
        }

        public async Task<IEnumerable<FuncionarioModel>> BuscarPorTreinamentoAsync(int treinamentoId)
        {
            return await _repository.BuscarPorTreinamentoAsync(treinamentoId);
        }

        public async Task<FuncionarioModel> CriarAsync(FuncionarioModel funcionario)
        {
            return await _repository.CriarAsync(funcionario);
        }

        public async Task<FuncionarioModel?> AtualizarAsync(FuncionarioModel funcionario)
        {
            return await _repository.AtualizarAsync(funcionario);
        }

        public async Task<bool> DeletarAsync(int id)
        {
            return await _repository.ExcluirAsync(id);
        }
    }
}
