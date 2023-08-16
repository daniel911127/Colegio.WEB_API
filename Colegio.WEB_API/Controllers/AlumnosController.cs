using Colegio.Comunes.Clases.Contracts.Colegio.Alumnos;
using Colegio.Dominio.Services.Colegio.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Colegio.WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlumnosController : ControllerBase
    {
        private readonly ICrudService<AlumnosContract> _crudService;
        public AlumnosController(ICrudService<AlumnosContract> crudService)
        {
            _crudService = crudService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _crudService.GetAllAsync());
        }
        [HttpGet]
        [Route("{identificacion}")]
        public async Task<IActionResult> Get(int identificacion)
        {
            return Ok(await _crudService.GetByIdAsync(identificacion));
        }
        [HttpPost]
        [Route("[Action]")]
        public async Task<IActionResult> Create(AlumnosContract contract)
        {
            AlumnosContract alumnoNuevo = await _crudService.CreateAsync(contract);
            if (alumnoNuevo != null)
            {
                return Ok(alumnoNuevo);
            }
            return BadRequest();
        }
        [HttpPut]
        [Route("[Action]")]
        public async Task<IActionResult> Update(AlumnosContract contract)
        {
           AlumnosContract alumno = await _crudService.UpdateAsync(contract);
            if (alumno != null)
            {
                return Ok(alumno);
            }
            return BadRequest();
        }
        [HttpDelete]
        [Route("{identificacion}")]
        public async Task<IActionResult> Delete(int identificacion)
        {
            return Ok(await _crudService.DeleteAsync(identificacion));
        }
    }
}
