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
        private readonly IProviderRepo _login;
        public ProviderController(IPropertyManager manager, IProviderRepo login)
        {
            _manager = manager;
            _login = login;
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

         [HttpGet("industrial/{id}/deactivate")]
        public IActionResult DeactivateIndustrialProperty([FromRoute]int id)
        {
            _manager.DeactivateProperty(id, "industrial");
            return Ok();
        }


      

        [HttpGet("industrial/{provider}/provider")]
        public async Task<IActionResult> GetIndustrialPropertyByProvider([FromRoute]string provider)
        {
            return Ok (await _manager.GetIndustrialPropertyByProvider(provider));
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


    }
}