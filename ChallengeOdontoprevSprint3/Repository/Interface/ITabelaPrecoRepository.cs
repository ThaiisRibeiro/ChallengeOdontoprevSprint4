using ChallengeOdontoprevSprint3.Model;

namespace ChallengeOdontoprevSprint3.Repository.Interface
{
    public interface ITabelaPrecoRepository
    {
        Task Adcionar(TabelaPreco Objeto);

        Task Atualizar(TabelaPreco Objeto);

        Task Excluir(TabelaPreco Objeto);

        Task<TabelaPreco> ObterPorId(int Id);

        Task<List<TabelaPreco>> Listar();
    }
}
