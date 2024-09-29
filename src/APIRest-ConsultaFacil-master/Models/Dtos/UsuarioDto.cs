using System.ComponentModel.DataAnnotations;

namespace apirest.Models.Dtos
{
    public class UsuarioDto
    {
        public string Nome { get; set; }

        public string CPF { get; set; }

        public string Email { get; set; }
    }
}
