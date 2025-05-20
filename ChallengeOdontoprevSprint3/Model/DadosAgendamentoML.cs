using Microsoft.ML.Data;

namespace ChallengeOdontoprevSprint3.Model
{
    public class DadosAgendamentoML
    {
        [LoadColumn(0)]
        public float QtdAgendamentosPaciente { get; set; }
        [LoadColumn(1)]
        public float QtdAgendamentosDentista { get; set; }
        [LoadColumn(2)]
        public Boolean IsSinistro { get; set; }
    }

}
