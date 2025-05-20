using ChallengeOdontoprevSprint3.Model;

namespace ChallengeOdontoprevSprint3.Repository.Interface
{
    public interface IContasReceberRepository
    {
        Task Adcionar(ContasReceber Objeto);

        Task Atualizar(ContasReceber Objeto);

        Task Excluir(ContasReceber Objeto);

        Task<ContasReceber> ObterPorId(int Id);

        Task<List<ContasReceber>> Listar();
    }
}
