using apirest.Services;
using apirest.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using apirest.Models.Dtos;
using System.Security.Claims;
using System.Linq.Expressions;


namespace apirest.Controllers
{
    public class ConsultasController : BaseController<Consulta, IConsultaService>
    {
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ConsultasController(IConsultaService service, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(service)
        {
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        [Authorize]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public override async Task<ActionResult> GetAll(int page = 1, int pageSize = 10)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                var id = Convert.ToInt32(userId);
                var perfil = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Role)?.Value;
                Expression<Func<Consulta, bool>> whereClause = null;

                if (perfil == UsuarioPerfil.Paciente.ToString())
                    whereClause = e => e.UsuarioId == id;
                else if (perfil == UsuarioPerfil.Medico.ToString())
                    whereClause = e => e.Medico.UsuarioId == id;

                var result = await _service.GetAllAsync(page, pageSize, whereClause);

                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }

        [Authorize]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public override async Task<ActionResult> GetById(int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var entity = await _service.GetByIdAsync(id,
                                                         e => e.Id == id,
                                                         include => include.Usuario, include => include.Medico.Usuario);

                var consulta = _mapper.Map<ConsultaDto>(entity);
                return Ok(consulta);
            }
            catch (ArgumentException ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new { message = ex.Message });
            }
            catch (KeyNotFoundException ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }

        [Authorize(Roles = "Administrador, Medico")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public override async Task<ActionResult> Create([FromBody] Consulta entity)
        {
            entity.DataConsulta = entity.DataConsulta.Value.ToUniversalTime();
            return await base.Create(entity);
        }

        [Authorize]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public override async Task<ActionResult> Update(int id, [FromBody] Consulta entity)
        {
            entity.DataConsulta = entity.DataConsulta.Value.ToUniversalTime();
            return await base.Update(id, entity);
        }

        [Authorize(Roles = "Administrador")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public override async Task<ActionResult> Delete(int id)
        {
            return await base.Delete(id);
        }

    }
}
