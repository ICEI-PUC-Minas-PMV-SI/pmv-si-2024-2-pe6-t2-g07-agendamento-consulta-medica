
namespace apirest.Models.Dtos
{
    public class ConsultaDto
    {
        public int Id { get; set; }

        public DateTime? DataConsulta { get; set; }

        public TimeSpan? HoraConsulta { get; set; }

        // Estado da consulta: Disponível, Agendada, Realizada, Cancelada.
        public Estado Tipo { get; set; }

        public int? UsuarioId { get; set; }

        public int? MedicoId { get; set; }

        public UsuarioDto Usuario { get; set; }

        public MedicoDto Medico { get; set; }        
    }
}
