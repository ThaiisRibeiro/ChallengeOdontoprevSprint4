using ChallengeOdontoprevSprint3.Model;

namespace ChallengeOdontoprevSprint3.Repository.Interface
{
    public interface IClinicaRepository
    {
        Task Adcionar(Clinica Objeto);

        Task Atualizar(Clinica Objeto);

        Task Excluir(Clinica Objeto);

        Task<Clinica> ObterPorId(int Id);

        Task<List<Clinica>> Listar();
    }
}
