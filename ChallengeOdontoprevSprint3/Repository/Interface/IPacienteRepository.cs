using ChallengeOdontoprevSprint3.Model;

namespace ChallengeOdontoprevSprint3.Repository.Interface
{
    public interface IPacienteRepository
    {
        Task Adcionar(Paciente Objeto);

        Task Atualizar(Paciente Objeto);

        Task Excluir(Paciente Objeto);

        Task<Paciente> ObterPorId(int Id);

        Task<List<Paciente>> Listar();
    }
}
