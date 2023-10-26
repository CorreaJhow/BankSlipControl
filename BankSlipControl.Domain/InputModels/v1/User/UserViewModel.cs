namespace BankSlipControl.Domain.InputModels.v1.User
{
    public class UserViewModel
    {
        public string Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string AccessToken { get; set; }
    }
}
