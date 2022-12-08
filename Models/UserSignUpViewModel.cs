using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tekno_Yazılım.Models
{
    public class UserSignUpViewModel
    {
        [Display(Name = "Ad Soyad")]
        [Required(ErrorMessage = "Lütfen ad ve soyadınızı giriniz")]
        public string NameSurname { get; set; }

        public IFormFile UserImage { get; set; }

        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "Lütfen şifrenizi giriniz")]
        public string Password { get; set; }

        [Display(Name = "Şifre Tekrarı")]
        [Compare("Password", ErrorMessage = "Şifreler uyuşmuyor!")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "E-Posta Adresi")]
        [Required(ErrorMessage = "Lütfen E-Posta Adresinizi giriniz")]
        public string Email { get; set; }

        [Display(Name = "Kullanıcı Adı")]
        [Required(ErrorMessage = "Lütfen bir kullanıcı adınızı giriniz")]
        public string UserName { get; set; }

        public bool IsAcceptTheContract { get; set; }
    }
}
