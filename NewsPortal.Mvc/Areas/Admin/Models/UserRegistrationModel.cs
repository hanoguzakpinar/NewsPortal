using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NewsPortal.Mvc.Areas.Admin.Models
{
    public class UserRegistrationModel
    {
        [DisplayName("İsim")]
        [Required(ErrorMessage = "{0} alanı doldurulmalıdır.")]
        public string FirstName { get; set; }
        [DisplayName("Soyisim")]
        [Required(ErrorMessage = "{0} alanı doldurulmalıdır.")]
        public string LastName { get; set; }
        [DisplayName("Email")]
        [Required(ErrorMessage = "{0} alanı doldurulmalıdır.")]
        [EmailAddress]
        public string Email { get; set; }
        [DisplayName("Şifre")]
        [Required(ErrorMessage = "{0} alanı doldurulmalıdır.")]
        [DataType(DataType.Password)]
        [MaxLength(30, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        [MinLength(5, ErrorMessage = "{0} {1} karakterden küçük olmamalıdır.")]
        public string Password { get; set; }
        [DisplayName("Şifre Tekrar")]
        [Required(ErrorMessage = "{0} alanı doldurulmalıdır.")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Girilen şifreler birbirinden farklı olmamalıdır.")]
        [MaxLength(30, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        [MinLength(5, ErrorMessage = "{0} {1} karakterden küçük olmamalıdır.")]
        public string ConfirmPassword { get; set; }
    }
}