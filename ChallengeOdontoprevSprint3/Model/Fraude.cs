using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ChallengeOdontoprevSprint3.Model
{
    [Table("Api_Dotnet_Fraudes")]
    public class Fraude
    {



        [Key]
        // public int id { get; set; }
        public int id_fraude { get; set; }
        [Column("tipo_fraude  ")]
        [Display(Name = "tipo_fraude : ")]
        [Required(ErrorMessage = "Campo Tipo de Fraude Obrigátorio", AllowEmptyStrings = false)]
        public string tipo_fraude { get; set; }


        [Column("descricao ")]
        [Display(Name = "descricao: ")]
        [Required(ErrorMessage = "Campo Descrição Obrigátorio", AllowEmptyStrings = false)]
        public string descricao { get; set; }

        [Column("id_paciente ")]
        [Display(Name = " id_paciente : ")]
        public int id_paciente { get; set; }

        [Column("id_dentista  ")]
        [Display(Name = " id_dentista  : ")]
        public int id_dentista { get; set; }

        [Column("id_clinica   ")]
        [Display(Name = " id_clinica   : ")]
        public int id_clinica { get; set; }

        [Column("id_agendamento ")]
        [Display(Name = " id_agendamento    : ")]
        public int id_agendamento { get; set; }


    }
}
