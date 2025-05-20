using ChallengeOdontoprevSprint3.Data;
using ChallengeOdontoprevSprint3.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.DirectoryServices.ActiveDirectory;

namespace ChallengeOdontoprevSprint3.Repository
{
    public class RepositoryContasReceber : IContasReceberRepository, IDisposable //nome da interface//
    {
        private DbContextOptions<Context> _OptionsBuilder;

        public RepositoryContasReceber()
        {
            _OptionsBuilder = new DbContextOptions<Context>();
        }
        public async Task Adcionar(Model.ContasReceber Objeto)
        {

            // throw new NotImplementedException();
            using (var banco = new Context(_OptionsBuilder))
            {
                banco.Set<Model.ContasReceber>().Add(Objeto);
                await banco.SaveChangesAsync();
            }
        }



        public async Task Atualizar(Model.ContasReceber Objeto)
        {
            using (var banco = new Context(_OptionsBuilder))
            {
                banco.Set<Model.ContasReceber>().Update(Objeto);
                await banco.SaveChangesAsync();
            }
        }



        public async Task Excluir(Model.ContasReceber Objeto)
        {
            using (var banco = new Context(_OptionsBuilder))
            {
                banco.Set<Model.ContasReceber>().Remove(Objeto);
                await banco.SaveChangesAsync();
            }
        }

        public async Task<List<Model.ContasReceber>> Listar()
        {
            using (var banco = new Context(_OptionsBuilder))
            {
                return await banco.Set<Model.ContasReceber>().AsNoTracking().ToListAsync();
            }
        }

        public async Task<Model.ContasReceber> ObterPorId(int Id)
        {
            using (var banco = new Context(_OptionsBuilder))
            {
                return await banco.Set<Model.ContasReceber>().FindAsync(Id);
            }
        }
        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }






    }
}
