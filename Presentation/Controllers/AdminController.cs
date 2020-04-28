using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using server.Core.Repo;
using tinder4apartment.Models;
using tinder4apartment.Repo;

namespace tinder4apartment.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly IFirmRepo _firmRepo;
        private readonly IAdminRepo _adminRepo;
        private readonly IPropertyManager _manager;
        public AdminController(IFirmRepo firmRepo, IPropertyManager manager, IAdminRepo adminRepo)
        {
            _firmRepo = firmRepo;
            _manager = manager;
            _adminRepo = adminRepo;
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


        [HttpGet("commercial/all")]
        public async Task<IActionResult> GetAllCommercialProperty()
        {
            return Ok (await _manager.GetIndustrialProperty());
        }

        [HttpGet("landproperties/all")]
        public async Task<IActionResult> GetAllLandProperties()
        {
            return Ok (await _manager.GetAllLandProperties());
        }

        [HttpGet("firms/all")]
        public async Task<IActionResult> GetAllFirms()
        {
            return Ok (await _adminRepo.GetAllFirms());
        }

        [HttpGet("emergency/property")]
        public IActionResult GetEmergencyProperties()
        {
            return Ok(_adminRepo.GetEmergencyProperties());
        }

        [HttpGet("property/searchlog")]
        public async Task<IActionResult> GetSearchLog()
        {
            return Ok(await _adminRepo.GetSearchQueryLogs());
        }

        [HttpGet("all/firm/actions")]
        public IActionResult GetFirmActions()
        {
            return Ok(_adminRepo.GetProviderActionCheckorRedirect());
        }



    }
}