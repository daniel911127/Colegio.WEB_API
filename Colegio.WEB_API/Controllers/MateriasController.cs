using Colegio.Comunes.Clases.Contracts.Colegio.Alumnos;
using Colegio.Comunes.Clases.Contracts.Colegio.Materias;
using Colegio.Comunes.Clases.Contracts.Colegio.Profesores;
using Colegio.Dominio.Services.Colegio.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Colegio.WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MateriasController : ControllerBase
    {
        private readonly ICrudService<MateriasContract> _crudService;
        public MateriasController(ICrudService<MateriasContract> crudService)
        {
            _crudService = crudService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _crudService.GetAllAsync());
        }
        [HttpGet]
        [Route("{codigo}")]
        public async Task<IActionResult> Get(int codigo)
        {
            return Ok(await _crudService.GetByIdAsync(codigo));
        }
        [HttpPost]
        [Route("[Action]")]
        public async Task<IActionResult> Create(MateriasContract contract)
        {
            MateriasContract materiaNueva = await _crudService.CreateAsync(contract);
            if (materiaNueva != null)
            {
                return Ok(materiaNueva);
            }
            return BadRequest();
        }
        [HttpPut]
        [Route("[Action]")]
        public async Task<IActionResult> Update(MateriasContract contract)
        {
            MateriasContract materia = await _crudService.UpdateAsync(contract);
            if (materia != null)
            {
                return Ok(materia);
            }
            return BadRequest();
        }
        [HttpDelete]
        [Route("{codigo}")]
        public async Task<IActionResult> Delete(int codigo)
        {
            return Ok(await _crudService.DeleteAsync(codigo));
        }
    }
}
