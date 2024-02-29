using Microsoft.AspNetCore.Mvc;
using RosariumBackEnd.Service.Interfaces;

namespace RosariumBackEnd.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomiliaController : ControllerBase
    {
        private readonly IEvangelhoService evangelhoService;

        public HomiliaController(IEvangelhoService _evangelhoService)
        {
            this.evangelhoService = _evangelhoService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllEvangelhosAsync()
        {
            try
            {
                var evangelhos = await evangelhoService.GetAllEvangelhosAsync();
                return Ok(evangelhos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao buscar os evangelhos: {ex.Message}");
            }
        }

    }
}