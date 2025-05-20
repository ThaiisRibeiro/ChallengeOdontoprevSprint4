using ChallengeOdontoprevSprint3.Model;
using ChallengeOdontoprevSprint3.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChallengeOdontoprevSprint3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FraudeController : ControllerBase
    {
        private readonly IFraudeRepository _IFraudeRepository;
        private static int _id = 0;

        public FraudeController(IFraudeRepository IFraudeRepository)
        {
            _IFraudeRepository = IFraudeRepository;
        }

        /// <summary>
        /// Retorna todas as fraudes cadastradas no sistema.
        /// </summary>
        /// <returns>Lista de fraudes.</returns>
        /// <response code="200">Fraudes retornadas com sucesso.</response>
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            return Ok(await _IFraudeRepository.Listar());
        }

        /// <summary>
        /// Retorna uma fraude específica pelo ID.
        /// </summary>
        /// <param name="id">ID da fraude.</param>
        /// <returns>Dados da fraude.</returns>
        /// <response code="200">Fraude encontrada com sucesso.</response>
        /// <response code="404">Fraude não encontrada.</response>
        [HttpGet("{id}")]
        public async Task<ActionResult> ObterPorId(int id)
        {
            var fraude = await _IFraudeRepository.ObterPorId(id);
            if (fraude == null)
            {
                return NotFound(new { message = "Fraude não encontrada." });
            }
            return Ok(fraude);
        }

        /// <summary>
        /// Adiciona uma nova fraude ao sistema.
        /// </summary>
        /// <param name="fraude">Objeto contendo os dados da fraude.</param>
        /// <returns>Fraude cadastrada.</returns>
        /// <response code="200">Fraude cadastrada com sucesso.</response>
        /// <response code="400">Dados inválidos.</response>
        [HttpPost("adicionar")]
        public async Task<ActionResult> Adicionar([FromBody] Fraude fraude)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = "Dados inválidos." });
            }

            fraude.id_fraude = ++_id;
            await _IFraudeRepository.Adcionar(fraude);

            return Ok(new { message = "Fraude cadastrada!", data = fraude });
        }

        /// <summary>
        /// Atualiza os dados de uma fraude existente.
        /// </summary>
        /// <param name="id">ID da fraude.</param>
        /// <param name="fraude">Objeto contendo os novos dados da fraude.</param>
        /// <returns>Fraude atualizada.</returns>
        /// <response code="200">Fraude atualizada com sucesso.</response>
        /// <response code="400">ID inválido ou dados incorretos.</response>
        /// <response code="409">Erro de concorrência ao atualizar a fraude.</response>
        [HttpPut("atualizar/{id}")]
        public async Task<ActionResult> Atualizar(int id, [FromBody] Fraude fraude)
        {
            if (id != fraude.id_fraude)
            {
                return BadRequest(new { message = "O ID informado não corresponde a Fraude." });
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = "Dados inválidos." });
            }

            try
            {
                await _IFraudeRepository.Atualizar(fraude);
            }
            catch (DbUpdateConcurrencyException)
            {
                return Conflict(new { message = "Erro de concorrência ao atualizar a Fraude." });
            }

            return Ok(new { message = "fraude atualizada!", data = fraude });
        }

        /// <summary>
        /// Exclui uma fraude do sistema com base no ID.
        /// </summary>
        /// <param name="id">ID da fraude.</param>
        /// <returns>Mensagem de sucesso.</returns>
        /// <response code="200">Fraude excluída com sucesso.</response>
        /// <response code="404">Fraude não encontrada.</response>
        [HttpDelete("excluir/{id}")]
        public async Task<ActionResult> Excluir(int id)
        {
            var fraude = await _IFraudeRepository.ObterPorId(id);
            if (fraude == null)
            {
                return NotFound(new { message = "fraude não encontrada." });
            }

            await _IFraudeRepository.Excluir(fraude);

            return Ok(new { message = "fraude excluída com sucesso!" });
        }
    }

}


