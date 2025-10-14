using System;
using ESG.InclusaoDiversidade.Models;
using ESG.InclusaoDiversidade.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ESG.InclusaoDiversidade.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TreinamentoController : ControllerBase
    {
        private readonly ITreinamentoService _service;

        public TreinamentoController(ITreinamentoService service)
        {
            _service = service;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Criar([FromBody] TreinamentoModel treinamento)
        {
            var criado = await _service.CriarAsync(treinamento);
            return CreatedAtAction(nameof(GetParticipantes), new { id = criado.TreinamentoID }, criado);
        }

        [HttpGet("{id}/participantes")]
        public async Task<IActionResult> GetParticipantes(int id)
        {
            var participantes = await _service.BuscarParticipantesAsync(id);
            return Ok(participantes);
        }

        [HttpPost("{id}/participantes")]
        [Authorize]
        public async Task<IActionResult> AdicionarParticipante(int id, [FromBody] ParticipacaoTreinamentoModel participacao)
        {
            if (id != participacao.TreinamentoID)
                return BadRequest("ID do treinamento não confere com o corpo da requisição.");

            var resultado = await _service.AdicionarParticipacaoAsync(participacao);
            return resultado ? Ok("Participação registrada") : StatusCode(500, "Erro ao registrar participação.");
        }
    }
}

