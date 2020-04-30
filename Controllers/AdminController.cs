using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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


        [HttpPost("b00c58c0-df00/login")]
        [AllowAnonymous]
        public IActionResult AdminLogin(AdminLoginDto loginDto)
        {
            var result = _adminRepo.AdminLogin(loginDto.UserName, loginDto.Password);
            if(result == null)
            {
                return Unauthorized("User not authorized to this area");
            }
            else{
                return new OkObjectResult( new {
                    token= result
                });
            }
        }
        
        [HttpGet("rental/all")]
        [Authorize]
        public async Task<IActionResult> GetAllRentalProperties()
        {
            return Ok(await _manager.GetAllRentalProperty());
        }

        [HttpGet("onsale/all")]
        [Authorize]
        public async Task<IActionResult> GetAllOnSaleProperties()
        {
            return Ok(await _manager.GetAllOnSaleProperty());
        }


        [HttpGet("commercial/all")]
        [Authorize]
        public async Task<IActionResult> GetAllCommercialProperty()
        {
            return Ok (await _manager.GetIndustrialProperty());
        }

        [HttpGet("landproperties/all")]
        [Authorize]
        public async Task<IActionResult> GetAllLandProperties()
        {
            return Ok (await _manager.GetAllLandProperties());
        }

        [HttpGet("firms/all")]
        [Authorize]
        public async Task<IActionResult> GetAllFirms()
        {
            return Ok (await _adminRepo.GetAllFirms());
        }

        [HttpGet("emergency/property")]
        [Authorize]
        public IActionResult GetEmergencyProperties()
        {
            return Ok(_adminRepo.GetEmergencyProperties());
        }

        [HttpGet("property/searchlog")]
        [Authorize]
        public async Task<IActionResult> GetSearchLog()
        {
            return Ok(await _adminRepo.GetSearchQueryLogs());
        }

        [HttpGet("all/firm/actions")]
        [Authorize]
        public IActionResult GetFirmActions()
        {
            return Ok(_adminRepo.GetProviderActionCheckorRedirect());
        }



    }

    public class AdminLoginDto
    {
        public string UserName {get; set;}
        public string Password {get; set;}
    }
}