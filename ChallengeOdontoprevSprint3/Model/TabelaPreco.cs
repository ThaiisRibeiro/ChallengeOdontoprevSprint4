using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json.Linq;

namespace ChallengeOdontoprevSprint3.Model
{
    [Table("Api_Dotnet_Tabela_Precos")]
    public class TabelaPreco
    {
        private string _nome_procedimento;
        private double _valor;
        private string _descricao;



        [Key]
        // public int id { get; set; }
        public int id_tabela_preco { get; set; }
        

        [Column("nome_procedimento ")]
        [Display(Name = "Nome do procedimento: ")]
        [Required(ErrorMessage = "Campo Nome do procedimento Obrigátorio", AllowEmptyStrings = false)]
        public string nome_procedimento 
        {
            get => _nome_procedimento;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Nome do procedimento não pode ser vazio.");
        _nome_procedimento = value;
            }
        }


        [Column("valor ")]
        [Display(Name = "valor : ")]
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


        [Column("descricao ")]
        [Display(Name = "descricao tabela paciente: ")]
        [Required(ErrorMessage = "Campo Descrição Obrigátorio", AllowEmptyStrings = false)]
        public string descricao 
        {
            get => _descricao;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Descrição não pode ser vazia.");
         _descricao = value;
            }
        }
    }
}
