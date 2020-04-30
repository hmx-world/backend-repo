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

     public class GoForCheckOrRedirectDTO : GoForCheckOrRedirect
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string PropertyLocation {get; set;}

        public new string PropertyType {get; set;}

        public string FirmName {get; set;}
        public string FirmLocation { get; set; }

        public new string FirmAction {get; set;}
        public new string DateCreated {get; set;}
    }
}