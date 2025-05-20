using ChallengeOdontoprevSprint3.Model;

namespace ChallengeOdontoprevSprint3.Repository.Interface
{
    public interface IContasPagarRepository
    {
        Task Adcionar(ContasPagar Objeto);

        Task Atualizar(ContasPagar Objeto);

        Task Excluir(ContasPagar Objeto);

        Task<ContasPagar> ObterPorId(int Id);

        Task<List<ContasPagar>> Listar();
    }
}
