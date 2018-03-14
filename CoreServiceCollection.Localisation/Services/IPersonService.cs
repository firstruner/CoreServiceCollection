using System.Collections.Generic;
using CoreServiceCollection.Localisation.Models;

namespace CoreServiceCollection.Localisation.Services
{
    public interface IPersonService
    {
        IList<PersonViewModel> Persons { get; set; }
    }
}