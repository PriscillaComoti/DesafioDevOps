using System;
using ESG.InclusaoDiversidade.Models;
using ESG.InclusaoDiversidade.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ESG.InclusaoDiversidade.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CandidatoController : ControllerBase
    {
        private readonly ICandidatoRepository _repository;

        public CandidatoController(ICandidatoRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var candidatos = await _repository.BuscarTodosAsync(page, pageSize);
            return Ok(candidatos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var candidato = await _repository.BuscarPorIdAsync(id);
            if (candidato == null) return NotFound();
            return Ok(candidato);
        }

        [HttpGet("filtro")]
        public async Task<IActionResult> GetByFiltro(string? cargo, string? genero, string? etnia)
        {
            var candidatos = await _repository.BuscarPorFiltroAsync(cargo, genero, etnia);
            return Ok(candidatos);
        }

        [HttpPost]
        [Authorize] 
        public async Task<IActionResult> Criar([FromBody] BancoTalentosModel candidato)
        {
            var novo = await _repository.CriarAsync(candidato);
            return CreatedAtAction(nameof(GetById), new { id = novo.CandidatoID }, novo);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Atualizar(int id, [FromBody] BancoTalentosModel candidato)
        {
            if (id != candidato.CandidatoID)
                return BadRequest("ID não corresponde.");

            var atualizado = await _repository.AtualizarAsync(candidato);
            return Ok(atualizado);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Deletar(int id)
        {
            var sucesso = await _repository.DeletarAsync(id);
            if (!sucesso) return NotFound();
            return NoContent();
        }
    }
}

