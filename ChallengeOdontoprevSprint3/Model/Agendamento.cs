using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ChallengeOdontoprevSprint3.Model
{
    [Table("Api_Dotnet_Agendamentos")]
    public class Agendamento
    {




        [Key]
        // public int id { get; set; }
        public int id_agendamento { get; set; }

        [Column("data_agendamento ")]
        [Display(Name = "data do agendamento: ")]
        [Required(ErrorMessage = "Campo Data do Agendamento Obrigátorio", AllowEmptyStrings = false)]
        public DateTime data_agendamento { get; set; }


        [Column("data_atendimento ")]
        [Display(Name = "data do atendimetno: ")]
        [Required(ErrorMessage = "Campo Data do Atendimento Obrigátorio", AllowEmptyStrings = false)]
        public DateTime data_atendimento { get; set; }

        [Column("id_paciente ")]
        [Display(Name = "id do paciente: ")]
        public int id_paciente { get; set; }

        [Column("id_dentista  ")]
        [Display(Name = "id do dentista : ")]
        public int id_dentista { get; set; }

        [Column("id_clinica  ")]
        [Display(Name = "id da clinica : ")]
        public int id_clinica { get; set; }

        [Column("id_tabela_preco  ")]
        [Display(Name = "id da tabela de preco : ")]
        public int id_tabela_preco { get; set; }
    }
}
