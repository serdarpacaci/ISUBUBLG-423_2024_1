using IsubuSatis.KatalogApi.Models;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace IsubuSatis.KatalogApi.Dtos
{
    public class UrunDto
    {
        public string Id { get; set; }

        public string Ad { get; set; }

        public decimal Fiyat { get; set; }
        public string KategoriId { get; set; }
        public string KategoriAdi { get; set; }
    }
}
