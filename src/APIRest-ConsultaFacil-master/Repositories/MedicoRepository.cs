using apirest.Data;
using apirest.Models;
using Microsoft.EntityFrameworkCore;

namespace apirest.Repositories
{
    public interface IMedicoRepository : IRepository<Medico> {
    }
    
    public class MedicoRepository : Repository<Medico, ApiDbContext>, IMedicoRepository
    {
        public MedicoRepository(ApiDbContext context) : base(context) { }

    }
}
