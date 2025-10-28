using Microsoft.AspNetCore.Mvc;
using Supabase;
using HelldiversApi.Models;
using System.Linq;
using System.Threading.Tasks;


namespace HelldiversApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SuperearthController : ControllerBase
    {
        private readonly Client _client;

        public SuperearthController(Client client)
        {
            _client = client;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _client.From<Superearth>().Get();

            // Mapeamos a DTO para evitar problemas de serialización
            var dto = response.Models.Select(s => new SuperearthDto
            {
                Id = s.Id,
                Department = s.Department,
                Type = s.Type,
                Name = s.Name,
                Penetration = s.Penetration,
                Description = s.Description,
                Photo_Url = s.Photo_Url
            }).ToList();

            return Ok(dto);
        }
    }
}