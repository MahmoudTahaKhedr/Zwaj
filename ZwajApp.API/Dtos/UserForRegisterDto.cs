using System.ComponentModel.DataAnnotations;

namespace ZwajApp.API.Dtos
{
    public class UserForRegisterDto
    {
        [Required]
        public string Username { get; set; }
        [Required,StringLength(8,MinimumLength =4,ErrorMessage ="كلمة السر لا تقل عن 4 أحرف أو تزيد عن 8 أحرف")]  
        public string Password { get; set; }                   
    }
}