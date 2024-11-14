using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace IsubuSatis.Sepet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocalCacheController : ControllerBase
    {
        private readonly IMemoryCache _memoryCache;

        public LocalCacheController(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        [HttpGet]
        public async Task<IActionResult> GetCacheTest()
        {
            var sonuc = await _memoryCache.GetOrCreateAsync("dersler", async  x =>
            {
                // x.AbsoluteExpiration = DateTime.Now.AddSeconds(10);
                x.SlidingExpiration = TimeSpan.FromSeconds(10);
                var dersler = await GetDersler();

                return dersler;
            });

            return Ok(sonuc);
        }

        private async Task<List<Ders>> GetDersler()
        {
            await Task.Delay(5000);

            return new List<Ders>
            {
                new Ders{ Id = 1, DersAdi = "C#"},
                new Ders{ Id = 2, DersAdi = "Sql"},
                new Ders{ Id = 3, DersAdi = "Web"},
                new Ders{ Id = 4, DersAdi = "Algoritma"},
            };
        }
    }

    public class  Ders
    {
        public int Id { get; set; }
        public string DersAdi { get; set; }
    }
}
