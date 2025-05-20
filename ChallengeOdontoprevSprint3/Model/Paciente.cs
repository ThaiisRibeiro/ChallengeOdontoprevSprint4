using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace ChallengeOdontoprevSprint3.Model
{
    [Table("Api_Dotnet_Pacientes")]
    public class Paciente
    {
        private string _cpf_cnpj;
        private string _cep;
        private string _telefone;
        private string _email;
        private string _tipoPaciente;
        private string _senha;

        [Key]
        // public int id { get; set; }
        public int id_paciente { get; set; }
        [Column("cpf_cnpj")]
        [Display(Name = "Cpf ou Cnpj paciente: ")]
        [Required(ErrorMessage = "Campo CPF ou CNPJ Obrigátorio", AllowEmptyStrings = false)]
        public string cpf_cnpj
        {
            get => _cpf_cnpj;
            set
            {
                if (string.IsNullOrWhiteSpace(value) ||
                    (value.Length != 11 && value.Length != 14) ||
                    !long.TryParse(value, out _))
                {
                    throw new ArgumentException("CPF/CNPJ inválido. Deve conter apenas números e ter 11 (CPF) ou 14 (CNPJ) dígitos.");
                }
                _cpf_cnpj = value;
            }
        }


        [Column("nome")]
        [Display(Name = "Nome paciente: ")]
        [Required(ErrorMessage = "Campo Nome Obrigátorio", AllowEmptyStrings = false)]
        public string nome { get; set; } = string.Empty;
        [Column("endereco")]
        [Display(Name = "Endereco paciente: ")]
        [Required(ErrorMessage = "Campo Endereço Obrigátorio", AllowEmptyStrings = false)]
        public string endereco { get; set; } = string.Empty;

        [Column("cep")]
        [Display(Name = "CEP do paciente: ")]
        [Required(ErrorMessage = "Campo CEP obrigatório", AllowEmptyStrings = false)]
        public string cep
        {
            get => _cep;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("CEP é obrigatório.");

                if (!Regex.IsMatch(value, @"^\d{5}-?\d{3}$"))
                    throw new ArgumentException("CEP inválido. Formato: 00000-000");

                _cep = value;
            }
        }

        [Display(Name = "Telefone paciente: ")]
        [Required(ErrorMessage = "Campo Telefone Obrigátorio", AllowEmptyStrings = false)]
        public string telefone
        {
            get => _telefone;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Telefone é obrigatório.");

                if (!Regex.IsMatch(value, @"^\d{10,11}$"))
                    throw new ArgumentException("Telefone inválido. Use apenas números com DDD.");

                _telefone = value;
            }
        }

        [Display(Name = "Email paciente: ")]
        [Required(ErrorMessage = "Campo email Obrigátorio", AllowEmptyStrings = false)]
        public string email
        {
            get => _email;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Email é obrigatório.");

                if (!new EmailAddressAttribute().IsValid(value))
                    throw new ArgumentException("Email inválido.");

                _email = value;
            }
        }


        [Display(Name = "Digite F ou J (fisico ou juridico): ")]
        [Required(ErrorMessage = "Campo Fisico ou Juridico Obrigátorio", AllowEmptyStrings = false)]
        public string tipo_paciente
        {
            get => _tipoPaciente;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Tipo de paciente é obrigatório.");

                if (value != "F" && value != "J")
                    throw new ArgumentException("Tipo deve ser 'F' ou 'J'.");

                _tipoPaciente = value;
            }
        }


        [Display(Name = "Senha paciente: ")]
        [Required(ErrorMessage = "Campo Senha Obrigátorio", AllowEmptyStrings = false)]
        public string senha
        {
            get => _senha;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Senha é obrigatória.");

                _senha = value;
            }
        }
        private bool EhCpfValido(string valor) => valor.Length == 11 && valor.All(char.IsDigit);
        private bool EhCnpjValido(string valor) => valor.Length == 14 && valor.All(char.IsDigit);
    }
}
