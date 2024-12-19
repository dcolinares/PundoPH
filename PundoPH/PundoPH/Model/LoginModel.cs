using Microsoft.AspNetCore.Components;
using System.ComponentModel.DataAnnotations;

namespace PundoPH.Model
{
    [Serializable]
    public class LoginModel
    {
        public int UserID { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        public string Email { get; set; }
        public EventCallback<bool> IsLoginSucessful { get; set; }

    }
}
