using ChallengeOdontoprevSprint3.Data;
using ChallengeOdontoprevSprint3.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.DirectoryServices.ActiveDirectory;

namespace ChallengeOdontoprevSprint3.Repository
{
    public class RepositoryContasPagar : IContasPagarRepository, IDisposable //nome da interface//
    {
        private DbContextOptions<Context> _OptionsBuilder;

        public RepositoryContasPagar()
        {
            _OptionsBuilder = new DbContextOptions<Context>();
        }
        public async Task Adcionar(Model.ContasPagar Objeto)
        {

            // throw new NotImplementedException();
            using (var banco = new Context(_OptionsBuilder))
            {
                banco.Set<Model.ContasPagar>().Add(Objeto);
                await banco.SaveChangesAsync();
            }
        }



        public async Task Atualizar(Model.ContasPagar Objeto)
        {
            using (var banco = new Context(_OptionsBuilder))
            {
                banco.Set<Model.ContasPagar>().Update(Objeto);
                await banco.SaveChangesAsync();
            }
        }



        public async Task Excluir(Model.ContasPagar Objeto)
        {
            using (var banco = new Context(_OptionsBuilder))
            {
                banco.Set<Model.ContasPagar>().Remove(Objeto);
                await banco.SaveChangesAsync();
            }
        }

        public async Task<List<Model.ContasPagar>> Listar()
        {
            using (var banco = new Context(_OptionsBuilder))
            {
                return await banco.Set<Model.ContasPagar>().AsNoTracking().ToListAsync();
            }
        }

        public async Task<Model.ContasPagar> ObterPorId(int Id)
        {
            using (var banco = new Context(_OptionsBuilder))
            {
                return await banco.Set<Model.ContasPagar>().FindAsync(Id);
            }
        }
        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }






    }
}
