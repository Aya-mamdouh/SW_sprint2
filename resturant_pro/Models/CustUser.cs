using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace resturant_pro.Models
{

    [MetadataType(typeof(UserMetaData))]
    public partial class User
    {
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }


    }
    public class UserMetaData
    {

        public int Id { get; set; }
        [Display(Name = "User Name")]
        public string UserName { get; set; }


        public string Address { get; set; }


        public string Password { get; set; }


    }
}