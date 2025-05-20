using ChallengeOdontoprevSprint3.Model;
using Microsoft.EntityFrameworkCore;

namespace ChallengeOdontoprevSprint3.Data
{
   
       public class Context : DbContext
        {
            public Context(DbContextOptions<Context> options) : base(options)


            {
                //          Database.EnsureCreated();
            }
            public DbSet<Paciente> Api_Dotnet_Pacientes { set; get; }
            public DbSet<Dentista> Api_Dotnet_Dentistas { set; get; }
            public DbSet<Clinica> Api_Dotnet_Clinicas { set; get; }
            public DbSet<Agendamento> Api_Dotnet_Agendamentos { set; get; }
            public DbSet<TabelaPreco> Api_Dotnet_Tabela_Precos { set; get; }
            public DbSet<ContasReceber> Api_Dotnet_Contas_Receber { set; get; }
            public DbSet<ContasPagar> Api_Dotnet_Contas_Pagar { set; get; }
            public DbSet<Fraude> Api_Dotnet_Fraudes { set; get; }



            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                // Se não estiver configurado no projeto IU pega deginição de chame do json configurado
                if (!optionsBuilder.IsConfigured)
                    //optionsBuilder.UseSqlServer(GetStringConectionConfig());
                    optionsBuilder.UseOracle(GetStringConectionConfig());

                base.OnConfiguring(optionsBuilder);
            }


            private string GetStringConectionConfig()
            {
                //string strCon = "Data Source=ORACLE.FIAP.COM.BR:1521/ORCL;Initial Catalog=fiap;Integrated Security=False;User ID=;Password=;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False";
                string strCon = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=oracle.fiap.com.br)(PORT=1521))) (CONNECT_DATA=(SERVER=DEDICATED)(SID=ORCL)));User Id=;Password=;";
                return strCon;
            }



        }
    }

