using System;
using ESG.InclusaoDiversidade.Models;

namespace ESG.InclusaoDiversidade.Repositories.Interfaces
{
    public interface IFuncionarioRepository
    {
        Task<IEnumerable<FuncionarioModel>> BuscarTodosAsync(int pagina, int tamanho);
        Task<FuncionarioModel?> BuscarPorIdAsync(int id);
        Task<IEnumerable<FuncionarioModel>> BuscarPorFiltroAsync(string? genero, string? etnia, decimal? salarioMin);
        Task<IEnumerable<FuncionarioModel>> BuscarPorTreinamentoAsync(int treinamentoId);
        Task<FuncionarioModel> CriarAsync(FuncionarioModel funcionario);
        Task<FuncionarioModel?> AtualizarAsync(FuncionarioModel funcionario);
        Task<bool> ExcluirAsync(int id);
        Task<int> ContarTotalAsync();
    }
}

