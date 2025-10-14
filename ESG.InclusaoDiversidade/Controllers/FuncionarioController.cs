using System;
using ESG.InclusaoDiversidade.Models;
using ESG.InclusaoDiversidade.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ESG.InclusaoDiversidade.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FuncionarioController : ControllerBase
    {
        private readonly IFuncionarioService _service;

        public FuncionarioController(IFuncionarioService service)
        {
            _service = service;
        }

        // GET
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FuncionarioModel>>> GetFuncionarios(
            [FromQuery] int pagina = 1,
            [FromQuery] int tamanho = 10)
        {
            var total = await _service.ContarTotalAsync();
            var funcionarios = await _service.ListarTodosAsync(pagina, tamanho);

            Response.Headers.Add("X-Total-Count", total.ToString());
            return Ok(funcionarios);
        }

        // GET
        [HttpGet("{id}")]
        public async Task<ActionResult<FuncionarioModel>> GetFuncionario(int id)
        {
            var funcionario = await _service.BuscarPorIdAsync(id);
            if (funcionario == null)
                return NotFound();
            return Ok(funcionario);
        }

        // GET: api/Funcionario/filtro?genero=Feminino&etnia=Negra&salarioMin=5000
        [HttpGet("filtro")]
        public async Task<ActionResult<IEnumerable<FuncionarioModel>>> FiltrarFuncionarios(
            [FromQuery] string? genero,
            [FromQuery] string? etnia,
            [FromQuery] decimal? salarioMin)
        {
            var resultado = await _service.FiltrarAsync(genero, etnia, salarioMin);
            return Ok(resultado);
        }

        // GET: api/Funcionario/por-treinamento/{treinamentoId}
        [HttpGet("por-treinamento/{treinamentoId}")]
        public async Task<ActionResult<IEnumerable<FuncionarioModel>>> GetPorTreinamento(int treinamentoId)
        {
            var funcionarios = await _service.BuscarPorTreinamentoAsync(treinamentoId);
            return Ok(funcionarios);
        }

        // POST: api/Funcionario
        [HttpPost]
        [Authorize] 
        public async Task<ActionResult<FuncionarioModel>> PostFuncionario([FromBody] FuncionarioModel funcionario)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var criado = await _service.CriarAsync(funcionario);
            return CreatedAtAction(nameof(GetFuncionario), new { id = criado.FuncionarioID }, criado);
        }

        // PUT: api/Funcionario/{id}
        [HttpPut("{id}")]
        [Authorize] 
        public async Task<ActionResult> PutFuncionario(int id, [FromBody] FuncionarioModel funcionario)
        {
            if (id != funcionario.FuncionarioID)
                return BadRequest("ID inconsistente");

            var atualizado = await _service.AtualizarAsync(funcionario);
            if (atualizado == null)
                return NotFound();

            return Ok(atualizado);
        }

        // DELETE: api/Funcionario/{id}
        [HttpDelete("{id}")]
        [Authorize] 
        public async Task<ActionResult> DeleteFuncionario(int id)
        {
            var sucesso = await _service.DeletarAsync(id);
            if (!sucesso)
                return NotFound();

            return NoContent();
        }
    }
}

