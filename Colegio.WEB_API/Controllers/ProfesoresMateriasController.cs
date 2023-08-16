using Colegio.Comunes.Clases.Contracts.Colegio.Materias;
using Colegio.Comunes.Clases.Contracts.Colegio.ProfesoresMaterias;
using Colegio.Dominio.Services.Colegio.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Colegio.WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfesoresMateriasController : ControllerBase
    {
        private readonly ICrudService<ProfesoresMateriasContract> _crudService;
        public ProfesoresMateriasController(ICrudService<ProfesoresMateriasContract> crudService)
        {
            _crudService = crudService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _crudService.GetAllAsync());
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _crudService.GetByIdAsync(id));
        }
        [HttpPost]
        [Route("[Action]")]
        public async Task<IActionResult> Create(ProfesoresMateriasContract contract)
        {
            ProfesoresMateriasContract asignacionprofesorNueva = await _crudService.CreateAsync(contract);
            if (asignacionprofesorNueva != null)
            {
                return Ok(asignacionprofesorNueva);
            }
            return BadRequest();
        }
        [HttpPut]
        [Route("[Action]")]
        public async Task<IActionResult> Update(ProfesoresMateriasContract contract)
        {
            ProfesoresMateriasContract asignacion = await _crudService.UpdateAsync(contract);
            if (asignacion != null)
            {
                return Ok(asignacion);
            }
            return BadRequest();
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _crudService.DeleteAsync(id));
        }
    }
}
