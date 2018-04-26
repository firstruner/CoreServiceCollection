using AutoMapper;
using CoreServiceCollection.Domain.Models;
using CoreServiceCollection.Localisation.Areas.Person.Models;

namespace CoreServiceCollection.Localisation.Models
{
    public class ViewModelsProfile : BiDirectionalProfile
    {
        public ViewModelsProfile()
        {
            CreateBiDirectionalMap<PersonModel, PersonViewModel>();
        }
    }

    public class BiDirectionalProfile : Profile
    {
        protected void CreateBiDirectionalMap<TSource, TDestination>()
        {
            CreateMap<TSource, TDestination>();
            CreateMap<TDestination, TSource>();
        }
    }
}