using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using tinder4apartment.Models;
using tinder4apartment.Repo;


namespace tinder4apartment.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProviderController : ControllerBase
    {
        private readonly IPropertyManager _manager;

        public ProviderController(IPropertyManager manager)
        {
            _manager = manager;
        }


        [HttpGet("rental/all")]
        public async Task<IActionResult> GetAllRentalProperties()
        {
            return Ok(await _manager.GetAllRentalProperty());
        }

        [HttpGet("onsale/all")]
        public async Task<IActionResult> GetAllOnSaleProperties()
        {
            return Ok(await _manager.GetAllOnSaleProperty());
        }
        
         [HttpGet("rental/{provider}/provider")]
        public async Task<IActionResult> GetRentalPropertyByProvider([FromRoute]string provider)
        {
             if (provider == null)
            {
                return BadRequest("Provide an providername");
            }
            return Ok(await _manager.GetRentalPropertyByProvider(provider));
        }

        [HttpGet("onsale/{provider}/provider")]
        public async Task<IActionResult> GetOnSalePropertyByProvider([FromRoute]string provider)
        {
              if (provider == null)
            {
                return BadRequest("Provide an providername");
            }
            return Ok(await _manager.GetOnSalePropertyByProvider(provider));
        }

        
        [HttpPost("rental")]
        public async Task<IActionResult> AddRentalProperty([FromBody]RentalProperty property)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _manager.AddRentalProperty(property);
            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest("property is null");
        }

         [HttpPost("onsale")]
        public async Task<IActionResult> AddOnSaleProperty([FromBody]OnSaleProperty property)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _manager.AddOnSaleProperty(property);
            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest("property is null");
        }


        [HttpGet("onsale/{id}/deactivate")]
        public IActionResult DeactivateOnSaleProperty([FromRoute]int id)
        {
            _manager.DeactivateProperty(id, "onsale");
            return Ok();
        }

        [HttpGet("rental/{id}/deactivate")]
        public IActionResult DeactivateRentalProperty([FromRoute]int id)
        {
            _manager.DeactivateProperty(id, "rental");
            return Ok();
        }

    }
}