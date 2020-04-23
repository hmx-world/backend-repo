using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tinder4apartment.Models;

namespace tinder4apartment.Repo
{
    public class MatchRepo : IMatchRepo
    {
        private static int locationScore = 4;
        public List<CommercialPropertyIndex> MatchCommercialProperty(CommercialQuery query, Purpose purpose, List<CommercialProperty> industrials)
        {
            List<CommercialPropertyIndex> indexedPropertyList = new List<CommercialPropertyIndex>();

            switch (purpose)
            {
                case Purpose.Rent:
                    industrials = industrials.Where( m => m.Purpose == Purpose.Rent).ToList();
                    industrials = industrials.Where( m => m.State.ToLower() == query.State.ToLower()).ToList();

                    foreach (var item in industrials)
                    {
                        double roomPoint = RoomRank(item.NumberOfBedrooms, query.NumberOfRooms);
                        double pricePoint = PriceRank(item.Price, query.minPrice, query.maxPrice);
                        var propertyIndex = new CommercialPropertyIndex(){
                            Id = item.Id,
                            ImageLink1 = item.ImageLink1,
                            ImageLink2 = item.ImageLink2,
                            ImageLink3 = item.ImageLink3,
                            City = item.City,
                            State = item.State,
                            Name = item.Name,
                            ProviderName = item.ProviderName,
                            Price = item.Price,
                            ParkingSpace = item.ParkingSpace,
                            Area = item.Area,
                            Purpose = item.Purpose,
                            NumberOfBedrooms = item.NumberOfBedrooms,
                            NeighbourhoodSecurity = item.NeighbourhoodSecurity,
                            Extras = item.Extras,
                            BuildingType = item.BuildingType,
                            IsActive = item.IsActive
                        };
                        
                        propertyIndex.Rank = roomPoint + pricePoint;

                        if (item.City.ToLower() == query.City.ToLower())
                        {
                            propertyIndex.Rank = propertyIndex.Rank + locationScore;
                        }

                        indexedPropertyList.Add(propertyIndex);
                    }

                    return indexedPropertyList;

                case Purpose.Sale:
                    industrials = industrials.Where( m => m.Purpose == Purpose.Sale).ToList();
                    industrials = industrials.Where( m => m.State.ToLower() == query.State.ToLower()).ToList();

                    foreach (var item in industrials)
                    {
                        double roomPoint = RoomRank(item.NumberOfBedrooms, query.NumberOfRooms);
                        double pricePoint = PriceRank(item.Price, query.minPrice, query.maxPrice);
                        var propertyIndex = new CommercialPropertyIndex(){
                            Id = item.Id,
                            ImageLink1 = item.ImageLink1,
                            ImageLink2 = item.ImageLink2,
                            ImageLink3 = item.ImageLink3,
                            City = item.City,
                            State = item.State,
                            Name = item.Name,
                            ProviderName = item.ProviderName,
                            Price = item.Price,
                            ParkingSpace = item.ParkingSpace,
                            Area = item.Area,
                            Purpose = item.Purpose,
                            NumberOfBedrooms = item.NumberOfBedrooms,
                            NeighbourhoodSecurity = item.NeighbourhoodSecurity,
                            Extras = item.Extras,
                            BuildingType = item.BuildingType,
                            IsActive = item.IsActive
                        };
                        
                        propertyIndex.Rank = roomPoint + pricePoint;

                        if (item.City.ToLower() == query.City.ToLower())
                        {
                            propertyIndex.Rank = propertyIndex.Rank + locationScore;
                        }

                        indexedPropertyList.Add(propertyIndex);
                    }

                    return indexedPropertyList;
                default:
                    break;
            }

            return null;
        }

