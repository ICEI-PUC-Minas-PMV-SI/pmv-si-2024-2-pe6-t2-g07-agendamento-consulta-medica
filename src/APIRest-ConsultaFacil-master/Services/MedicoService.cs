using apirest.Data;
using apirest.Models;
using apirest.Repositories;

namespace apirest.Services
{
    public interface IMedicoService : IService<Medico> 
    {
        
    }

    public class MedicoService : Service<Medico, ApiDbContext>, IMedicoService
    {
        public MedicoService(IMedicoRepository repository) : base(repository)
        {
            
        }          
                    
    }
}
