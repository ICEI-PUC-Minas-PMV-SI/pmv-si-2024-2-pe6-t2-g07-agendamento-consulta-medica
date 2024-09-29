using apirest.Data;
using apirest.Models;
using Microsoft.EntityFrameworkCore;

namespace apirest.Repositories
{
    public interface IUsuarioRepository : IRepository<Usuario> {
        Task<Usuario> GetByEmailAsync(string email);
    }
    
    public class UsuarioRepository : Repository<Usuario, ApiDbContext>, IUsuarioRepository
    {
        public UsuarioRepository(ApiDbContext context) : base(context) { }

        public async Task<Usuario> GetByEmailAsync(string email)
        {
            try
            {
                var entity = await _context.Usuarios.FirstOrDefaultAsync(e => e.Email == email)
                    ?? throw new KeyNotFoundException($"Entidade do tipo Usuário com o e-mail {email} não encontrada.");
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"Falha ao recuperar a entidade com o e-mail {email}.", ex);
            }
        }
    }
}
