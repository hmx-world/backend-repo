using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using tinder4apartment.Models;
using tinder4apartment.Repo;

namespace tinder4apartment.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PropertyController : ControllerBase
    {
        private readonly IPropertyManager _manager;
        private readonly IMatchRepo _match;
        public PropertyController(IPropertyManager manager, IMatchRepo match)
        {
            _manager = manager;
            _match = match;
        }
      
        [HttpGet("rental/all")]
        public async Task<IActionResult> GetAllRentalProperties()
        {
            return Ok(await _manager.GetAllActiveRentalProperty());
        }

        [HttpGet("onsale/all")]
        public async Task<IActionResult> GetAllOnSaleProperties()
        {
            return Ok(await _manager.GetAllActiveOnSaleProperty());
        }

        [HttpGet("rental/{id}")]
        public async Task<IActionResult> GetOneRentalProperty([FromRoute]int? id)
        {
            if (id == null)
            {
                return BadRequest("Provide an Id");
            }
            return Ok(await _manager.GetOneRentalProperty((int)id));
        }

        [HttpGet("onsale/{id}")]
        public async Task<IActionResult> GetOneOnSaleProperty([FromRoute]int? id)
        {
             if (id == null)
            {
                return BadRequest("Provide an Id");
            }
            return Ok(await _manager.GetOneOnSaleProperty((int)id));
        }

        [HttpGet("rental/{provider}/provider")]
        public async Task<IActionResult> GetActiveRentalPropertyByProvider([FromRoute]string provider)
        {
             if (provider == null)
            {
                return BadRequest("Provide an providername");
            }
            return Ok(await _manager.GetActiveRentalPropertyByProvider(provider));
        }

        [HttpGet("onsale/{provider}/provider")]
        public async Task<IActionResult> GetActiveOnSalePropertyByProvider([FromRoute]string provider)
        {
              if (provider == null)
            {
                return BadRequest("Provide an providername");
            }
            return Ok(await _manager.GetActiveOnSalePropertyByProvider(provider));
        }


        [HttpPost("rental/match/{providerName}")]
        public async Task<IActionResult> MatchRentalProperty([FromRoute]string providerName, [FromBody]UserQuery query)
        {
            var propertyList = await _manager.GetActiveRentalPropertyByProvider(providerName);

            var result = _match.MatchRentalProperty(query, propertyList);

            return Ok(result.OrderByDescending(m => m.Rank));
        }

        [HttpPost("onsale/match/{providerName}")]
        public async Task<IActionResult> MatchOnSaleProperty([FromRoute]string providerName, [FromBody]UserQuery query)
        {
            var propertyList = await _manager.GetActiveOnSalePropertyByProvider(providerName);

            var result = _match.MatchOnSaleProperty(query, propertyList);

            return Ok(result.OrderByDescending(m => m.Rank));
        }
    }
}