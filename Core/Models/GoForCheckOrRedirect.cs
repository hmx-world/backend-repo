using System;

namespace server.Core.Models
{
    public class GoForCheckOrRedirect
    {
        public int Id { get; set; }
        public int PropertyId { get; set; }
        public FirmAction FirmAction {get; set;}
        public DateTime DateCreated {get; set;}
        public PropertyType PropertyType { get; set; }
    }

    public enum FirmAction{
        GoForCheck, Redirect
    }
}