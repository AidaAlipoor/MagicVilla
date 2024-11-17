using DataAccess.Entities;

namespace Business.ViewModels
{
    public class LoginResponseViewModel
    {
        public LocalUser User { get; set; }
        public string Token { get; set; }
    }

}
