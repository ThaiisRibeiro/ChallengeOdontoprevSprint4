using ChallengeOdontoprevSprint3.Data;
using ChallengeOdontoprevSprint3.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.DirectoryServices.ActiveDirectory;

namespace ChallengeOdontoprevSprint3.Repository
{
    public class RepositoryPaciente : IPacienteRepository, IDisposable //nome da interface//
    {
        private DbContextOptions<Context> _OptionsBuilder;

        public RepositoryPaciente()
        {
            _OptionsBuilder = new DbContextOptions<Context>();
        }
        public async Task Adcionar(Model.Paciente Objeto)
        {

            // throw new NotImplementedException();
            using (var banco = new Context(_OptionsBuilder))
            {
                banco.Set<Model.Paciente>().Add(Objeto);
                await banco.SaveChangesAsync();
            }
        }



        public async Task Atualizar(Model.Paciente Objeto)
        {
            using (var banco = new Context(_OptionsBuilder))
            {
                banco.Set<Model.Paciente>().Update(Objeto);
                await banco.SaveChangesAsync();
            }
        }



        public async Task Excluir(Model.Paciente Objeto)
        {
            using (var banco = new Context(_OptionsBuilder))
            {
                banco.Set<Model.Paciente>().Remove(Objeto);
                await banco.SaveChangesAsync();
            }
        }

        public async Task<List<Model.Paciente>> Listar()
        {
            using (var banco = new Context(_OptionsBuilder))
            {
                return await banco.Set<Model.Paciente>().AsNoTracking().ToListAsync();
            }
        }

        public async Task<Model.Paciente> ObterPorId(int Id)
        {
            using (var banco = new Context(_OptionsBuilder))
            {
                return await banco.Set<Model.Paciente>().FindAsync(Id);
            }
        }



        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }






    }
}
