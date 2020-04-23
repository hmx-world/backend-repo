using System.Collections.Generic;
using System.Threading.Tasks;
using tinder4apartment.Models;

namespace tinder4apartment.Repo
{
    public interface IMatchRepo
    {
        List<RentalPropertyIndex> MatchRentalProperty(UserQuery query, List<RentalProperty> rentals);

        List<OnSalePropertyIndex> MatchOnSaleProperty(UserQuery query, List<OnSaleProperty> onsale);


        List<CommercialPropertyIndex> MatchCommercialProperty(CommercialQuery query, Purpose purpose, List<CommercialProperty> industrials);
    }
}