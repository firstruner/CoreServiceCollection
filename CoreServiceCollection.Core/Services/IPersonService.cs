using System.Collections.Generic;
using CoreServiceCollection.Core.Models;

namespace CoreServiceCollection.Core.Services
{
    public interface IPersonService
    {
        IList<PersonModel> Persons { get; set; }
    }
}