using System.ComponentModel.DataAnnotations;

namespace PokeAPI.Model
{
    public class UserLoginModel
    {
        [Required(ErrorMessage = "Are you drunk? You have to enter your username dude..")]
        public string UserName { get; set; }
        
        [Required(ErrorMessage = "Come on! Think again... You can find it!")]
        public string Password { get; set; }
    }
}
