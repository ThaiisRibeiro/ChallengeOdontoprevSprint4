using ChallengeOdontoprevSprint3.Model;
using ChallengeOdontoprevSprint3.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;



namespace ChallengeOdontoprevSprint3.Controllers
{
    

    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private readonly IPacienteRepository _IPacienteRepository;
        private static int _id = 0;

        public PacienteController(IPacienteRepository IPacienteRepository)
        {
            _IPacienteRepository = IPacienteRepository;
        }

        /// <summary>
        /// Retorna todos os pacientes cadastrados.
        /// </summary>
        /// <returns>Lista de pacientes.</returns>
        /// <response code="200">Retorna a lista de pacientes</response>
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            return Ok(await _IPacienteRepository.Listar());
        }

        /// <summary>
        /// Retorna os dados de um paciente específico pelo ID.
        /// </summary>
        /// <param name="id">ID do paciente</param>
        /// <returns>Dados do paciente</returns>
        /// <response code="200">Paciente encontrado</response>
        /// <response code="404">Paciente não encontrado</response>
        [HttpGet("{id}")]
        public async Task<ActionResult> ObterPorId(int id)
        {
            var paciente = await _IPacienteRepository.ObterPorId(id);
            if (paciente == null)
            {
                return NotFound(new { message = "Paciente não encontrado." });
            }
            return Ok(paciente);
        }

        /// <summary>
        /// Cadastra um novo paciente.
        /// </summary>
        /// <param name="paciente">Objeto paciente a ser cadastrado</param>
        /// <returns>Paciente cadastrado</returns>
        /// <response code="200">Paciente cadastrado com sucesso</response>
        /// <response code="400">Dados inválidos</response>
        /*  [HttpPost("adicionar")]
          public async Task<ActionResult> Adicionar([FromBody] Paciente paciente)
          {
              if (!ModelState.IsValid)
              {
                  return BadRequest(new { message = "Dados inválidos." });
              }
              using var httpClient = new HttpClient();
              var response = await httpClient.GetAsync($"https://viacep.com.br/ws/{paciente.cep}/json/");

              if (response.IsSuccessStatusCode)
              {
                  var json = await response.Content.ReadAsStringAsync();
                  var dadosCep = JsonSerializer.Deserialize<ViaCepResponse>(json);

                  if (dadosCep != null && !dadosCep.erro)
                  {
                      paciente.endereco = $"{dadosCep.logradouro}, {dadosCep.bairro}, {dadosCep.localidade} - {dadosCep.uf}";
                  }
              }

              paciente.id_paciente = ++_id;
              await _IPacienteRepository.Adcionar(paciente);

              return Ok(new { message = "Paciente cadastrado!", data = paciente });
          }
        */
        [HttpPost("adicionar")]
        public async Task<ActionResult> Adicionar([FromBody] Paciente paciente)
        {
            // Verificar se os dados enviados são válidos
            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = "Dados inválidos." });
            }

            // Realiza a consulta ao ViaCEP para obter os detalhes do endereço
            using var httpClient = new HttpClient();
            var response = await httpClient.GetAsync($"https://viacep.com.br/ws/{paciente.cep}/json/");

            // Se a requisição for bem-sucedida
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var dadosCep = JsonSerializer.Deserialize<ViaCepResponse>(json);

                // Se o CEP for válido (sem erro)
                if (dadosCep != null && !dadosCep.erro)
                {
                    // Monta o endereço completo utilizando os dados do ViaCEP
                    paciente.endereco = $"{dadosCep.logradouro}, {dadosCep.bairro}, {dadosCep.localidade} - {dadosCep.uf}";
                }
                else
                {
                    return BadRequest(new { message = "CEP inválido." });
                }
            }
            else
            {
                return BadRequest(new { message = "Erro ao consultar o CEP." });
            }

            // Incrementa o ID do paciente (caso não tenha sido passado) e salva no repositório
           // paciente.id_paciente = ++_id;
            await _IPacienteRepository.Adcionar(paciente);

            // Retorna uma resposta indicando que o paciente foi cadastrado com sucesso
            return Ok(new { message = "Paciente cadastrado!", data = paciente });
        }


        /// <summary>
        /// Atualiza os dados de um paciente existente.
        /// </summary>
        /// <param name="id">ID do paciente</param>
        /// <param name="paciente">Dados atualizados do paciente</param>
        /// <returns>Paciente atualizado</returns>
        /// <response code="200">Paciente atualizado com sucesso</response>
        /// <response code="400">ID inválido ou dados incorretos</response>
        /// <response code="409">Erro de concorrência</response>
        [HttpPut("atualizar/{id}")]
        public async Task<ActionResult> Atualizar(int id, [FromBody] Paciente paciente)
        {
            if (id != paciente.id_paciente)
            {
                return BadRequest(new { message = "O ID informado não corresponde ao Paciente." });
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = "Dados inválidos." });
            }

            try
            {
                await _IPacienteRepository.Atualizar(paciente);
            }
            catch (DbUpdateConcurrencyException)
            {
                return Conflict(new { message = "Erro de concorrência ao atualizar o Paciente." });
            }

            return Ok(new { message = "Paciente atualizado!", data = paciente });
        }

        /// <summary>
        /// Exclui um paciente pelo ID.
        /// </summary>
        /// <param name="id">ID do paciente</param>
        /// <returns>Status da exclusão</returns>
        /// <response code="200">Paciente excluído com sucesso</response>
        /// <response code="404">Paciente não encontrado</response>
        [HttpDelete("excluir/{id}")]
        public async Task<ActionResult> Excluir(int id)
        {
            var paciente = await _IPacienteRepository.ObterPorId(id);
            if (paciente == null)
            {
                return NotFound(new { message = "Paciente não encontrado." });
            }

            await _IPacienteRepository.Excluir(paciente);
            return Ok(new { message = "Paciente excluído com sucesso!" });
        }
    }

}
