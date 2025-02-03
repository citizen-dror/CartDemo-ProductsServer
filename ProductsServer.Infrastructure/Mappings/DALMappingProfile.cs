using AutoMapper;
using ProductsServer.Domain;
using ProductsServer.Infrastructure.Entities;

namespace ProductsServer.Infrastructure.Mappings
{
    public class DALMappingProfile: Profile
    {

        public DALMappingProfile() 
        {
            // Map EF Entity to Domain object
            CreateMap<ProductEntity, Product>()
            .ForMember(dest => dest.Category, opt => opt.MapFrom(src => new ProductCategory
            {
                Id = src.ProductCategory.Id,
                Name = src.ProductCategory.Name
            }))
            .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.CategoryId))
            .ReverseMap();

            CreateMap<ProductCategoryEntity, ProductCategory>()
                .ReverseMap();
        }
     
    }
}
