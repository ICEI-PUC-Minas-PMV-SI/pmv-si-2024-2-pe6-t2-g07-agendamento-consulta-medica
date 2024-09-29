using apirest.Services;
using apirest.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using System.Security.Claims;


namespace apirest.Controllers
{
    public class MedicosController : BaseController<Medico, IMedicoService>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public MedicosController(IMedicoService service, IHttpContextAccessor httpContextAccessor) : base(service)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        [Authorize(Roles = "Administrador, Medico")]
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
                Expression<Func<Medico, bool>> whereClause = null;

                if (perfil == UsuarioPerfil.Medico.ToString())
                    whereClause = e => e.UsuarioId == id;

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

        [Authorize(Roles = "Administrador, Medico")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public override async Task<ActionResult> GetById(int id)
        {
            return await base.GetById(id);
        }

        [Authorize(Roles = "Administrador, Medico")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public override async Task<ActionResult> Create([FromBody] Medico entity)
        {
            return await base.Create(entity);
        }

        [Authorize(Roles = "Administrador, Medico")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public override async Task<ActionResult> Update(int id, [FromBody] Medico entity)
        {
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
