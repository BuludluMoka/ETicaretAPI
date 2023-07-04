using AutoMapper;

namespace OnionArchitecture.Application.Utilities.Mapper
{
    public interface IMapTo<T>
    {
        void Mapping(Profile profile) => profile.CreateMap(GetType(), typeof(T)).ReverseMap();
    }
}
