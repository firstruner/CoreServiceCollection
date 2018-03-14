using System;
using System.ComponentModel.DataAnnotations;

namespace CoreServiceCollection.Localisation.Models
{
    public class PersonViewModel
    {
        public Guid? Id { get; set; }

        [Required(ErrorMessage = "Le prénom est requis")]
        [Display(Name = "Prénom")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Le nom est requis")]
        [Display(Name = "Nom")]
        public string LastName { get; set; }

        [EmailAddress(ErrorMessage = "Le courriel n'est pas valide")]
        [Display(Name = "Courriel")]
        public string Email { get; set; }

        [Display(Name = "Information additionnelle")]
        public string AdditionalInfo { get; set; }
    }
}