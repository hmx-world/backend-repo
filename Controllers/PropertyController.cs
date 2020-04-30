using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using server.Core.Models;
using server.Presentation.Helpers;
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
        private MatchHelper _matchHelper;
        public PropertyController(IPropertyManager manager, IMatchRepo match)
        {
            _manager = manager;
            _match = match;
            _matchHelper = new MatchHelper(match, manager);
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

        [HttpGet("active/rental/{firmId}/firm")]
        public async Task<IActionResult> GetActiveRentalPropertyByProvider([FromRoute]int? firmId)
        {
             if (firmId == null)
            {
                return BadRequest("Provide an firm id");
            }
            var result = await _manager.GetActiveRentalPropertyByProvider((int)firmId);

            if(result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet("active/onsale/{firmId}/firm")]
        public async Task<IActionResult> GetActiveOnSalePropertyByProvider([FromRoute]int? firmId)
        {
              if (firmId == null)
            {
                return BadRequest("Provide an firm id");
            }
            var result = await _manager.GetActiveOnSalePropertyByProvider((int)firmId);

            if(result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
 
        [HttpGet("active/commercial/all")]
        public async Task<IActionResult> GetIndustrialProperty()
        {
            return Ok (await _manager.GetActiveIndustrialProperty());
        }

        [HttpGet("active/commercial/{firmId}/firm")]
        public async Task<IActionResult> GetIndustrialPropertyByProvider([FromRoute]int? firmId)
        {
            if(firmId == null)
            {
                return BadRequest("provide a firm id");
            }
            var result = await _manager.GetActiveIndustrialPropertyByProvider((int)firmId);

            if(result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

         [HttpGet("commercial/{id}")]
        public async Task<IActionResult> GetOneIndustrialProperty([FromRoute]int? id)
        {
            if(id == null)
            {
                return BadRequest("provide a id");
            }
            var property = await _manager.GetOneIndustrialProperty((int)id);
            if(property == null)
            {
                return NotFound();
            }

            return Ok(property);
        }


          [HttpGet("active/landproperties/all")]
        public async Task<IActionResult> GetActiveLandProperty()
        {
            return Ok(await _manager.GetAllActiveLandProperties());
        }

        [HttpGet("active/landproperties/{firmId}/firm")]
        public async Task<IActionResult> GetActiveLandPropertyByProvider([FromRoute]int? firmId)
        {
            if(firmId == null)
            {
                return BadRequest("provide a firm id");
            }
            var result = await _manager.GetAllActiveLandPropertiesByFirm((int)firmId);

            if(result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet("landproperty/{id}")]
        public async Task<IActionResult> GetOneLandProperty([FromRoute]int? id)
        {
            if(id == null)
            {
                return BadRequest("provide a id");
            }   
            var property = await _manager.GetOneLandProperty((int)id);
            if(property == null)
            {
                return NotFound();
            }

            return Ok(property);
        }


#region match

        [HttpPost("residential/match/{firmId:int?}")]
        public async Task<IActionResult> MatchResidential([FromRoute]int? firmId, [FromBody]UserQuery query)
        {
            if(firmId == null)
            {
                return await MatchResidentialProperty(query);
            }
            else{
                return await MatchResidentialPropertyByFirm((int)firmId, query);
            }
        }

      
        public async Task<IActionResult> MatchResidentialPropertyByFirm([FromRoute]int firmId, [FromBody]UserQuery query)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else{
                switch (query.purpose)
                {
                    case Purpose.Rent:
                        return Ok(await _matchHelper.MatchRentalPropertyByFirm(firmId, query));
                    case Purpose.Sale: 
                        return Ok(await _matchHelper.MatchOnSalePropertyByFirm(firmId, query));
                    default:
                        return Ok(await _matchHelper.MatchRentalPropertyByFirm(firmId, query));
                }
            }
        }

       
        public async Task<IActionResult> MatchResidentialProperty([FromBody]UserQuery query)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else{
                switch (query.purpose)
                {
                    case Purpose.Rent:
                        return Ok(await _matchHelper.MatchRentalProperty(query));
                    case Purpose.Sale: 
                        return Ok(await _matchHelper.MatchOnSaleProperty(query));
                    default:
                        return Ok(await _matchHelper.MatchRentalProperty(query));
                }
            }
        }

        [HttpPost("commercial/match/{firmId:int?}")]
        public async Task<IActionResult> MatchCommercial([FromRoute]int? firmId, [FromBody]CommercialQuery query)
        {
            if(firmId == null)
            {
                return await MatchCommercialProperty(query);
            }
            else{
                return await MatchCommercialPropertyByFirm((int)firmId, query);
            }
        }

      
        public async Task<IActionResult> MatchCommercialPropertyByFirm([FromRoute]int firmId, [FromBody]CommercialQuery query)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else{
                switch (query.purpose)
                {
                    case Purpose.Rent:
                        return Ok(await _matchHelper.MatchCommercialRentalPropertyByFirm(firmId, query));
                    case Purpose.Sale: 
                        return Ok(await _matchHelper.MatchCommercialSalePropertyByFirm(firmId, query));
                    default:
                        return  Ok(await _matchHelper.MatchCommercialRentalPropertyByFirm(firmId, query));
                }
            }

        }
        
        public async Task<IActionResult> MatchCommercialProperty([FromBody]CommercialQuery query)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else{
                switch (query.purpose)
                {
                    case Purpose.Rent:
                        return Ok(await _matchHelper.MatchCommercialRentalProperty(query));
                    case Purpose.Sale: 
                        return Ok(await _matchHelper.MatchCommercialSaleProperty(query));
                    default:
                        return  Ok(await _matchHelper.MatchCommercialRentalProperty(query));
                }
            }

        }


         [HttpPost("landproperty/match/{firmId:int?}")]
        public async Task<IActionResult> MatchLandProperty([FromRoute]int? firmId, [FromBody]LandPropertyQuery query)
        {
            if(firmId == null)
            {
                return await MatchLandProperty(query);
            }
            else{
                return await MatchLandPropertyByFirm((int)firmId, query);
            }
        }


  
        public async Task<IActionResult> MatchLandProperty(LandPropertyQuery query)
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
        public async Task<IActionResult> MatchLandPropertyByFirm(int firmId, LandPropertyQuery query)
        {
              if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var propertyList = await _manager.GetAllActiveLandPropertiesByFirm(firmId);

            var result = _match.MatchOnLandProperty(query, propertyList);

            
             string stringQuery = $"Land Area: {query.area}. max price: {query.maxPrice}, min price: {query.minPrice}";
            string location = $"{query.City}, {query.State}";
            _manager.AddSearchQueryToLog(stringQuery, location,firmId, PropertyType.LandProperty, result.Count, 0);

            return Ok(result.OrderByDescending(m => m.Rank));
        }


      
      
#endregion


       


        [HttpPost("firm/action")]
        public IActionResult GoForPropertyCheck([FromBody]GoForCheckOrRedirect providerAction)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            providerAction.DateCreated = DateTime.Now;
            _manager.AddProviderAction(providerAction);

            return Ok();
        }


        [HttpGet("firms")]
        public async Task<IActionResult> GetFirmsName()
        {
            return Ok(await _manager.GetProviders());
        }

        [HttpGet("firm/{id}")]
        public async Task<IActionResult> GetOneFirm([FromRoute]int id)
        {
            return Ok( await _manager.GetOneProvider(id));
        }

    }

   
}