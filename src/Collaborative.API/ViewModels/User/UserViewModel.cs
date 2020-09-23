namespace Collaborative.API.ViewModels.User
{
    public class UserViewModel
    {
        public UserViewModel(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public string Email { get; set; }
        public string Password { get; set; }
    }
}
