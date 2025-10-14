using System;
using ESG.InclusaoDiversidade.Data;
using ESG.InclusaoDiversidade.Models;
using ESG.InclusaoDiversidade.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ESG.InclusaoDiversidade.Repositories
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        private readonly ApplicationDbContext _context;

        public FuncionarioRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<FuncionarioModel>> BuscarTodosAsync(int pagina, int tamanho)
        {
            return await _context.Funcionarios
                .Include(f => f.Equipe)
                .Skip((pagina - 1) * tamanho)
                .Take(tamanho)
                .ToListAsync();
        }

        public async Task<int> ContarTotalAsync()
        {
            return await _context.Funcionarios.CountAsync();
        }

        public async Task<FuncionarioModel?> BuscarPorIdAsync(int id)
        {
            return await _context.Funcionarios
                .Include(f => f.Equipe)
                .FirstOrDefaultAsync(f => f.FuncionarioID == id);
        }

        public async Task<IEnumerable<FuncionarioModel>> BuscarPorFiltroAsync(string? genero, string? etnia, decimal? salarioMin)
        {
            var query = _context.Funcionarios.AsQueryable();

            if (!string.IsNullOrEmpty(genero))
                query = query.Where(f => f.Genero == genero);

            if (!string.IsNullOrEmpty(etnia))
                query = query.Where(f => f.Etnia == etnia);

            if (salarioMin.HasValue)
                query = query.Where(f => f.Salario >= salarioMin);

            return await query
                .Include(f => f.Equipe)
                .ToListAsync();
        }

        public async Task<IEnumerable<FuncionarioModel>> BuscarPorTreinamentoAsync(int treinamentoId)
        {
            return await _context.Participacoes
                .Where(p => p.TreinamentoID == treinamentoId)
                .Select(p => p.Funcionario!)
                .Include(f => f.Equipe)
                .ToListAsync();
        }

        public async Task<FuncionarioModel> CriarAsync(FuncionarioModel funcionario)
        {
            _context.Funcionarios.Add(funcionario);
            await _context.SaveChangesAsync();
            return funcionario;
        }

        public async Task<FuncionarioModel?> AtualizarAsync(FuncionarioModel funcionario)
        {
            var existente = await _context.Funcionarios.FindAsync(funcionario.FuncionarioID);
            if (existente == null) return null;

            _context.Entry(existente).CurrentValues.SetValues(funcionario);
            await _context.SaveChangesAsync();
            return existente;
        }

        public async Task<bool> ExcluirAsync(int id)
        {
            var funcionario = await _context.Funcionarios.FindAsync(id);
            if (funcionario == null) return false;

            _context.Funcionarios.Remove(funcionario);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

