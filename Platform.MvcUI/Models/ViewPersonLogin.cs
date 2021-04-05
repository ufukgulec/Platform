using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Platform.MvcUI.Models
{
    public class ViewPersonLogin
    {
        [DisplayName("Kullanıcı Adı")]
        [Required(ErrorMessage ="Kullanıcı Adı Boş Geçilemez."),MaxLength(50,ErrorMessage ="Kullanıcı Adı En Fazla 50 Karakter Olmalıdır.")]
        public string Username { get; set; }
        [DisplayName("Parola")]
        [Required(ErrorMessage ="Parola Boş Geçilemez."),DataType(DataType.Password)]
        public string Password { get; set; }
    }
}