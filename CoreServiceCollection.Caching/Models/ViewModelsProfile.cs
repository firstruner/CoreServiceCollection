using AutoMapper;
using CoreServiceCollection.Core.Models;

namespace CoreServiceCollection.Caching.Models
{
    public class ViewModelsProfile : Profile
    {
        public ViewModelsProfile()
        {
            CreateMap<PersonModel, PersonViewModel>();
            CreateMap<PersonViewModel, PersonModel>();
        }
    }
}