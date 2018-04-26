using AutoMapper;
using CoreServiceCollection.Domain.Models;

namespace CoreServiceCollection.Injection.Models
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