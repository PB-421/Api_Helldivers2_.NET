using Microsoft.AspNetCore.Mvc;
using Supabase;
using HelldiversApi.Models;
using System.Linq;
using System.Threading.Tasks;

namespace HelldiversApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IlluminateController : ControllerBase
    {
        private readonly Client _client;

        public IlluminateController(Client client)
        {
            _client = client;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _client.From<Illuminate>().Get();

            var dto = response.Models.Select(s => new IlluminateDto
            {
                Id = s.Id,
                Structure = s.Structure,
                Name = s.Name,
                Resistance = s.Resistance,
                Description = s.Description,
                Photo_Url = s.Photo_Url
            }).ToList();

            return Ok(dto);
        }
    }
}
