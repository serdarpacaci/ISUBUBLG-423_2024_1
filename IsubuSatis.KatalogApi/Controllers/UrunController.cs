using IsubuSatis.KatalogApi.Dtos;
using IsubuSatis.KatalogApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IsubuSatis.KatalogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrunController : ControllerBase
    {
        private readonly IUrunService _urunService;

        public UrunController(IUrunService urunService)
        {
            _urunService = urunService;
        }

        [HttpGet]
        public async Task<List<UrunDto>> GetUrunler()
        {
            return await _urunService.GetUrunler();
        }

        [HttpPost]
        public async Task<IActionResult> UrunEkle(CreateOrUpdateUrunDto input)
        {
            await _urunService.CreateOrUpdate(input);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UrunGuncelle(CreateOrUpdateUrunDto input)
        {
            await _urunService.CreateOrUpdate(input);

            return Ok();
        }

        [HttpDelete]
        public async Task KategoriSil(string id)
        {
            await _urunService.Sil(id);
        }
    }
}
