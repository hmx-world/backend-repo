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
        public PropertyController(IPropertyManager manager)
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
    }
}