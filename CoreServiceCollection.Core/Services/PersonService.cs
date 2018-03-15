using System;
using System.Collections.Generic;
using CoreServiceCollection.Core.Models;

namespace CoreServiceCollection.Core.Services
{
    public class PersonService : IPersonService
    {
        public PersonService()
        {
            Persons = new List<PersonModel>()
            {
                new PersonModel()
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Bruno",
                    LastName = "Barrette",
                    Email = "bruno@bracketshow.com",
                    AdditionalInfo = "test"
                },
                new PersonModel()
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Éric",
                    LastName = "De Carufel",
                    Email = "eric@bracketshow.com"
                }
            };
        }

        public IList<PersonModel> Persons { get; set; }
    }
}