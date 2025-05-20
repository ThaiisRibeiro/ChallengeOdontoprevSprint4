using ChallengeOdontoprevSprint3.Data;
using ChallengeOdontoprevSprint3.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.DirectoryServices.ActiveDirectory;

namespace ChallengeOdontoprevSprint3.Repository
{
    public class RepositoryDentista : IDentistaRepository, IDisposable //nome da interface//
    {
        private DbContextOptions<Context> _OptionsBuilder;

        public RepositoryDentista()
        {
            _OptionsBuilder = new DbContextOptions<Context>();
        }
        public async Task Adcionar(Model.Dentista Objeto)
        {

            // throw new NotImplementedException();
            using (var banco = new Context(_OptionsBuilder))
            {
                banco.Set<Model.Dentista>().Add(Objeto);
                await banco.SaveChangesAsync();
            }
        }



        public async Task Atualizar(Model.Dentista Objeto)
        {
            using (var banco = new Context(_OptionsBuilder))
            {
                banco.Set<Model.Dentista>().Update(Objeto);
                await banco.SaveChangesAsync();
            }
        }



        public async Task Excluir(Model.Dentista Objeto)
        {
            using (var banco = new Context(_OptionsBuilder))
            {
                banco.Set<Model.Dentista>().Remove(Objeto);
                await banco.SaveChangesAsync();
            }
        }

        public async Task<List<Model.Dentista>> Listar()
        {
            using (var banco = new Context(_OptionsBuilder))
            {
                return await banco.Set<Model.Dentista>().AsNoTracking().ToListAsync();
            }
        }

        public async Task<Model.Dentista> ObterPorId(int Id)
        {
            using (var banco = new Context(_OptionsBuilder))
            {
                return await banco.Set<Model.Dentista>().FindAsync(Id);
            }
        }
        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }






    }
}
