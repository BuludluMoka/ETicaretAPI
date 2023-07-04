using AutoMapper;

namespace OnionArchitecture.Application.Utilities.Mapper
{
    public interface IMapFrom<T>
    {
        void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
    }
}
