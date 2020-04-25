using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using tinder4apartment.Models;
using tinder4apartment.Repo;

namespace tinder4apartment.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly IFirmRepo _firmRepo;
        private readonly IPropertyManager _manager;
        public AdminController(IFirmRepo firmRepo, IPropertyManager manager)
        {
            _firmRepo = firmRepo;
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


          [HttpGet("industrial/all")]
        public async Task<IActionResult> GetIndustrialProperty()
        {
            return Ok (await _manager.GetIndustrialProperty());
        }

        [HttpGet("providers/all")]
        public async Task<IActionResult> GetAllProviders()
        {
            return Ok (await _firmRepo.GetFirms());
        }


        
    }
}