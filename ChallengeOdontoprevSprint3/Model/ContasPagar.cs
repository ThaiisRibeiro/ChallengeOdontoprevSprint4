using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ChallengeOdontoprevSprint3.Model
{
    [Table("Api_Dotnet_Contas_Pagar")]
    public class ContasPagar
    {
        private double _valor;
        private DateTime _data_emissao;
        private DateTime _data_vencimento;



        [Key]
        // public int id { get; set; }
        public int id_conta_pagar { get; set; }

        [Column("id_clinica ")]
        [Display(Name = "id_clinica : ")]
        public int id_clinica { get; set; }



        [Column("valor ")]
        [Display(Name = "valor  paciente: ")]
        [Required(ErrorMessage = "Campo Valor Obrigátorio", AllowEmptyStrings = false)]
        public double valor
        {
            get => _valor;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Valor inválido. Deve ser maior que zero.");
                _valor = value;
            }
        }


        [Column("data_emissao ")]
        [Display(Name = "data_emissao : ")]
        [Required(ErrorMessage = "Campo Data de Emissao Obrigátorio", AllowEmptyStrings = false)]
        public DateTime data_emissao
        {
            get => _data_emissao;
            set => _data_emissao = value;
        }

        [Column("data_vencimento  ")]
        [Display(Name = "data_vencimento  : ")]
        [Required(ErrorMessage = "Campo Data de Vencimento Obrigátorio", AllowEmptyStrings = false)]
        public DateTime data_vencimento
        {
            get => _data_vencimento;
            set
            {
                if (value < data_emissao)
                    throw new ArgumentException("Data de vencimento não pode ser anterior à data de emissão.");
                _data_vencimento = value;
            }
        }


    }
}
