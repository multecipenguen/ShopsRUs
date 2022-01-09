using AutoMapper;

namespace ShopsRUs.Application.ProfileMapping
{
    public interface IMapFrom<T>
    {
        void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
    }
}
