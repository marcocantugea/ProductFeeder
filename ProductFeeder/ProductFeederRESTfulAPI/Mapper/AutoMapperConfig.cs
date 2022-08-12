using AutoMapper;
using ProductFeederCoreLib.Models;
using ProductFeederRESTfulAPI.DTO;

namespace ProductFeederRESTfulAPI.Mapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMapForSuppliers();
            CreateMapForBrands();
            CreateMapForProduct();
        }

        private void CreateMapForSuppliers()
        {
            CreateMap<SupplierDTO, Supplier>().ForMember(dest => dest.SupplierName, opt => opt.MapFrom(src => src.supplierName));
            CreateMap<SupplierDTO, Supplier>().ForMember(dest => dest.Prefix, opt => opt.MapFrom(src => src.prefix));
            CreateMap<SupplierDTO, Supplier>().ForMember(dest => dest.RazonSocial, opt => opt.MapFrom(src => src.razonSocial));
            CreateMap<SupplierDTO, Supplier>().ForMember(dest => dest.RFC, opt => opt.MapFrom(src => src.rfc));
            CreateMap<SupplierDTO, Supplier>().ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.email));
        }

        private void CreateMapForBrands()
        {
            CreateMap<BrandDTO, Brand>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.name));
            CreateMap<BrandDTO, Brand>().ForMember(dest => dest.Prefix, opt => opt.MapFrom(src => src.prefix));
            CreateMap<BrandDTO, Brand>().ForMember(dest => dest.SupplierId, opt => opt.MapFrom(src => src.supplierId));
        }

        private void CreateMapForProduct()
        {
            CreateMap<ProductDTO, Product>().ForMember(dest => dest.sku, opt => opt.MapFrom(src => src.sku));
            CreateMap<ProductDTO, Product>().ForMember(dest => dest.ShortDescription, opt => opt.MapFrom(src => src.shortDescription));
            CreateMap<ProductDTO, Product>().ForMember(dest => dest.LongDescription, opt => opt.MapFrom(src => src.longDescription));
            //CreateMap<ProductDTO, Product>().ForMember(dest => dest.BrandId, opt => opt.MapFrom(src => src.brandId));

        }
    }
}
