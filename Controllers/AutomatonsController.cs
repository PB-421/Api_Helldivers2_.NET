using Microsoft.AspNetCore.Mvc;
using Supabase;
using HelldiversApi.Models;
using System.Linq;
using System.Threading.Tasks;

namespace HelldiversApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AutomatonsController : ControllerBase
    {
        private readonly Client _client;

        public AutomatonsController(Client client)
        {
            _client = client;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _client.From<Automatons>().Get();

            var dto = response.Models.Select(s => new AutomatonsDto
            {
                Id = s.Id,
                Structure = s.Structure,
                Division = s.Division,
                Name = s.Name,
                Resistance = s.Resistance,
                Description = s.Description,
                Photo_Url = s.Photo_Url
            }).ToList();

            return Ok(dto);
        }
    }
}
