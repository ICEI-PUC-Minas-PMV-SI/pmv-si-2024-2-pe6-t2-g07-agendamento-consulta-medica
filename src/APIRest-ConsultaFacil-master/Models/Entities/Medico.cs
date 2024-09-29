using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace apirest.Models
{
    [Table("Medicos")]
    public class Medico: BaseEntity
    {
        [Required(ErrorMessage = "A Especialidade é obrigatória.")]
        [MaxLength(30, ErrorMessage = "O nome da Especialidade não pode exceder 30 caracteres.")]
        public string Especialidade { get; set; }

        [Required]
        [MaxLength(10, ErrorMessage = "O CPF não pode exceder 10 caracteres.")]
        public string CRM { get; set; }

        [ForeignKey("Usuario")]
        public int UsuarioId { get; set;}

        [JsonIgnore]
        public Usuario Usuario { get; set;}

        //Associar a tabela Médicos a tabela Consultas. Um Médico possui muitas Consultas.
        [JsonIgnore]
        public ICollection<Consulta> Consultas { get; set; }

    }
}
