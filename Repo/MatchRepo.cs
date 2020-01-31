using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tinder4apartment.Models;

namespace tinder4apartment.Repo
{
    public class MatchRepo : IMatchRepo
    {
        public List<IndustrialPropertyIndex> MatchIndustrialProperty(IndustrialQuery query, Mode mode, List<IndustrialProperty> industrials)
        {
            List<IndustrialPropertyIndex> indexedPropertyList = new List<IndustrialPropertyIndex>();

            switch (mode)
            {
                case Mode.Rent:
                    industrials = industrials.Where( m => m.Mode == Mode.Rent).ToList();
                    industrials = industrials.Where( m => m.State == query.State).ToList();

                    foreach (var item in industrials)
                    {
                        int roomPoint = RoomRank(item.NumberOfBedrooms, query.NumberOfRooms);
                        var propertyIndex = new IndustrialPropertyIndex(){
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
                            Mode = item.Mode,
                            NumberOfBedrooms = item.NumberOfBedrooms,
                            NeighbourhoodSecurity = item.NeighbourhoodSecurity,
                            Extras = item.Extras,
                            BuildingType = item.BuildingType,
                            IsActive = item.IsActive
                        };
                        
                        propertyIndex.Rank = roomPoint;

                        if (item.City == query.City)
                        {
                            propertyIndex.Rank = propertyIndex.Rank +3;
                        }

                        indexedPropertyList.Add(propertyIndex);
                    }

                    return indexedPropertyList;

                case Mode.Sale:
                    industrials = industrials.Where( m => m.Mode == Mode.Sale).ToList();
                    industrials = industrials.Where( m => m.State == query.State).ToList();

                    foreach (var item in industrials)
                    {
                        int roomPoint = RoomRank(item.NumberOfBedrooms, query.NumberOfRooms);
                        var propertyIndex = new IndustrialPropertyIndex(){
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
                            Mode = item.Mode,
                            NumberOfBedrooms = item.NumberOfBedrooms,
                            NeighbourhoodSecurity = item.NeighbourhoodSecurity,
                            Extras = item.Extras,
                            BuildingType = item.BuildingType,
                            IsActive = item.IsActive
                        };
                        
                        propertyIndex.Rank = roomPoint;

                        if (item.City == query.City)
                        {
                            propertyIndex.Rank = propertyIndex.Rank +3;
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

            onsale = onsale.Where(m => m.State == query.State).ToList();

            
            if (query.AvgChildrenAge == 0)
            {
                query.AvgChildrenAge = 18;
            }

            foreach (var item in onsale)
            {
                int roomPoint = RoomRank(item.NumberOfBedrooms, (query.NumberofAdult + query.NumberofChildren));
                int securityPoint = SecrityRank(item.NeighbourhoodSecurity, query.AvgChildrenAge);

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
                
                propertyIndex.Rank = roomPoint + securityPoint;

                if (item.City == query.City)
                {
                    propertyIndex.Rank = propertyIndex.Rank + 2;
                }

                indexedPropertyList.Add(propertyIndex);
            }

            return indexedPropertyList;
        }

        public List<RentalPropertyIndex> MatchRentalProperty(UserQuery query, List<RentalProperty> rentals)
        {
            List<RentalPropertyIndex> indexedPropertyList = new List<RentalPropertyIndex>();

            rentals = rentals.Where(m=> m.State == query.State).ToList();

            if (query.AvgChildrenAge == 0)
            {
                query.AvgChildrenAge = 18;
            }

            foreach (var item in rentals)
            {
                int roomPoint = RoomRank(item.NumberOfBedrooms, (query.NumberofAdult + query.NumberofChildren));
                int securityPoint = SecrityRank(item.NeighbourhoodSecurity, query.AvgChildrenAge);

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
                
                propertyIndex.Rank = roomPoint + securityPoint;

                if (item.City == query.City)
                {
                    propertyIndex.Rank = propertyIndex.Rank + 2;
                }

                indexedPropertyList.Add(propertyIndex);
            }

            return indexedPropertyList;
        }


        private int RoomRank(int numberBedrooms, int numberOfAdultandChildren )
        {
            switch (numberBedrooms)
                {
                    case int numRooms when numRooms  == (numberOfAdultandChildren):
                        return 5;
                    case int numRooms when numRooms  == (numberOfAdultandChildren + 1):
                        return 3;
                    case int numRooms when numRooms  == (numberOfAdultandChildren -1):
                        return 2;
                    case int numRooms when numRooms  == (numberOfAdultandChildren - 2):
                        return 1;
                    default:
                        return 0;
                }
        }

        private int SecrityRank(int securityLevel, int age)
        {
           int security = securityLevel;
           int avgAge = age;

            if (avgAge >= 10 && security >= 5 && security <= 7)
            {
                return 1;
            }

            else if(avgAge >= 10 && security >= 8 && security <= 10)
            {
                return 2;
            }

            else if(avgAge < 10 && security < 5 && security >= 3)
            {
                return -1;
            }

            else if(avgAge < 10 && security <= 2 && security >= 1)
            {
                return -2;
            }

            return 0;
        }
    }


    public class RentalPropertyIndex: RentalProperty
    {
        public int Rank { get; set; }
    }


    public class OnSalePropertyIndex: OnSaleProperty
    {
        public int Rank { get; set; }
    }

    public class IndustrialPropertyIndex: IndustrialProperty
    {
        public int Rank { get; set; }
    }


   
}