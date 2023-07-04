using AutoMapper;

public static class AutoMapperExtensions
{
    public static T Map<T>(this IMapper mapper, object source, object destination)
    {
        return (T)mapper.Map(
            source, 
            destination, 
            source.GetType(), 
            typeof(T));
    }
}