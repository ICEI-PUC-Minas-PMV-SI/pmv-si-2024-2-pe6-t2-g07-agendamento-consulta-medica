using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace apirest.Models
{
    [Table("Consultas")]
    public class Consulta : BaseEntity
    {

        [Required]
        [DataType(DataType.Date)]
        public DateTime? DataConsulta { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public TimeSpan? HoraConsulta { get; set; }

        // Estado da consulta: Disponível, Agendada, Realizada, Cancelada.
        [Required]
        public Estado Tipo { get; set; }


        public string TipoDescricao
        {

            get { return Tipo.ToString(); }

        }

        //Foreign Key para relacionamento entre as tabelas Consultas e Usuários de forma 1:N "navegação virtual"
        public int? UsuarioId { get; set; }

        [JsonIgnore]
        public Usuario Usuario { get; set; }

        //Foreign Key para relacionamento entre as tabelas Consultas e Médicos de forma 1:N "navegação virtual"
        public int? MedicoId { get; set; }

        [JsonIgnore]
        public Medico Medico { get; set; }


    }
    public enum Estado
    {
        [Display(Name = "Disponível")]
        Disponivel, // 0
        Agendada,   // 1
        Realizada,  // 2
        Cancelada   // 3
    }
}
