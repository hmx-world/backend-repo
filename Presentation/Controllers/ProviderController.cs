using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using server.Core.Models;
using tinder4apartment.Models;
using tinder4apartment.Repo;


namespace tinder4apartment.Controllers
{
    [Produces("application/json")]  
    [ApiController]
    [Route("api/[controller]")]
    public class ProviderController : ControllerBase
    {
        private readonly IPropertyManager _manager;
        private readonly IProviderRepo _providerRepo;
        private readonly ISubscriptionRepo _sub;
        public ProviderController(IPropertyManager manager, IProviderRepo providerRepo, ISubscriptionRepo sub)
        {
            _manager = manager;
            _providerRepo= providerRepo;
            _sub = sub;
        }


               [Authorize]
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

        [Authorize]
        [HttpPost("rental")]
       // [RequestFormLimits(MultipartBodyLengthLimit = long.MaxValue)]
        public async Task<IActionResult> AddRentalProperty([FromForm]RentalProperty property)
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

            return BadRequest();
        }

        [Authorize]
        [HttpPut("rental/{id}")]
       // [RequestFormLimits(MultipartBodyLengthLimit = long.MaxValue)]
        public async Task<IActionResult> EditRentalProperty([FromRoute]int id, [FromBody]RentalProperty property)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _manager.EditRentalProperty(id, property);
            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest();
        }

         [Authorize]
         [HttpPost("onsale")]
       //  [RequestFormLimits(MultipartBodyLengthLimit = long.MaxValue)]
        public async Task<IActionResult> AddOnSaleProperty([FromForm]OnSaleProperty property)
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

            return BadRequest();
        }

          [Authorize]
         [HttpPut("onsale/{id}")]
       //  [RequestFormLimits(MultipartBodyLengthLimit = long.MaxValue)]
        public async Task<IActionResult> EditOnSaleProperty([FromRoute]int id, [FromBody]OnSaleProperty property)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _manager.EditOnSaleProperty(id, property);
            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest();
        }

       [Authorize]
        [HttpGet("onsale/{id}/deactivate")]
        public IActionResult DeactivateOnSaleProperty([FromRoute]int id)
        {
            _manager.DeactivateProperty(id, "onsale");
            return Ok();
        }

         [Authorize]
        [HttpGet("rental/{id}/deactivate")]
        public IActionResult DeactivateRentalProperty([FromRoute]int id)
        {
            _manager.DeactivateProperty(id, "rental");
            return Ok();
        }

         [Authorize]
         [HttpGet("industrial/{id}/deactivate")]
        public IActionResult DeactivateIndustrialProperty([FromRoute]int id)
        {
            _manager.DeactivateProperty(id, "industrial");
            return Ok();
        }

        [Authorize]
        [HttpGet("landproperty/{id}/deactivate")]
        public IActionResult DeactivateLandProperty([FromRoute]int id)
        {
            _manager.DeactivateProperty(id, "landproperty");
            return Ok();
        }


      
       [Authorize]
        [HttpGet("industrial/{providerId}/provider")]
        public async Task<IActionResult> GetIndustrialPropertyByProvider([FromRoute]int providerId)
        {
            return Ok (await _manager.GetIndustrialPropertyByProvider(providerId));
        }

        
        [Authorize]
        [HttpPost("industrial")]
       // [RequestFormLimits(MultipartBodyLengthLimit = long.MaxValue)]
        public async Task<IActionResult> AddIndustrialProperty([FromForm]CommercialProperty property)
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

            return BadRequest();
        }

         [Authorize]
        [HttpPut("industrial/{id}")]
       // [RequestFormLimits(MultipartBodyLengthLimit = long.MaxValue)]
        public async Task<IActionResult> EditCommercialProperty([FromRoute] int id, [FromBody]CommercialProperty property)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _manager.EditCommercialProperty(id, property);
            if (result != null)
            {
               return Ok(result);
            }

            return BadRequest();
        }

        [Authorize]
        [HttpPost("landproperty")]
       // [RequestFormLimits(MultipartBodyLengthLimit = long.MaxValue)]
        public async Task<IActionResult> AddLandProperty([FromForm]LandProperty property)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _manager.AddLandProperty(property);
            if (result != null)
            {
               return Ok(result);
            }

            return BadRequest();
        }

        [Authorize]
        [HttpPut("landproperty/{id}")]
       // [RequestFormLimits(MultipartBodyLengthLimit = long.MaxValue)]
        public async Task<IActionResult> EditLandProperty([FromRoute]int id, [FromBody]LandProperty property)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _manager.EditLandProperty(id, property);
            if (result != null)
            {
               return Ok(result);
            }

            return BadRequest();
        }

        [Authorize]
        [HttpGet("land/{providerId}/provider")]
        public async Task<IActionResult> GetLandPropertyByProvider([FromRoute]int providerId)
        {
            return Ok (await _manager.GetIndustrialPropertyByProvider(providerId));
        }


        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]ProviderLoginDto loginDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _providerRepo.ProviderLogin(loginDto);
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

            return Ok(await _providerRepo.GetProviderDataComplete((int)id));
        }


        [HttpPost("emergencyProperty")]
        public IActionResult AddEmergencyProperty([FromBody]EmergencyProperty property)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _providerRepo.AddEmergencyProperty(property);

            return Ok();

        }




        [HttpPost("register")]
        public async Task<IActionResult> Register([FromForm]ProviderModel provider)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _providerRepo.CreateProvider(provider);

            return Ok(result);
        }

        [HttpPost("subscription")]
        public IActionResult CreateSubscription([FromBody]SubModel submodel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = _sub.Populate(submodel);

            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest("cannot update model data");
        }

        [HttpGet("subscription/{loginid}")]
        public IActionResult GetSubscriptionData([FromRoute]string loginId)
        {
            var result = _sub.GetUserDataPlan(loginId);

            if(result != null)
            {
                return  Ok(result);
            }    
            return NotFound("user not found");
        }


        [HttpPost("subscription/propertylimit/{id}")]
        public async Task<IActionResult> IsPropertyLimitReachedAsync([FromRoute]int id, [FromBody]SubModel sub){
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await  _sub.IsPropertyLimitOver(id, sub);

           return Ok(result);
        }


        [HttpPost("subscription/subscriptionover/{loginId}")]
        public IActionResult IsSubcriptionOver([FromRoute]string loginId, [FromBody]DuedateClass duedate)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = _sub.IsSubscriptionOver(loginId, duedate.duedate);

            return Ok(result);
        }

        [HttpPost("subscription/upgrade/{userSubId}/{newPlan}")]
        public IActionResult UpgradeSubscription([FromRoute]int userSubId, [FromRoute]int newPlan)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

             _sub.UpdateUserData(userSubId, newPlan);

             return Ok();
        }

    }

    public class DuedateClass{
        public string duedate;
    }

    public class Upgrade{
        public int userSubId; 
        public int newPlan;
    }
}