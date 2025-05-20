using ChallengeOdontoprevSprint3.Model;
using ChallengeOdontoprevSprint3.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChallengeOdontoprevSprint3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContasPagarController : ControllerBase
    {
        private readonly IContasPagarRepository _IContasPagarRepository;
        private static int _id = 0; // Controla o ID

        public ContasPagarController(IContasPagarRepository IContasPagarRepository)
        {
            _IContasPagarRepository = IContasPagarRepository;
        }

        /// <summary>
        /// Retorna todas as contas a pagar cadastradas.
        /// </summary>
        /// <returns>Lista de contas a pagar.</returns>
        /// <response code="200">Listagem realizada com sucesso.</response>
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            return Ok(await _IContasPagarRepository.Listar());
        }

        /// <summary>
        /// Retorna uma conta a pagar específica pelo ID.
        /// </summary>
        /// <param name="id">ID da conta a pagar.</param>
        /// <returns>Dados da conta a pagar.</returns>
        /// <response code="200">Conta encontrada com sucesso.</response>
        /// <response code="404">Conta não encontrada.</response>
        [HttpGet("{id}")]
        public async Task<ActionResult> ObterPorId(int id)
        {
            var contaspagar = await _IContasPagarRepository.ObterPorId(id);
            if (contaspagar == null)
            {
                return NotFound(new { message = "Contas a Pagar não encontrada." });
            }
            return Ok(contaspagar);
        }

        /// <summary>
        /// Adiciona uma nova conta a pagar ao sistema.
        /// </summary>
        /// <param name="contaspagar">Objeto com os dados da conta a pagar.</param>
        /// <returns>Conta cadastrada com sucesso.</returns>
        /// <response code="200">Conta a pagar cadastrada com sucesso.</response>
        /// <response code="400">Dados inválidos.</response>
        [HttpPost("adicionar")]
        public async Task<ActionResult> Adicionar([FromBody] ContasPagar contaspagar)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = "Dados inválidos." });
            }

            contaspagar.id_conta_pagar = ++_id;
            await _IContasPagarRepository.Adcionar(contaspagar);

            return Ok(new { message = "contas a pagar cadastrada!", data = contaspagar });
        }

        /// <summary>
        /// Atualiza os dados de uma conta a pagar existente.
        /// </summary>
        /// <param name="id">ID da conta a pagar.</param>
        /// <param name="contaspagar">Objeto com os dados atualizados.</param>
        /// <returns>Conta a pagar atualizada.</returns>
        /// <response code="200">Conta atualizada com sucesso.</response>
        /// <response code="400">ID ou dados inválidos.</response>
        /// <response code="409">Erro de concorrência ao atualizar.</response>
        [HttpPut("atualizar/{id}")]
        public async Task<ActionResult> Atualizar(int id, [FromBody] ContasPagar contaspagar)
        {
            if (id != contaspagar.id_conta_pagar)
            {
                return BadRequest(new { message = "O ID informado não corresponde a contas a pagar." });
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = "Dados inválidos." });
            }

            try
            {
                await _IContasPagarRepository.Atualizar(contaspagar);
            }
            catch (DbUpdateConcurrencyException)
            {
                return Conflict(new { message = "Erro de concorrência ao atualizar a conta a pagar." });
            }

            return Ok(new { message = "conta a pagar atualizada!", data = contaspagar });
        }

        /// <summary>
        /// Exclui uma conta a pagar do sistema com base no ID.
        /// </summary>
        /// <param name="id">ID da conta a pagar.</param>
        /// <returns>Mensagem de sucesso.</returns>
        /// <response code="200">Conta excluída com sucesso.</response>
        /// <response code="404">Conta não encontrada.</response>
        [HttpDelete("excluir/{id}")]
        public async Task<ActionResult> Excluir(int id)
        {
            var contaspagar = await _IContasPagarRepository.ObterPorId(id);
            if (contaspagar == null)
            {
                return NotFound(new { message = "conta a pagar não encontrada." });
            }

            await _IContasPagarRepository.Excluir(contaspagar);

            return Ok(new { message = "conta a pagar excluída com sucesso!" });
        }
    }

}

