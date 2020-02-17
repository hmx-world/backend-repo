using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
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
        private readonly IProviderRepo _login;
        public ProviderController(IPropertyManager manager, IProviderRepo login)
        {
            _manager = manager;
            _login = login;
        }


        
         [HttpGet("rental/{providerId}/provider")]
        public async Task<IActionResult> GetRentalPropertyByProvider([FromRoute]int providerId)
        {
            return Ok(await _manager.GetRentalPropertyByProvider(providerId));
        }

        [HttpGet("onsale/{providerId}/provider")]
        public async Task<IActionResult> GetOnSalePropertyByProvider([FromRoute]int providerId)
        {
            return Ok(await _manager.GetOnSalePropertyByProvider(providerId));
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

         [HttpGet("industrial/{id}/deactivate")]
        public IActionResult DeactivateIndustrialProperty([FromRoute]int id)
        {
            _manager.DeactivateProperty(id, "industrial");
            return Ok();
        }


      

        [HttpGet("industrial/{providerId}/provider")]
        public async Task<IActionResult> GetIndustrialPropertyByProvider([FromRoute]int providerId)
        {
            return Ok (await _manager.GetIndustrialPropertyByProvider(providerId));
        }

        

        [HttpPost("industrial")]
        public async Task<IActionResult> AddIndustrialProperty([FromBody]IndustrialProperty property)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _manager.AddIndustrialProperty(property);
            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest("Request is null");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]ProviderLoginDto loginDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _login.ProviderLogin(loginDto);
            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest("Login failed");
        }


        [HttpGet("providerInfo/{id}")]
        public async Task<IActionResult> GetProviderInfo(int? id)
        {
            if (id == null)
            {
                return BadRequest("Provide an id");
            }

            return Ok(await _login.GetProviderDataComplete((int)id));
        }

    }
}