using apirest.Data;
using apirest.Models;
using apirest.Repositories;

namespace apirest.Services
{
    public interface IConsultaService : IService<Consulta> 
    {
       
    }

    public class ConsultaService : Service<Consulta, ApiDbContext>, IConsultaService
    {
       
        public ConsultaService(IConsultaRepository repository) : base(repository)
        {
           
        }

    }
}
