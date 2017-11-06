using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HW5.Models
{
    public class Form
    {
        public int ID { get; set; }

        [Required, StringLength(64)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required, StringLength(64)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "DOB")]
        public DateTime DOB { get; set; }

        [Required, StringLength(128)]
        [Display(Name = "Address")]
        public string NewAddress { get; set; }

        [Required, StringLength(128)]
        [Display(Name = "City")]
        public string City { get; set; }

        [Required, StringLength(64)]
        [Display(Name = "State")]
        public string NewState { get; set; }

        [Display(Name = "Zip")]
        public int Zip { get; set; }

        [Display(Name = "County")]
        public string County { get; set; }


        public override string ToString()
        {
            return $"{base.ToString()}: {FirstName} {LastName} DOB = {DOB} {NewAddress} {City} {NewState} Zip = {Zip}";
        }
    }
}