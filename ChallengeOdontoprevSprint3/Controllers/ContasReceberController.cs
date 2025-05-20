using ChallengeOdontoprevSprint3.Model;
using ChallengeOdontoprevSprint3.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChallengeOdontoprevSprint3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContasReceberController : ControllerBase
    {
        private readonly IContasReceberRepository _IContasReceberRepository;
        private static int _id = 0; // Controla o ID

        public ContasReceberController(IContasReceberRepository IContasReceberRepository)
        {
            _IContasReceberRepository = IContasReceberRepository;
        }

        /// <summary>
        /// Retorna todas as contas a receber cadastradas.
        /// </summary>
        /// <returns>Lista de contas a receber.</returns>
        /// <response code="200">Listagem realizada com sucesso.</response>
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            return Ok(await _IContasReceberRepository.Listar());
        }

        /// <summary>
        /// Retorna uma conta a receber específica pelo ID.
        /// </summary>
        /// <param name="id">ID da conta a receber.</param>
        /// <returns>Dados da conta a receber.</returns>
        /// <response code="200">Conta encontrada com sucesso.</response>
        /// <response code="404">Conta não encontrada.</response>
        [HttpGet("{id}")]
        public async Task<ActionResult> ObterPorId(int id)
        {
            var contasreceber = await _IContasReceberRepository.ObterPorId(id);
            if (contasreceber == null)
            {
                return NotFound(new { message = "Contas a Receber não encontrada." });
            }
            return Ok(contasreceber);
        }

        /// <summary>
        /// Adiciona uma nova conta a receber ao sistema.
        /// </summary>
        /// <param name="contasreceber">Objeto com os dados da conta a receber.</param>
        /// <returns>Conta cadastrada com sucesso.</returns>
        /// <response code="200">Conta a receber cadastrada com sucesso.</response>
        /// <response code="400">Dados inválidos.</response>
        [HttpPost("adicionar")]
        public async Task<ActionResult> Adicionar([FromBody] ContasReceber contasreceber)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = "Dados inválidos." });
            }

            contasreceber.id_conta_receber = ++_id;
            await _IContasReceberRepository.Adcionar(contasreceber);

            return Ok(new { message = "contas a receber cadastrada!", data = contasreceber });
        }

        /// <summary>
        /// Atualiza os dados de uma conta a receber existente.
        /// </summary>
        /// <param name="id">ID da conta a receber.</param>
        /// <param name="contasreceber">Objeto com os dados atualizados.</param>
        /// <returns>Conta a receber atualizada.</returns>
        /// <response code="200">Conta atualizada com sucesso.</response>
        /// <response code="400">ID ou dados inválidos.</response>
        /// <response code="409">Erro de concorrência ao atualizar.</response>
        [HttpPut("atualizar/{id}")]
        public async Task<ActionResult> Atualizar(int id, [FromBody] ContasReceber contasreceber)
        {
            if (id != contasreceber.id_conta_receber)
            {
                return BadRequest(new { message = "O ID informado não corresponde a contas a receber." });
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = "Dados inválidos." });
            }

            try
            {
                await _IContasReceberRepository.Atualizar(contasreceber);
            }
            catch (DbUpdateConcurrencyException)
            {
                return Conflict(new { message = "Erro de concorrência ao atualizar a conta a receber." });
            }

            return Ok(new { message = "conta a receber atualizada!", data = contasreceber });
        }

        /// <summary>
        /// Exclui uma conta a receber do sistema com base no ID.
        /// </summary>
        /// <param name="id">ID da conta a receber.</param>
        /// <returns>Mensagem de sucesso.</returns>
        /// <response code="200">Conta excluída com sucesso.</response>
        /// <response code="404">Conta não encontrada.</response>
        [HttpDelete("excluir/{id}")]
        public async Task<ActionResult> Excluir(int id)
        {
            var contasreceber = await _IContasReceberRepository.ObterPorId(id);
            if (contasreceber == null)
            {
                return NotFound(new { message = "conta a receber não encontrada." });
            }

            await _IContasReceberRepository.Excluir(contasreceber);

            return Ok(new { message = "conta a receber excluída com sucesso!" });
        }
    }

}

