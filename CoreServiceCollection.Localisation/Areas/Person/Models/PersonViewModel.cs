using System;
using System.ComponentModel.DataAnnotations;

namespace CoreServiceCollection.Localisation.Areas.Person.Models
{
    public class PersonViewModel
    {
        public Guid? Id { get; set; }

        [Required(ErrorMessage = "FirstName_RequiredMessage")]
        [Display(Name = "FirstName_Display")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "LastName_RequiredMessage")]
        [Display(Name = "LastName_Display")]
        public string LastName { get; set; }

        [EmailAddress(ErrorMessage = "Email_InvalidMessage")]
        [Display(Name = "Email_Display")]
        public string Email { get; set; }

        [Display(Name = "AdditionalInfo_Display")]
        public string AdditionalInfo { get; set; }
    }
}