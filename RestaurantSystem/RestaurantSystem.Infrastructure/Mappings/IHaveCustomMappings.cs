using AutoMapper;
namespace RestaurantSystem.Infrastructure.Mappings
{
    public interface IHaveCustomMappings
    {
        void CreateMappings(IConfiguration configuration);
    }
}
