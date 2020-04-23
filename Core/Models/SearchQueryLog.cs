using System;
using tinder4apartment.Models;

namespace server.Core.Models
{
    public class SearchQueryLog
    {
        public int Id { get; set; }
        public string SearchQuery { get; set; }
        public string SearchLocation { get; set; }
        public string QueriedFirm { get; set; }
        public Purpose purpose { get; set; }
        public int CountResultFoundInQueriedFirm { get; set; }
        public int CountResultFoundInOtherFirms { get; set; }
        public DateTime DateQueried { get; set; }
    }

    
}