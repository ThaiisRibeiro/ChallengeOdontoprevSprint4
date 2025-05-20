using ChallengeOdontoprevSprint3.Data;
using ChallengeOdontoprevSprint3.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.DirectoryServices.ActiveDirectory;

namespace ChallengeOdontoprevSprint3.Repository
{
    public class RepositoryTabelaPreco : ITabelaPrecoRepository, IDisposable //nome da interface//
    {
        private DbContextOptions<Context> _OptionsBuilder;

        public RepositoryTabelaPreco()
        {
            _OptionsBuilder = new DbContextOptions<Context>();
        }
        public async Task Adcionar(Model.TabelaPreco Objeto)
        {

            // throw new NotImplementedException();
            using (var banco = new Context(_OptionsBuilder))
            {
                banco.Set<Model.TabelaPreco>().Add(Objeto);
                await banco.SaveChangesAsync();
            }
        }



        public async Task Atualizar(Model.TabelaPreco Objeto)
        {
            using (var banco = new Context(_OptionsBuilder))
            {
                banco.Set<Model.TabelaPreco>().Update(Objeto);
                await banco.SaveChangesAsync();
            }
        }



        public async Task Excluir(Model.TabelaPreco Objeto)
        {
            using (var banco = new Context(_OptionsBuilder))
            {
                banco.Set<Model.TabelaPreco>().Remove(Objeto);
                await banco.SaveChangesAsync();
            }
        }

        public async Task<List<Model.TabelaPreco>> Listar()
        {
            using (var banco = new Context(_OptionsBuilder))
            {
                return await banco.Set<Model.TabelaPreco>().AsNoTracking().ToListAsync();
            }
        }

        public async Task<Model.TabelaPreco> ObterPorId(int Id)
        {
            using (var banco = new Context(_OptionsBuilder))
            {
                return await banco.Set<Model.TabelaPreco>().FindAsync(Id);
            }
        }
        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }






    }
}
