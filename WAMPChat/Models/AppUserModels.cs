using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WAMPChat.Models
{
    public enum Cities
    {
        [Display(Name = "Лондон")]
        LONDON,

        [Display(Name = "Париж")]
        PARIS,

        [Display(Name = "Москва")]
        MOSCOW
    }

    public enum Countries
    {
        [Display(Name = "Не указано")]
        NONE,

        [Display(Name = "Англия")]
        ENG,

        [Display(Name = "Франция")]
        FRA,

        [Display(Name = "Россия")]
        RUS
    }

    public class AppUser : IdentityUser
    {
        public Cities City { get; set; }
        public Countries Country { get; set; }

        public void SetCountryFromCity(Cities city)
        {
            switch (city)
            {
                case Cities.LONDON:
                    Country = Countries.ENG;
                    break;
                case Cities.PARIS:
                    Country = Countries.FRA;
                    break;
                case Cities.MOSCOW:
                    Country = Countries.RUS;
                    break;
                default:
                    Country = Countries.NONE;
                    break;
            }
        }
    }
}