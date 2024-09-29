using AutoMapper;
using apirest.Models;
using apirest.Models.Dtos;

namespace UserService.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Usuario, RegisterDto>().ReverseMap();
            CreateMap<Consulta, ConsultaDto>().ReverseMap();
            CreateMap<Usuario, UsuarioDto>().ReverseMap();
            CreateMap<Medico, MedicoDto>().ReverseMap();
        }
    }
}