namespace GDSDemo.RequestModels
{
    public class UserFormDataRequestModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string CountryOfResidence { get; set; }
        public IList<string> Interests { get; set; }
    }
}
