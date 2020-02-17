using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using tinder4apartment.Models;
using tinder4apartment.Repo;

namespace tinder4apartment.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly IProviderRepo _providerRepo;
        private readonly IPropertyManager _manager;
        public AdminController(IProviderRepo providerRepo, IPropertyManager manager)
        {
            _providerRepo = providerRepo;
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

        [HttpPost("create-provider")]
        public async Task<IActionResult> CreateProvider([FromBody] ProviderModel provider)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _providerRepo.CreateProvider(provider));
        }

          [HttpGet("industrial/all")]
        public async Task<IActionResult> GetIndustrialProperty()
        {
            return Ok (await _manager.GetIndustrialProperty());
        }

        [HttpGet("providers/all")]
        public async Task<IActionResult> GetAllProviders()
        {
            return Ok (await _providerRepo.GetProviders());
        }


        
    }
}