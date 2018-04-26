using System.Collections.Generic;
using CoreServiceCollection.Domain.Models;

namespace CoreServiceCollection.Core.Services
{
    public interface IPersonService
    {
        IList<PersonModel> Persons { get; set; }
    }
}