        public List<OnSalePropertyIndex> MatchOnSaleProperty(UserQuery query, List<OnSaleProperty> onsale)
        {
           List<OnSalePropertyIndex> indexedPropertyList = new List<OnSalePropertyIndex>();

            onsale = onsale.Where(m => m.State.ToLower() == query.State.ToLower()).ToList();

            
        
            foreach (var item in onsale)
            {
                double roomPoint = RoomRank(item.NumberOfBedrooms, (query.NumberofAdult + query.NumberofChildren));
                double pricePoint = PriceRank(item.Price, query.minPrice, query.maxPrice);
           

                var propertyIndex = new OnSalePropertyIndex(){
                    Id = item.Id,
                    ImageLink1 = item.ImageLink1,
                    ImageLink2 = item.ImageLink2,
                    ImageLink3 = item.ImageLink3,
                    City = item.City,
                    State = item.State,
                    Name = item.Name,
                    ProviderName = item.ProviderName,
                    Price = item.Price,
                    LandArea = item.LandArea,
                    Title = item.Title,
                    SiteDescription = item.SiteDescription,
                    NumberOfBedrooms = item.NumberOfBedrooms,
                    NeighbourhoodSecurity = item.NeighbourhoodSecurity,
                    Extras = item.Extras,
                    BuildingType = item.BuildingType,
                    IsActive = item.IsActive
                };
                
                propertyIndex.Rank = roomPoint + pricePoint;

                if (item.City.ToLower() == query.City.ToLower())
                {
                    propertyIndex.Rank = propertyIndex.Rank + locationScore;
                }

                indexedPropertyList.Add(propertyIndex);
            }

            return indexedPropertyList;
        }

        public List<RentalPropertyIndex> MatchRentalProperty(UserQuery query, List<RentalProperty> rentals)
        {
            List<RentalPropertyIndex> indexedPropertyList = new List<RentalPropertyIndex>();

            rentals = rentals.Where(m=> m.State.ToLower() == query.State.ToLower()).ToList();

         
            foreach (var item in rentals)
            {
                double roomPoint = RoomRank(item.NumberOfBedrooms, (query.NumberofAdult + query.NumberofChildren));
                double pricePoint = PriceRank(item.Price, query.minPrice, query.maxPrice);
              
                var propertyIndex = new RentalPropertyIndex(){
                    Id = item.Id,
                    ImageLink1 = item.ImageLink1,
                    ImageLink2 = item.ImageLink2,
                    ImageLink3 = item.ImageLink3,
                    City = item.City,
                    State = item.State,
                    Name = item.Name,
                    ProviderName = item.ProviderName,
                    Price = item.Price,
                    Light24hours = item.Light24hours,
                    WaterSupply = item.WaterSupply,
                    NumberOfBedrooms = item.NumberOfBedrooms,
                    NeighbourhoodSecurity = item.NeighbourhoodSecurity,
                    Extras = item.Extras,
                    BuildingType = item.BuildingType,
                    IsActive = item.IsActive
                };
                
                propertyIndex.Rank = roomPoint + pricePoint;

                if (item.City.ToLower() == query.City.ToLower())
                {
                    propertyIndex.Rank = propertyIndex.Rank + locationScore;
                }

                indexedPropertyList.Add(propertyIndex);
            }

            return indexedPropertyList;
        }


        private double RoomRank(int numberBedrooms, int numberOfAdultandChildren )
        {
            switch (numberBedrooms)
                {
                    case int numRooms when numRooms  == (numberOfAdultandChildren):
                        return 2.7;
                    case int numRooms when numRooms  == (numberOfAdultandChildren + 1):
                        return 1.62;
                    case int numRooms when numRooms  == (numberOfAdultandChildren -1):
                        return 1.08;
                    case int numRooms when numRooms  == (numberOfAdultandChildren - 2):
                        return 0.02;
                    default:
                        return 0;
                }
        }

        private double PriceRank(double normalPrice, double minPrice, double maxPrice)
        {
            if (normalPrice > minPrice && normalPrice < maxPrice)
            {
                return 3;
            }
            if (normalPrice < minPrice )
            {
                return 2;
            }
            else{
                return 1;
            }
        }

       
    }


    public class RentalPropertyIndex: RentalProperty
    {
        public double Rank { get; set; }
    }


    public class OnSalePropertyIndex: OnSaleProperty
    {
        public double Rank { get; set; }
    }

    public class CommercialPropertyIndex: CommercialProperty
    {
        public double Rank { get; set; }
    }


   
}