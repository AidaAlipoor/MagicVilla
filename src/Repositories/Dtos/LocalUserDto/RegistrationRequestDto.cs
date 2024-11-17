using System.Drawing;

namespace Business.Dtos.LocalUserDto
{
    public class RegistrationRequestDto
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set;  }

    }
}
