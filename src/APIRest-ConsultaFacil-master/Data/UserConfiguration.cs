using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using apirest.Models;
using BC = BCrypt.Net.BCrypt;

namespace apirest.Data
{
    public class UserConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasIndex(x => x.Email).IsUnique();
            builder.HasData(
                new Usuario
                {
                    Id = 1,
                    Nome = "Administrador",
                    CPF = "12345678910",
                    Email = "admin@email.com.br",
                    Perfil = UsuarioPerfil.Administrador,
                    Senha = BC.HashPassword("consultafacil"),
                    Telefone = "31990000000",
                    DataNascimento = null,
                    Sexo = Sexo.Masculino
                },
                new Usuario
                {
                    Id = 2,
                    Nome = "Medico",
                    CPF = "12345678911",
                    Email = "medico@email.com.br",
                    Perfil = UsuarioPerfil.Medico,
                    Senha = BC.HashPassword("consultafacil"),
                    Telefone = "31990000001",
                    DataNascimento = null,
                    Sexo = Sexo.Masculino
                },
                 new Usuario
                 {
                     Id = 3,
                     Nome = "Paciente",
                     CPF = "12345678912",
                     Email = "paciente@email.com.br",
                     Perfil = UsuarioPerfil.Paciente,
                     Senha = BC.HashPassword("consultafacil"),
                     Telefone = "31990000002",
                     DataNascimento = null,
                     Sexo = null
                 }
            );
        }
    }
}
