using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tekno_Yazılım.Models
{
    public class UserUpdateViewModel
    {
        public string namesurname { get; set; }
        public string username { get; set; }
        public IFormFile imageurl { get; set; }
        public string mail { get; set; }
        public string password { get; set; }
        public string PhoneNumber { get; set; }
        public string Youtube { get; set; }
        public string Github { get; set; }
        public string Linkedin { get; set; }
        public string Instagram { get; set; }
        public string Facebook { get; set; }
        public string Tweteer { get; set; }
        public string Pinterest { get; set; }
        public string Discord { get; set; }
        public string Microsoft { get; set; }
        public string WeChat { get; set; }
        public string Twitch { get; set; }
        public string userabout { get; set; }
        public bool userstatus { get; set; }
    }
}
