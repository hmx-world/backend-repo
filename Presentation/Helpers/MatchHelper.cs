using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using server.Core.Models;
using tinder4apartment.Models;
using tinder4apartment.Repo;

namespace server.Presentation.Helpers
{
    public class MatchHelper
    {
        private readonly IMatchRepo _match;
        private readonly IPropertyManager  _manager;
        public MatchHelper(IMatchRepo match, IPropertyManager manager )
        {
            _match = match;
            _manager = manager;
        }  


        public async Task<IEnumerable<RentalPropertyIndex>> MatchRentalPropertyByFirm(int firmId, UserQuery query)
        {
            
            var propertyList = await _manager.GetActiveRentalPropertyByProvider(firmId);

            var result = _match.MatchRentalProperty(query, propertyList);

            string stringQuery = $"Number of occupants: {query.NumberofAdult + query.NumberofChildren}. max price: {query.maxPrice}, min price: {query.minPrice}";
            string location = $"{query.City}, {query.State}";
            _manager.AddSearchQueryToLog(stringQuery, location,firmId, PropertyType.ResidentialForRent, result.Count, 0);

            return result.OrderByDescending(m => m.Rank);
        }

       
        public async Task<IEnumerable<OnSalePropertyIndex>> MatchOnSalePropertyByFirm(int firmId, UserQuery query)
        {
           
            var propertyList = await _manager.GetActiveOnSalePropertyByProvider(firmId);

            var result = _match.MatchOnSaleProperty(query, propertyList);

            string stringQuery = $"Number of occupants: {query.NumberofAdult + query.NumberofChildren}. max price: {query.maxPrice}, min price: {query.minPrice}";
            string location = $"{query.City}, {query.State}";
            _manager.AddSearchQueryToLog(stringQuery, location,firmId, PropertyType.ResidentialForSale, result.Count, 0);

            return result.OrderByDescending(m => m.Rank);
        }

      
        public async  Task<IEnumerable<RentalPropertyIndex>> MatchRentalProperty(UserQuery query)
        {
           
            var propertyList = await _manager.GetAllActiveRentalProperty();

            var result = _match.MatchRentalProperty(query, propertyList);

            string stringQuery = $"Number of occupants: {query.NumberofAdult + query.NumberofChildren}. max price: {query.maxPrice}, min price: {query.minPrice}";
            string location = $"{query.City}, {query.State}";
            _manager.UpdateSearchQueryToLog(stringQuery, location, PropertyType.ResidentialForRent,0, result.Count);

            return result.OrderByDescending(m => m.Rank);
        }

      
        public async Task<IEnumerable<OnSalePropertyIndex>> MatchOnSaleProperty(UserQuery query)
        {
           

            var propertyList = await _manager.GetAllActiveOnSaleProperty();

            var result = _match.MatchOnSaleProperty(query, propertyList);

            string stringQuery = $"Number of occupants: {query.NumberofAdult + query.NumberofChildren}. max price: {query.maxPrice}, min price: {query.minPrice}";
            string location = $"{query.City}, {query.State}";
            _manager.UpdateSearchQueryToLog(stringQuery, location, PropertyType.ResidentialForSale,0, result.Count);

            return result.OrderByDescending(m => m.Rank);
        }


        
        public async Task<IEnumerable<CommercialPropertyIndex>> MatchCommercialRentalPropertyByFirm(int firmId, CommercialQuery query)
        {
            
            var propertyList = await _manager.GetActiveIndustrialPropertyByProvider(firmId);

            var result = _match.MatchCommercialProperty(query, Purpose.Rent, propertyList);

            string stringQuery = $"Number of rooms: {query.NumberOfRooms}. max price: {query.maxPrice}, min price: {query.minPrice}";
            string location = $"{query.City}, {query.State}";
            _manager.AddSearchQueryToLog(stringQuery, location,firmId, PropertyType.CommercialForRent, result.Count, 0);

            return result.OrderByDescending(m => m.Rank);
        }

       
        public async Task<IEnumerable<CommercialPropertyIndex>> MatchCommercialSalePropertyByFirm(int firmId, CommercialQuery query)
        {
           
            var propertyList = await _manager.GetActiveIndustrialPropertyByProvider(firmId);

            var result = _match.MatchCommercialProperty(query, Purpose.Sale, propertyList);

             string stringQuery = $"Number of rooms: {query.NumberOfRooms}. max price: {query.maxPrice}, min price: {query.minPrice}";
            string location = $"{query.City}, {query.State}";
            _manager.AddSearchQueryToLog(stringQuery, location,firmId, PropertyType.CommercialForRent, result.Count, 0);

            return result.OrderByDescending(m => m.Rank);
        }


       
        public async Task<IEnumerable<CommercialPropertyIndex>> MatchCommercialRentalProperty( CommercialQuery query)
        {
          
            var propertyList = await _manager.GetActiveIndustrialProperty();

            var result = _match.MatchCommercialProperty(query, Purpose.Rent, propertyList);

             string stringQuery = $"Number of rooms: {query.NumberOfRooms}. max price: {query.maxPrice}, min price: {query.minPrice}";
            string location = $"{query.City}, {query.State}";
            _manager.UpdateSearchQueryToLog(stringQuery, location, PropertyType.CommercialForRent,  0, result.Count);

            return result.OrderByDescending(m => m.Rank);
        }

    
        public  async Task<IEnumerable<CommercialPropertyIndex>> MatchCommercialSaleProperty(CommercialQuery query)
        {
            
            var propertyList = await _manager.GetActiveIndustrialProperty();

            var result = _match.MatchCommercialProperty(query, Purpose.Sale, propertyList);

            string stringQuery = $"Number of rooms: {query.NumberOfRooms}. max price: {query.maxPrice}, min price: {query.minPrice}";
            string location = $"{query.City}, {query.State}";
            _manager.UpdateSearchQueryToLog(stringQuery, location, PropertyType.CommercialForSale, 0, result.Count);

            return result.OrderByDescending(m => m.Rank);
        }

        
    }
}