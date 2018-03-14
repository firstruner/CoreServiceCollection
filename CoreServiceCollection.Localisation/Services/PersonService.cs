using System;
using System.Collections.Generic;
using CoreServiceCollection.Localisation.Models;

namespace CoreServiceCollection.Localisation.Services
{
    public class PersonService : IPersonService
    {
        public PersonService()
        {
            Persons = new List<PersonViewModel>()
            {
                new PersonViewModel()
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Bruno",
                    LastName = "Barrette",
                    Email = "bruno@bracketshow.com"
                },
                new PersonViewModel()
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Éric",
                    LastName = "De Carufel",
                    Email = "eric@bracketshow.com"
                }
            };
        }

        public IList<PersonViewModel> Persons { get; set; }
    }
}