using ChallengeOdontoprevSprint3.Model;

namespace ChallengeOdontoprevSprint3.Repository.Interface
{
    public interface IDentistaRepository
    {
        Task Adcionar(Dentista Objeto);

        Task Atualizar(Dentista Objeto);

        Task Excluir(Dentista Objeto);

        Task<Dentista> ObterPorId(int Id);

        Task<List<Dentista>> Listar();
    }
}
