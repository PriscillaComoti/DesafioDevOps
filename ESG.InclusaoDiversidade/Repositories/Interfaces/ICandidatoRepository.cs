using System;
using ESG.InclusaoDiversidade.Models;

namespace ESG.InclusaoDiversidade.Repositories.Interfaces
{
    public interface ICandidatoRepository
    {
        Task<IEnumerable<BancoTalentosModel>> BuscarTodosAsync(int page, int pageSize);
        Task<BancoTalentosModel> BuscarPorIdAsync(int id);
        Task<IEnumerable<BancoTalentosModel>> BuscarPorFiltroAsync(string cargo, string genero, string etnia);
        Task<BancoTalentosModel> CriarAsync(BancoTalentosModel candidato);
        Task<BancoTalentosModel> AtualizarAsync(BancoTalentosModel candidato);
        Task<bool> DeletarAsync(int id);
    }
}

