using Colegio.Comunes.Clases.Contracts.Colegio.Profesores;
using Colegio.Dominio.Services.Colegio.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Colegio.WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfesoresController : ControllerBase
    {
        private readonly ICrudService<ProfesoresContract> _crudService;
        public ProfesoresController(ICrudService<ProfesoresContract> crudService)
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
        public async Task<IActionResult>Get(int identificacion)
        {
            return Ok(await _crudService.GetByIdAsync(identificacion));
        }
        [HttpPost]
        [Route("[Action]")]
        public async Task<IActionResult>Create(ProfesoresContract contract)
        {
            ProfesoresContract profesorNuevo=await _crudService.CreateAsync(contract);
            if(profesorNuevo!=null)
            {
                return Ok(profesorNuevo);
            }
            return BadRequest();
        }
        [HttpPost]
        [Route("[Action]")]
        public async Task<IActionResult>Update(ProfesoresContract contract)
        {
            ProfesoresContract profesor = await _crudService.UpdateAsync(contract);
            if (profesor != null)
            {
                return Ok(profesor);
            }
            return BadRequest();
        }
        [HttpDelete]
        [Route("{identificacion}")]
        public async Task<IActionResult>Delete(int identificacion)
        {
            return Ok(await _crudService.DeleteAsync(identificacion));
        }
            

    }
}
