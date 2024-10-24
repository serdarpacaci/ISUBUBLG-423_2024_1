using AutoMapper;
using IsubuSatis.KatalogApi.Dtos;
using IsubuSatis.KatalogApi.Models;

namespace IsubuSatis.KatalogApi
{
    public class CustomDtoMapper : Profile
    {
        public CustomDtoMapper()
        {
            CreateMap<Kategori, CreateOrUpdateKategoriDto>().ReverseMap();
            CreateMap<Kategori, KategoriDto>().ReverseMap();


            CreateMap<Urun, CreateOrUpdateUrunDto>().ReverseMap();
            CreateMap<Urun, UrunDto>().ReverseMap();

        }
    }
}
