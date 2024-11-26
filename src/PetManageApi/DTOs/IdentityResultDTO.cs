namespace PetManageApi.DTOs
{
    public class IdentityResultDTO
    {
        public bool success { get; set; }
        public string errorMessage { get; set; }
        public List<string> error { get; set; }
        public string result { get; set; }
        public List<object> resultObject { get; set; }
    }
}
