using IsubuSatis.KatalogApi.Dtos;
using IsubuSatis.KatalogApi.Models;
using IsubuSatis.KatalogApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IsubuSatis.KatalogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KategoriController : ControllerBase
    {
        private readonly IKategoriService _kategoriService;

        public KategoriController(IKategoriService kategoriService)
        {
            _kategoriService = kategoriService;
        }

        [HttpGet]
        public async Task<List<KategoriDto>> GetKategoriler()
        {
            return await _kategoriService.GetKategoriler();
        }

        [HttpPost]
        public async Task<IActionResult> KategoriEkle(CreateOrUpdateKategoriDto input)
        {
            await _kategoriService.CreateOrUpdate(input);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> KategoriGuncelle(CreateOrUpdateKategoriDto input)
        {
            await _kategoriService.CreateOrUpdate(input);

            return Ok();
        }

        [HttpDelete]
        public async Task KategoriSil(string id)
        {
            await _kategoriService.Sil(id);
        }
    }
}
