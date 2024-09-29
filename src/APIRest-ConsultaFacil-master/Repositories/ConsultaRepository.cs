using apirest.Data;
using apirest.Models;
using Microsoft.EntityFrameworkCore;

namespace apirest.Repositories
{
    public interface IConsultaRepository : IRepository<Consulta> {
    }

    public class ConsultaRepository : Repository<Consulta, ApiDbContext>, IConsultaRepository
    {
        public ConsultaRepository(ApiDbContext context) : base(context) { }

    }
}
