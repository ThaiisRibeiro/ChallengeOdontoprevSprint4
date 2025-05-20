
using ChallengeOdontoprevSprint3.Data;
using ChallengeOdontoprevSprint3.Repository.Interface;
using ChallengeOdontoprevSprint3.Repository;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ChallengeOdontoprevSprint3
{
    public class Program
    {
        public static void Main(string[] args)
        {
         


            var builder = WebApplication.CreateBuilder(args);

            var stringConexao = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=oracle.fiap.com.br)(PORT=1521))) (CONNECT_DATA=(SERVER=DEDICATED)(SID=ORCL)));User Id=Password=;";

            builder.Services.AddDbContext<Context>
                (options => options.UseOracle(stringConexao));

            //1
            builder.Services.AddSwaggerGen(c =>
            {
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });


            builder.Services.AddScoped<IPacienteRepository, RepositoryPaciente>();


            builder.Services.AddScoped<IAgendamentoRepository, RepositoryAgendamento>();
            builder.Services.AddScoped<IClinicaRepository, RepositoryClinica>();
            builder.Services.AddScoped<IContasPagarRepository, RepositoryContasPagar>();
            builder.Services.AddScoped<IContasReceberRepository, RepositoryContasReceber>();
            builder.Services.AddScoped<IDentistaRepository, RepositoryDentista>();
            builder.Services.AddScoped<IFraudeRepository, RepositoryFraude>();
            builder.Services.AddScoped<ITabelaPrecoRepository, RepositoryTabelaPreco>();

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
