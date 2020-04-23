using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using server.Core.Models;
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
            var property = await _manager.GetOneRentalProperty((int)id);
            if(property == null)
            {
                return NotFound();
            }

            return Ok(property);
        }

        [HttpGet("onsale/{id}")]
        public async Task<IActionResult> GetOneOnSaleProperty([FromRoute]int? id)
        {
             if (id == null)
            {
                return BadRequest("Provide an Id");
            }
            
            var property = await _manager.GetOneOnSaleProperty((int)id);
            if(property == null)
            {
                return NotFound();
            }

            return Ok(property);
        }

        [HttpGet("active/rental/{providerId}/provider")]
        public async Task<IActionResult> GetActiveRentalPropertyByProvider([FromRoute]int? providerId)
        {
             if (providerId == null)
            {
                return BadRequest("Provide an provider id");
            }
            return Ok(await _manager.GetActiveRentalPropertyByProvider((int)providerId));
        }

        [HttpGet("active/onsale/{providerId}/provider")]
        public async Task<IActionResult> GetActiveOnSalePropertyByProvider([FromRoute]int? providerId)
        {
              if (providerId == null)
            {
                return BadRequest("Provide an provider id");
            }
            return Ok(await _manager.GetActiveOnSalePropertyByProvider((int)providerId));
        }


        [HttpPost("active/rental/match/{providerId}")]
        public async Task<IActionResult> MatchRentalPropertyByProvider([FromRoute]int providerId, [FromBody]UserQuery query)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var propertyList = await _manager.GetActiveRentalPropertyByProvider(providerId);

            var result = _match.MatchRentalProperty(query, propertyList);

            string stringQuery = $"Number of occupants: {query.NumberofAdult + query.NumberofChildren}. max price: {query.maxPrice}, min price: {query.minPrice}";
            string location = $"{query.City}, {query.State}";
            _manager.AddSearchQueryToLog(stringQuery, location,providerId, PropertyType.ResidentialForRent, result.Count, 0);

            return Ok(result.OrderByDescending(m => m.Rank));
        }

        [HttpPost("active/onsale/match/{providerId}")]
        public async Task<IActionResult> MatchOnSalePropertyByProvider([FromRoute]int providerId, [FromBody]UserQuery query)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var propertyList = await _manager.GetActiveOnSalePropertyByProvider(providerId);

            var result = _match.MatchOnSaleProperty(query, propertyList);

            string stringQuery = $"Number of occupants: {query.NumberofAdult + query.NumberofChildren}. max price: {query.maxPrice}, min price: {query.minPrice}";
            string location = $"{query.City}, {query.State}";
            _manager.AddSearchQueryToLog(stringQuery, location,providerId, PropertyType.ResidentialForSale, result.Count, 0);

            return Ok(result.OrderByDescending(m => m.Rank));
        }


         [HttpPost("active/rental/match")]
        public async Task<IActionResult> MatchRentalProperty([FromBody]UserQuery query)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var propertyList = await _manager.GetAllActiveRentalProperty();

            var result = _match.MatchRentalProperty(query, propertyList);

            string stringQuery = $"Number of occupants: {query.NumberofAdult + query.NumberofChildren}. max price: {query.maxPrice}, min price: {query.minPrice}";
            string location = $"{query.City}, {query.State}";
            _manager.UpdateSearchQueryToLog(stringQuery, location, PropertyType.ResidentialForRent,0, result.Count);

            return Ok(result.OrderByDescending(m => m.Rank));
        }

        [HttpPost("active/onsale/match")]
        public async Task<IActionResult> MatchOnSaleProperty([FromBody]UserQuery query)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var propertyList = await _manager.GetAllActiveOnSaleProperty();

            var result = _match.MatchOnSaleProperty(query, propertyList);

            string stringQuery = $"Number of occupants: {query.NumberofAdult + query.NumberofChildren}. max price: {query.maxPrice}, min price: {query.minPrice}";
            string location = $"{query.City}, {query.State}";
            _manager.UpdateSearchQueryToLog(stringQuery, location, PropertyType.ResidentialForSale,0, result.Count);

            return Ok(result.OrderByDescending(m => m.Rank));
        }




        [HttpGet("active/industrial/all")]
        public async Task<IActionResult> GetIndustrialProperty()
        {
            return Ok (await _manager.GetActiveIndustrialProperty());
        }

        [HttpGet("active/industrial/{providerId}/provider")]
        public async Task<IActionResult> GetIndustrialPropertyByProvider([FromRoute]int? providerId)
        {
            if(providerId == null)
            {
                return BadRequest("provide a provider id");
            }
            return Ok (await _manager.GetActiveIndustrialPropertyByProvider((int)providerId));
        }

         [HttpGet("industrial/{id}")]
        public async Task<IActionResult> GetOneIndustrialProperty([FromRoute]int? id)
        {
            if(id == null)
            {
                return BadRequest("provide a provider id");
            }
            var property = await _manager.GetOneIndustrialProperty((int)id);
            if(property == null)
            {
                return NotFound();
            }

            return Ok(property);
        }


        [HttpPost("active/industrial/rent/match/{providerId}")]
        public async Task<IActionResult> MatchIndustrialRentalPropertyByProvider([FromRoute]int providerId, [FromBody]CommercialQuery query)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var propertyList = await _manager.GetActiveIndustrialPropertyByProvider(providerId);

            var result = _match.MatchCommercialProperty(query, Purpose.Rent, propertyList);

            string stringQuery = $"Number of rooms: {query.NumberOfRooms}. max price: {query.maxPrice}, min price: {query.minPrice}";
            string location = $"{query.City}, {query.State}";
            _manager.AddSearchQueryToLog(stringQuery, location,providerId, PropertyType.CommercialForRent, result.Count, 0);

            return Ok(result.OrderByDescending(m => m.Rank));
        }

        [HttpPost("active/industrial/sale/match/{providerId}")]
        public async Task<IActionResult> MatchIndustrialSalePropertyByProvider([FromRoute]int providerId, [FromBody]CommercialQuery query)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var propertyList = await _manager.GetActiveIndustrialPropertyByProvider(providerId);

            var result = _match.MatchCommercialProperty(query, Purpose.Sale, propertyList);

             string stringQuery = $"Number of rooms: {query.NumberOfRooms}. max price: {query.maxPrice}, min price: {query.minPrice}";
            string location = $"{query.City}, {query.State}";
            _manager.AddSearchQueryToLog(stringQuery, location,providerId, PropertyType.CommercialForRent, result.Count, 0);

            return Ok(result.OrderByDescending(m => m.Rank));
        }


        [HttpPost("active/industrial/rent/match")]
        public async Task<IActionResult> MatchIndustrialRentalProperty( [FromBody]CommercialQuery query)
        {
              if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var propertyList = await _manager.GetActiveIndustrialProperty();

            var result = _match.MatchCommercialProperty(query, Purpose.Rent, propertyList);

             string stringQuery = $"Number of rooms: {query.NumberOfRooms}. max price: {query.maxPrice}, min price: {query.minPrice}";
            string location = $"{query.City}, {query.State}";
            _manager.UpdateSearchQueryToLog(stringQuery, location, PropertyType.CommercialForRent,  0, result.Count);

            return Ok(result.OrderByDescending(m => m.Rank));
        }

        [HttpPost("active/industrial/sale/match")]
        public async Task<IActionResult> MatchIndustrialSaleProperty([FromBody]CommercialQuery query)
        {
              if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var propertyList = await _manager.GetActiveIndustrialProperty();

            var result = _match.MatchCommercialProperty(query, Purpose.Sale, propertyList);

            string stringQuery = $"Number of rooms: {query.NumberOfRooms}. max price: {query.maxPrice}, min price: {query.minPrice}";
            string location = $"{query.City}, {query.State}";
            _manager.UpdateSearchQueryToLog(stringQuery, location, PropertyType.CommercialForSale, 0, result.Count);

            return Ok(result.OrderByDescending(m => m.Rank));
        }

        [HttpPost("active/Land/sale/match")]
        public async Task<IActionResult> MatchLandProperty([FromBody]LandPropertyQuery query)
        {
              if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var propertyList = await _manager.GetAllActiveLandProperties();

            var result = _match.MatchOnLandProperty(query, propertyList);

             string stringQuery = $"Land Area: {query.area}. max price: {query.maxPrice}, min price: {query.minPrice}";
            string location = $"{query.City}, {query.State}";
            _manager.UpdateSearchQueryToLog(stringQuery, location, PropertyType.LandProperty, 0, result.Count);

            return Ok(result.OrderByDescending(m => m.Rank));
        }

        [HttpPost("active/Land/sale/match/{providerId}")]
        public async Task<IActionResult> MatchLandPropertyByProvider([FromRoute]int providerId, [FromBody]LandPropertyQuery query)
        {
              if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var propertyList = await _manager.GetAllActiveLandPropertiesByFirm(providerId);

            var result = _match.MatchOnLandProperty(query, propertyList);

            
             string stringQuery = $"Land Area: {query.area}. max price: {query.maxPrice}, min price: {query.minPrice}";
            string location = $"{query.City}, {query.State}";
            _manager.AddSearchQueryToLog(stringQuery, location,providerId, PropertyType.CommercialForRent, result.Count, 0);

            return Ok(result.OrderByDescending(m => m.Rank));
        }

        [HttpGet("active/landproperties/all")]
        public async Task<IActionResult> GetActiveLandProperty()
        {
            return Ok(await _manager.GetAllActiveLandProperties());
        }

        [HttpGet("active/landproperties/{providerId}/provider")]
        public async Task<IActionResult> GetActiveLandPropertyByProvider([FromRoute]int? providerId)
        {
            if(providerId == null)
            {
                return BadRequest("provide a provider id");
            }
            return Ok(await _manager.GetAllActiveLandPropertiesByFirm((int)providerId));
        }

        [HttpGet("landproperty/{id}")]
        public async Task<IActionResult> GetOneLandProperty([FromRoute]int? id)
        {
            if(id == null)
            {
                return BadRequest("provide a provider id");
            }   
            var property = await _manager.GetOneLandProperty((int)id);
            if(property == null)
            {
                return NotFound();
            }

            return Ok(property);
        }


        [HttpPost("provider-action")]
        public IActionResult GoForPropertyCheck([FromBody]GoForCheckOrRedirect providerAction)
        {
            if (ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            providerAction.DateCreated = DateTime.Now;
            _manager.AddProviderAction(providerAction);

            return Ok();
        }


        [HttpGet("providers")]
        public async Task<IActionResult> GetProvidersName()
        {
            return Ok(await _manager.GetProviders());
        }

        [HttpGet("provider/{id}")]
        public async Task<IActionResult> GetOneProvider([FromRoute]int id)
        {
            return Ok( await _manager.GetOneProvider(id));
        }

    }

   
}