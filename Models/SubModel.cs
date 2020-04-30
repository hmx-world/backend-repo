namespace tinder4apartment.Models 
{
    public class SubModel
    {
        public int Id  { get; set; }
        public string LoginId {get; set;}

        public Plan Plan {get; set;}

        public string DueDate {get; set;}
        public int PropertyLimit {get; set;}
        public string Email { get; set; }         
    }

    public enum Plan
    {
        Business, Pro , Premium
    }
}