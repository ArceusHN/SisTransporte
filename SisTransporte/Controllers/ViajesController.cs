using Application.Interfaces;
using Application.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace SisTransporte.Controllers
{
    [ApiController]
    [Route("api/Viajes")]
    public class ViajesController : ControllerBase
    {
        private readonly IViajeRepositoryAsync _viajesRepository;

        public ViajesController(IViajeRepositoryAsync viajesRepository)
        {
            _viajesRepository = viajesRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetViajes()
        {
            return Ok(await _viajesRepository.GetAll());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetViaje(int id)
        {
            return Ok(await _viajesRepository.Get(id));
        }

    }
}
