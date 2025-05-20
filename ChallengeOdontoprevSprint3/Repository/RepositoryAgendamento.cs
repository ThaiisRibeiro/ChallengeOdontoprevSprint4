using ChallengeOdontoprevSprint3.Data;
using ChallengeOdontoprevSprint3.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.DirectoryServices.ActiveDirectory;

namespace ChallengeOdontoprevSprint3.Repository
{
    public class RepositoryAgendamento : IAgendamentoRepository, IDisposable //nome da interface//
    {

        private DbContextOptions<Context> _OptionsBuilder;

        public RepositoryAgendamento()
        {
            _OptionsBuilder = new DbContextOptions<Context>();
        }
        public async Task Adcionar(Model.Agendamento Objeto)
        {

            // throw new NotImplementedException();
            using (var banco = new Context(_OptionsBuilder))
            {
                banco.Set<Model.Agendamento>().Add(Objeto);
                await banco.SaveChangesAsync();
            }
        }



        public async Task Atualizar(Model.Agendamento Objeto)
        {
            using (var banco = new Context(_OptionsBuilder))
            {
                banco.Set<Model.Agendamento>().Update(Objeto);
                await banco.SaveChangesAsync();
            }
        }



        public async Task Excluir(Model.Agendamento Objeto)
        {
            using (var banco = new Context(_OptionsBuilder))
            {
                banco.Set<Model.Agendamento>().Remove(Objeto);
                await banco.SaveChangesAsync();
            }
        }

        public async Task<List<Model.Agendamento>> Listar()
        {
            using (var banco = new Context(_OptionsBuilder))
            {
                return await banco.Set<Model.Agendamento>().AsNoTracking().ToListAsync();
            }
        }

        public async Task<Model.Agendamento> ObterPorId(int Id)
        {
            using (var banco = new Context(_OptionsBuilder))
            {
                return await banco.Set<Model.Agendamento>().FindAsync(Id);
            }
        }


        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }






    }
}
