namespace apirest.Models.Dtos
{
    public class MedicoDto
    {
        public string Especialidade { get; set; }

        public string CRM { get; set; }

        public int UsuarioId { get; set; }

        public UsuarioDto Usuario { get; set; }
    }
}
