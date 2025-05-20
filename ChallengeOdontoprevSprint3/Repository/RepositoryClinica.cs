using ChallengeOdontoprevSprint3.Data;
using ChallengeOdontoprevSprint3.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.DirectoryServices.ActiveDirectory;

namespace ChallengeOdontoprevSprint3.Repository
{
    public class RepositoryClinica : IClinicaRepository, IDisposable //nome da interface//
    {
        private DbContextOptions<Context> _OptionsBuilder;

        public RepositoryClinica()
        {
            _OptionsBuilder = new DbContextOptions<Context>();
        }
        public async Task Adcionar(Model.Clinica Objeto)
        {

            // throw new NotImplementedException();
            using (var banco = new Context(_OptionsBuilder))
            {
                banco.Set<Model.Clinica>().Add(Objeto);
                await banco.SaveChangesAsync();
            }
        }



        public async Task Atualizar(Model.Clinica Objeto)
        {
            using (var banco = new Context(_OptionsBuilder))
            {
                banco.Set<Model.Clinica>().Update(Objeto);
                await banco.SaveChangesAsync();
            }
        }



        public async Task Excluir(Model.Clinica Objeto)
        {
            using (var banco = new Context(_OptionsBuilder))
            {
                banco.Set<Model.Clinica>().Remove(Objeto);
                await banco.SaveChangesAsync();
            }
        }

        public async Task<List<Model.Clinica>> Listar()
        {
            using (var banco = new Context(_OptionsBuilder))
            {
                return await banco.Set<Model.Clinica>().AsNoTracking().ToListAsync();
            }
        }

        public async Task<Model.Clinica> ObterPorId(int Id)
        {
            using (var banco = new Context(_OptionsBuilder))
            {
                return await banco.Set<Model.Clinica>().FindAsync(Id);
            }
        }
        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }






    }
}
