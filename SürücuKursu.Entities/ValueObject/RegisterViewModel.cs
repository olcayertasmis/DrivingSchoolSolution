using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SürücüKursu.Entitites.ValueObject
{
    public class RegisterViewModel
    {
        [DisplayName("Kullanıcı Adı"), Required(ErrorMessage = "{0} alanı boş geçilemez"), StringLength(25, ErrorMessage = "{0} max karakter {1} olmalı")]
        public string Username { get; set; }

        [DisplayName("Eposta"), Required(ErrorMessage = "{0} alanı boş geçilemez"), StringLength(70, ErrorMessage = "{0} max karakter {1} olmalı"),
            EmailAddress(ErrorMessage = "{0} alanı için geçerli bir adres giriniz")]
        public string Email { get; set; }

        [DisplayName("Şifre"), Required(ErrorMessage = "{0} alanı boş geçilemez."), DataType(DataType.Password), StringLength(25, ErrorMessage = "{0} max karakter {1} olmalı")]
        public string Password { get; set; }
    }
}