using ChallengeOdontoprevSprint3.Model;

namespace ChallengeOdontoprevSprint3.Repository.Interface
{
    public interface IFraudeRepository
    {
        Task Adcionar(Fraude Objeto);

        Task Atualizar(Fraude Objeto);

        Task Excluir(Fraude Objeto);

        Task<Fraude> ObterPorId(int Id);

        Task<List<Fraude>> Listar();
    }
}
