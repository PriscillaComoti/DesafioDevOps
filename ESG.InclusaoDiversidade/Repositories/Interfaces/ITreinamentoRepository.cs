using System;
using ESG.InclusaoDiversidade.Models;

namespace ESG.InclusaoDiversidade.Repositories.Interfaces
{
    public interface ITreinamentoRepository
    {
        Task<TreinamentoModel> CriarAsync(TreinamentoModel treinamento);
        Task<TreinamentoModel?> BuscarPorIdAsync(int id);
        Task<IEnumerable<FuncionarioModel>> ListarParticipantesAsync(int treinamentoId);
        Task<bool> AdicionarParticipacaoAsync(ParticipacaoTreinamentoModel participacao);
    }
}

