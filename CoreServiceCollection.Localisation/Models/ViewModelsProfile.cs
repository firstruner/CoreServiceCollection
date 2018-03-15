using AutoMapper;
using CoreServiceCollection.Core.Models;

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