using AutoMapper;

namespace Animal_Status.Mapping
{
    public class BaseMapper<TSource, TDestination> : Profile
    {
        public BaseMapper()
        {
            CreateMap<TSource, TDestination>();
            CreateMap<TDestination, TSource>();
        }
    }
}
