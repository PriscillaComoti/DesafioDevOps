using System;
using ESG.InclusaoDiversidade.Data;
using ESG.InclusaoDiversidade.Models;
using ESG.InclusaoDiversidade.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ESG.InclusaoDiversidade.Repositories
{
    public class CandidatoRepository : ICandidatoRepository
    {
        private readonly ApplicationDbContext _context;

        public CandidatoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BancoTalentosModel>> BuscarTodosAsync(int page, int pageSize)
        {
            return await _context.Candidatos
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<BancoTalentosModel> BuscarPorIdAsync(int id)
        {
            return await _context.Candidatos.FindAsync(id);
        }

        public async Task<IEnumerable<BancoTalentosModel>> BuscarPorFiltroAsync(string cargo, string genero, string etnia)
        {
            return await _context.Candidatos
                .Where(c =>
                    (string.IsNullOrEmpty(cargo) || c.CargoPretendido == cargo) &&
                    (string.IsNullOrEmpty(genero) || c.Genero == genero) &&
                    (string.IsNullOrEmpty(etnia) || c.Etnia == etnia))
                .ToListAsync();
        }

        public async Task<BancoTalentosModel> CriarAsync(BancoTalentosModel candidato)
        {
            _context.Candidatos.Add(candidato);
            await _context.SaveChangesAsync();
            return candidato;
        }

        public async Task<BancoTalentosModel> AtualizarAsync(BancoTalentosModel candidato)
        {
            _context.Candidatos.Update(candidato);
            await _context.SaveChangesAsync();
            return candidato;
        }

        public async Task<bool> DeletarAsync(int id)
        {
            var candidato = await _context.Candidatos.FindAsync(id);
            if (candidato == null) return false;

            _context.Candidatos.Remove(candidato);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

