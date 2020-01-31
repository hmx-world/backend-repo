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
      
        [HttpGet("active/rental/all")]
        public async Task<IActionResult> GetAllRentalProperties()
        {
            return Ok(await _manager.GetAllActiveRentalProperty());
        }

        [HttpGet("active/onsale/all")]
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

        [HttpGet("active/rental/{provider}/provider")]
        public async Task<IActionResult> GetActiveRentalPropertyByProvider([FromRoute]string provider)
        {
             if (provider == null)
            {
                return BadRequest("Provide an providername");
            }
            return Ok(await _manager.GetActiveRentalPropertyByProvider(provider));
        }

        [HttpGet("active/onsale/{provider}/provider")]
        public async Task<IActionResult> GetActiveOnSalePropertyByProvider([FromRoute]string provider)
        {
              if (provider == null)
            {
                return BadRequest("Provide an providername");
            }
            return Ok(await _manager.GetActiveOnSalePropertyByProvider(provider));
        }


        [HttpPost("active/rental/match/{providerName}")]
        public async Task<IActionResult> MatchRentalPropertyByProvider([FromRoute]string providerName, [FromBody]UserQuery query)
        {
            var propertyList = await _manager.GetActiveRentalPropertyByProvider(providerName);

            var result = _match.MatchRentalProperty(query, propertyList);

            return Ok(result.OrderByDescending(m => m.Rank));
        }

        [HttpPost("active/onsale/match/{providerName}")]
        public async Task<IActionResult> MatchOnSalePropertyByProvider([FromRoute]string providerName, [FromBody]UserQuery query)
        {
            var propertyList = await _manager.GetActiveOnSalePropertyByProvider(providerName);

            var result = _match.MatchOnSaleProperty(query, propertyList);

            return Ok(result.OrderByDescending(m => m.Rank));
        }


         [HttpPost("active/rental/match")]
        public async Task<IActionResult> MatchRentalProperty([FromBody]UserQuery query)
        {
            var propertyList = await _manager.GetAllActiveRentalProperty();

            var result = _match.MatchRentalProperty(query, propertyList);

            return Ok(result.OrderByDescending(m => m.Rank));
        }

        [HttpPost("active/onsale/match")]
        public async Task<IActionResult> MatchOnSaleProperty([FromBody]UserQuery query)
        {
            var propertyList = await _manager.GetAllActiveOnSaleProperty();

            var result = _match.MatchOnSaleProperty(query, propertyList);

            return Ok(result.OrderByDescending(m => m.Rank));
        }




        [HttpGet("active/industrial/all")]
        public async Task<IActionResult> GetIndustrialProperty()
        {
            return Ok (await _manager.GetActiveIndustrialProperty());
        }

        [HttpGet("active/industrial/{provider}/provider")]
        public async Task<IActionResult> GetIndustrialPropertyByProvider([FromRoute]string provider)
        {
            return Ok (await _manager.GetActiveIndustrialPropertyByProvider(provider));
        }

         [HttpGet("industrial/{id}")]
        public async Task<IActionResult> GetOneIndustrialProperty([FromRoute]int id)
        {
            return Ok (await _manager.GetOneIndustrialProperty(id));
        }


        [HttpPost("active/industrial/rent/match/{providerName}")]
        public async Task<IActionResult> MatchIndustrialRentalPropertyByProvider([FromRoute]string providerName, [FromBody]IndustrialQuery query)
        {
            var propertyList = await _manager.GetActiveIndustrialPropertyByProvider(providerName);

            var result = _match.MatchIndustrialProperty(query, Mode.Rent, propertyList);

            return Ok(result.OrderByDescending(m => m.Rank));
        }

        [HttpPost("active/industrial/sale/match/{providerName}")]
        public async Task<IActionResult> MatchIndustrialSalePropertyByProvider([FromRoute]string providerName, [FromBody]IndustrialQuery query)
        {
            var propertyList = await _manager.GetActiveIndustrialPropertyByProvider(providerName);

            var result = _match.MatchIndustrialProperty(query, Mode.Sale, propertyList);

            return Ok(result.OrderByDescending(m => m.Rank));
        }


        [HttpPost("active/industrial/rent/match")]
        public async Task<IActionResult> MatchIndustrialRentalProperty( [FromBody]IndustrialQuery query)
        {
            var propertyList = await _manager.GetActiveIndustrialProperty();

            var result = _match.MatchIndustrialProperty(query, Mode.Rent, propertyList);

            return Ok(result.OrderByDescending(m => m.Rank));
        }

        [HttpPost("active/industrial/sale/match")]
        public async Task<IActionResult> MatchIndustrialSaleProperty([FromBody]IndustrialQuery query)
        {
            var propertyList = await _manager.GetActiveIndustrialProperty();

            var result = _match.MatchIndustrialProperty(query, Mode.Sale, propertyList);

            return Ok(result.OrderByDescending(m => m.Rank));
        }

    }
}