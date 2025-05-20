using ChallengeOdontoprevSprint3.Model;

namespace ChallengeOdontoprevSprint3.Repository.Interface
{
    public interface IAgendamentoRepository
    {
        Task Adcionar(Agendamento Objeto);

        Task Atualizar(Agendamento Objeto);

        Task Excluir(Agendamento Objeto);

        Task<Agendamento> ObterPorId(int Id);

        Task<List<Agendamento>> Listar();
    }
}
