using AutoMapper;

namespace ETicaretAPI.Application.Utilities.Mapper
{
    public interface IMapTo<T>
    {
        void Mapping(Profile profile) => profile.CreateMap(GetType(), typeof(T)).ReverseMap();
    }
}
