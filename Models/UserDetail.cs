using Microsoft.AspNetCore.Identity;

namespace HastaneWeb.Models
{
    public class UserDetail : IdentityUser
    {
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
    }
}
