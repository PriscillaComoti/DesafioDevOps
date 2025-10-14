using System;
using ESG.InclusaoDiversidade.Data;
using ESG.InclusaoDiversidade.Models;
using ESG.InclusaoDiversidade.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ESG.InclusaoDiversidade.Repositories
{
    public class TreinamentoRepository : ITreinamentoRepository
    {
        private readonly ApplicationDbContext _context;

        public TreinamentoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<TreinamentoModel> CriarAsync(TreinamentoModel treinamento)
        {
            _context.Treinamentos.Add(treinamento);
            await _context.SaveChangesAsync();
            return treinamento;
        }

        public async Task<TreinamentoModel?> BuscarPorIdAsync(int id)
        {
            return await _context.Treinamentos.FindAsync(id);
        }

        public async Task<IEnumerable<FuncionarioModel>> ListarParticipantesAsync(int treinamentoId)
        {
            return await _context.Participacoes
                .Include(p => p.Funcionario)
                .Where(p => p.TreinamentoID == treinamentoId)
                .Select(p => p.Funcionario!)
                .ToListAsync();
        }

        public async Task<bool> AdicionarParticipacaoAsync(ParticipacaoTreinamentoModel participacao)
        {
            _context.Participacoes.Add(participacao);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
