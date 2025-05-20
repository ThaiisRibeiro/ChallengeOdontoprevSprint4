using Microsoft.ML.Data;
using Microsoft.ML;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;

namespace ChallengeOdontoprevSprint3.ML
{
    public class SinistroModelBuilder
    {

        private readonly MLContext mlContext;
        private readonly string caminhoCsv = Path.Combine(Environment.CurrentDirectory, "ML", "DadosTreinamento.csv");
        //C:\Users\Thata\Documents\0000000000 THAIS AULA\Projeto Sprint4\Challenge4Teste\ChallengeOdontoprevSprint3\ChallengeOdontoprevSprint3\ML\DadosTreinamento.csv
        private readonly string caminhoModelo = Path.Combine(Environment.CurrentDirectory, "ML", "ModeloTreinado.zip");

        public SinistroModelBuilder()
        {
            mlContext = new MLContext(seed: 0);
        }

        public class AgendamentoData
        {
            [LoadColumn(0)]
            public float id_agendamento { get; set; }

            [LoadColumn(1)]
            public string data_agendamento { get; set; }

            [LoadColumn(2)]
            public string data_atendimento { get; set; }

            [LoadColumn(3)]
            public float id_paciente { get; set; }

            [LoadColumn(4)]
            public float id_dentista { get; set; }

            [LoadColumn(5)]
            public float id_clinica { get; set; }

            [LoadColumn(6)]
            public float id_tabela_preco { get; set; }

            [LoadColumn(7)]
            public float total_agendamentos_paciente { get; set; }

            [LoadColumn(8)]
            public float total_agendamentos_dentista { get; set; }

            [LoadColumn(9)]
            public bool flag_sinistro { get; set; }
        }

        public class SinistroPrediction
        {
            [ColumnName("PredictedLabel")]
            public bool PredicaoSinistro { get; set; }

            public float Score { get; set; }
        }

        public void TreinarModelo()
        {
            if (!File.Exists(caminhoCsv))
            {
                Console.WriteLine("Arquivo CSV não encontrado: " + caminhoCsv);
                return;
            }

            IDataView dados = mlContext.Data.LoadFromTextFile<AgendamentoData>(
                caminhoCsv,
                hasHeader: true,
                separatorChar: ',');

            var pipeline = mlContext.Transforms.CopyColumns(outputColumnName: "Label", inputColumnName: nameof(AgendamentoData.flag_sinistro))

                .Append(mlContext.Transforms.Categorical.OneHotEncoding("id_paciente"))
                .Append(mlContext.Transforms.Categorical.OneHotEncoding("id_dentista"))
                .Append(mlContext.Transforms.Concatenate("Features",
                    "id_paciente",
                    "id_dentista",
                    "total_agendamentos_paciente",
                    "total_agendamentos_dentista"))
                .Append(mlContext.BinaryClassification.Trainers.FastTree());

            var modelo = pipeline.Fit(dados);

            mlContext.Model.Save(modelo, dados.Schema, caminhoModelo);

            Console.WriteLine("Modelo treinado e salvo em: " + caminhoModelo);
        }

        public SinistroPrediction Prever(AgendamentoData agendamento)
        {
            if (!File.Exists(caminhoModelo))
            {
                Console.WriteLine("Modelo não treinado. Treine antes de usar a previsão.");
                return null;
            }

            var modelo = mlContext.Model.Load(caminhoModelo, out var schema);

            var engine = mlContext.Model.CreatePredictionEngine<AgendamentoData, SinistroPrediction>(modelo);

            return engine.Predict(agendamento);
        }
    }
    }

