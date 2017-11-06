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

        public string LastName { get; set; }

        public int DOB { get; set; }

        public string NewAddress { get; set; }

        public string City { get; set; }

        public string NewState { get; set; }

        public int Zip { get; set; }

        public int TodayDate
        {
            get
            {
                var today = DateTime.Today;
                return TodayDate;
            }
        }

  
        public override string ToString()
        {
            return $"{base.ToString()}: {FirstName} {LastName} DOB = {DOB} {NewAddress} {City} {NewState} Zip = {Zip} TodayDate ={TodayDate}";
        }
    }
}