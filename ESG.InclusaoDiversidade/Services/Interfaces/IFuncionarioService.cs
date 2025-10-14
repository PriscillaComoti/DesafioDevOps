using System;
using ESG.InclusaoDiversidade.Models;

namespace ESG.InclusaoDiversidade.Services.Interfaces
{
    public interface IFuncionarioService
    {
        Task<IEnumerable<FuncionarioModel>> ListarTodosAsync(int pagina, int tamanho);
        Task<int> ContarTotalAsync();
        Task<FuncionarioModel?> BuscarPorIdAsync(int id);
        Task<IEnumerable<FuncionarioModel>> FiltrarAsync(string? genero, string? etnia, decimal? salarioMin);
        Task<IEnumerable<FuncionarioModel>> BuscarPorTreinamentoAsync(int treinamentoId);
        Task<FuncionarioModel> CriarAsync(FuncionarioModel funcionario);
        Task<FuncionarioModel?> AtualizarAsync(FuncionarioModel funcionario);
        Task<bool> DeletarAsync(int id);
    }
}
