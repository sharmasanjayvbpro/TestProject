using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestProject.Areas.Profile.Models
{
    public class ProfileEntity
    {

        [Required(ErrorMessageResourceType = typeof(TestProject.Resources.TestLanguae), ErrorMessageResourceName = "PleaseEnterFirstNameMessage")]
        [Display(Name = "First Name")]
        public string firstName { get; set; }


        [Required(ErrorMessageResourceType = typeof(TestProject.Resources.TestLanguae), ErrorMessageResourceName = "PleaseEnterLastNameMessage")]
        [Display(Name = "Last Name")]
        public string lastName { get; set; }


    }
}