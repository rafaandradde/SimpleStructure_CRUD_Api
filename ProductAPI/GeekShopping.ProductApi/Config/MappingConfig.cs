using AutoMapper;
using GeekShopping.ProductApi.Data.ValueObjects;
using Simple.ProductApi.Entities;

namespace GeekShopping.ProductApi.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ProductVO, Product>();
                config.CreateMap<Product, ProductVO>(); 

            });
            return mappingConfig;
        }
    }
}
