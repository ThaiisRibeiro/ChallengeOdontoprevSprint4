using ChallengeOdontoprevSprint3.Model;
using ChallengeOdontoprevSprint3.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChallengeOdontoprevSprint3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TabelaPrecoController : ControllerBase
    {
        private readonly ITabelaPrecoRepository _ITabelaPrecoRepository;
        private static int _id = 0; // Controla o ID

        public TabelaPrecoController(ITabelaPrecoRepository ITabelaPrecoRepository)
        {
            _ITabelaPrecoRepository = ITabelaPrecoRepository;
        }

        /// <summary>
        /// Retorna todas as Tabelas de Preço cadastradas.
        /// </summary>
        /// <returns>Lista de tabelas de preço.</returns>
        /// <response code="200">Listagem realizada com sucesso.</response>
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            return Ok(await _ITabelaPrecoRepository.Listar());
        }

        /// <summary>
        /// Retorna uma Tabela de Preço específica pelo ID.
        /// </summary>
        /// <param name="id">ID da tabela de preço.</param>
        /// <returns>Dados da tabela de preço.</returns>
        /// <response code="200">Tabela de Preço encontrada com sucesso.</response>
        /// <response code="404">Tabela de Preço não encontrada.</response>
        [HttpGet("{id}")]
        public async Task<ActionResult> ObterPorId(int id)
        {
            var tabelapreco = await _ITabelaPrecoRepository.ObterPorId(id);
            if (tabelapreco == null)
            {
                return NotFound(new { message = "Tabela Preco não encontrada." });
            }
            return Ok(tabelapreco);
        }

        /// <summary>
        /// Adiciona uma nova Tabela de Preço ao sistema.
        /// </summary>
        /// <param name="tabelapreco">Objeto com os dados da tabela de preço.</param>
        /// <returns>Tabela de preço cadastrada.</returns>
        /// <response code="200">Tabela de Preço cadastrada com sucesso.</response>
        /// <response code="400">Dados inválidos.</response>
        [HttpPost("adicionar")]
        public async Task<ActionResult> Adicionar([FromBody] TabelaPreco tabelapreco)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = "Dados inválidos." });
            }

            tabelapreco.id_tabela_preco = ++_id;
            await _ITabelaPrecoRepository.Adcionar(tabelapreco);

            return Ok(new { message = "Tabela Preco cadastrada!", data = tabelapreco });
        }

        /// <summary>
        /// Atualiza os dados de uma Tabela de Preço existente.
        /// </summary>
        /// <param name="id">ID da tabela de preço.</param>
        /// <param name="tabelapreco">Objeto com os dados atualizados.</param>
        /// <returns>Tabela de preço atualizada.</returns>
        /// <response code="200">Tabela de Preço atualizada com sucesso.</response>
        /// <response code="400">ID ou dados inválidos.</response>
        /// <response code="409">Erro de concorrência ao atualizar.</response>
        [HttpPut("atualizar/{id}")]
        public async Task<ActionResult> Atualizar(int id, [FromBody] TabelaPreco tabelapreco)
        {
            if (id != tabelapreco.id_tabela_preco)
            {
                return BadRequest(new { message = "O ID informado não corresponde o Paciente." });
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = "Dados inválidos." });
            }

            try
            {
                await _ITabelaPrecoRepository.Atualizar(tabelapreco);
            }
            catch (DbUpdateConcurrencyException)
            {
                return Conflict(new { message = "Erro de concorrência ao atualizar a Tabela Preco." });
            }

            return Ok(new { message = "tabela preco atualizada!", data = tabelapreco });
        }

        /// <summary>
        /// Exclui uma Tabela de Preço do sistema com base no ID.
        /// </summary>
        /// <param name="id">ID da tabela de preço.</param>
        /// <returns>Mensagem de sucesso.</returns>
        /// <response code="200">Tabela de Preço excluída com sucesso.</response>
        /// <response code="404">Tabela de Preço não encontrada.</response>
        [HttpDelete("excluir/{id}")]
        public async Task<ActionResult> Excluir(int id)
        {
            var tabelapreco = await _ITabelaPrecoRepository.ObterPorId(id);
            if (tabelapreco == null)
            {
                return NotFound(new { message = "tabela preco não encontrada." });
            }

            await _ITabelaPrecoRepository.Excluir(tabelapreco);

            return Ok(new { message = "tabela preco excluída com sucesso!" });
        }
    }

}

