using AutoMapper;
using CoreServiceCollection.Domain.Models;

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