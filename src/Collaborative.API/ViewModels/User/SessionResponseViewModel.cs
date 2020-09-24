namespace Collaborative.API.ViewModels.User
{
    public class SessionResponseViewModel
    {
        public SessionResponseViewModel(string email, string token)
        {
            Email = email;
            Token = token;
        }

        public string Email { get; set; }
        public string Token { get; set; }
    }
}
