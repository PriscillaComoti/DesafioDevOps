using System;
using ESG.InclusaoDiversidade.Models;
using ESG.InclusaoDiversidade.Repositories.Interfaces;
using ESG.InclusaoDiversidade.Services.Interfaces;

namespace ESG.InclusaoDiversidade.Services
{
    public class TreinamentoService : ITreinamentoService
    {
        private readonly ITreinamentoRepository _repository;

        public TreinamentoService(ITreinamentoRepository repository)
        {
            _repository = repository;
        }

        public async Task<TreinamentoModel> CriarAsync(TreinamentoModel treinamento)
        {
            return await _repository.CriarAsync(treinamento);
        }

        public async Task<IEnumerable<FuncionarioModel>> BuscarParticipantesAsync(int treinamentoId)
        {
            return await _repository.ListarParticipantesAsync(treinamentoId);
        }

        public async Task<bool> AdicionarParticipacaoAsync(ParticipacaoTreinamentoModel participacao)
        {
            return await _repository.AdicionarParticipacaoAsync(participacao);
        }
    }
}
