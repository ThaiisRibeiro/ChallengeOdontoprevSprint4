using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;

namespace ChallengeOdontoprevSprint3.Model
{
    [Table("Api_Dotnet_Dentistas")]
    public class Dentista
    {
        private string _cpf;
        private string _numero_cro;
        private string _telefone;
        private string _email;



        [Key]
        // public int id { get; set; }
        public int id_dentista { get; set; }
        [Column("cpf_cnpj")]

        [Display(Name = "Cpf dentista: ")]
        [Required(ErrorMessage = "Campo CPF Obrigátorio", AllowEmptyStrings = false)]
        public string cpf
         {
            get => _cpf;
            set
            {
                if (!Regex.IsMatch(value, @"^\d{11}|\d{14}$"))
                    throw new ArgumentException("CPF/CNPJ inválido. Deve conter apenas números e ter 11 (CPF) ou 14 (CNPJ) dígitos.");
         _cpf = value;
            }
         }


        [Display(Name = "numero_cro  dentista: ")]
        [Required(ErrorMessage = "Campo numero CRO Obrigátorio", AllowEmptyStrings = false)]
        public string numero_cro
        {
            get => _numero_cro;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Número CRO inválido.");
         _numero_cro = value;
            }
         }


        [Column("nome")]
        [Display(Name = "Nome dentista: ")]
        [Required(ErrorMessage = "Campo Nome Obrigátorio", AllowEmptyStrings = false)]
        public string nome { get; set; }

        [Column("telefone ")]

        [Display(Name = "telefone dentista: ")]
        [Required(ErrorMessage = "Campo Telefone Obrigátorio", AllowEmptyStrings = false)]
        public string telefone 
        {
            get => _telefone;
            set
            {
                if (!Regex.IsMatch(value, @"^(9|1)\d{10}$"))
                    throw new ArgumentException("Telefone inválido. Deve ter 11 dígitos e começar com 9 ou 1.");
         _telefone = value;
            }
        }



        [Column("email  ")]
        [Display(Name = "email  dentista: ")]
        [Required(ErrorMessage = "Campo Email Obrigátorio", AllowEmptyStrings = false)]
        public string email 
         {
            get => _email;
            set
            {
                if (!value.Contains("@"))
                    throw new ArgumentException("E-mail inválido. Deve conter '@'.");
         _email = value;
            }
         }


    }
}
