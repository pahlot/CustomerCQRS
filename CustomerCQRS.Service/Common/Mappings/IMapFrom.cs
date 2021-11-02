using AutoMapper;

namespace CustomerCQRS.Infrastructure.Common
{
    public interface IMapFrom<T>
    {
        void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
    }
}
