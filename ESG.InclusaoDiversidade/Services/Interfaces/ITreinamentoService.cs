using System;
using ESG.InclusaoDiversidade.Models;

namespace ESG.InclusaoDiversidade.Services.Interfaces
{
    public interface ITreinamentoService
    {
        Task<TreinamentoModel> CriarAsync(TreinamentoModel treinamento);
        Task<IEnumerable<FuncionarioModel>> BuscarParticipantesAsync(int treinamentoId);
        Task<bool> AdicionarParticipacaoAsync(ParticipacaoTreinamentoModel participacao);
    }
}
