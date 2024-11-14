using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IsubuSatis.FotografDepoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FotografController : ControllerBase
    {
        private readonly string _fotografKlasorPath;
        private List<string> _izinVerilenFormatlar = new List<string>
        {
            "image/png",
            "image/jpeg",
            "image/jpg",
            "image/gif",
        };

        public FotografController()
        {
            _fotografKlasorPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwRoot", "images");
        }

        //[HttpPost]
        //public IActionResult Kaydet(IFormFile fotograf)
        //{
        //    if (fotograf.Length == 0 || !_izinVerilenFormatlar.Any(x=> x == fotograf.ContentType))
        //    {
        //        return BadRequest();
        //    }

        //    var fileExtension = Path.GetExtension(fotograf.FileName); 
        //    var fileName = Path.GetRandomFileName();
        //    fileName = fileName.Substring(0,fileName.Length - 4) + fileExtension;

        //    var fotografPath = Path.Combine(_fotografKlasorPath, fileName);
        //    using var stream = new FileStream(fotografPath, FileMode.Create);
        //    fotograf.CopyTo(stream);
        //    stream.Close();

        //    return Ok();

        //}

        [HttpPost]
        public async Task<IActionResult> Kaydet(IFormFile fotograf, CancellationToken cancellationToken)
        {
            if (fotograf.Length == 0 || !_izinVerilenFormatlar.Any(x => x == fotograf.ContentType))
            {
                return BadRequest();
            }

            var fileExtension = Path.GetExtension(fotograf.FileName);
            var fileName = Path.GetRandomFileName();
            fileName = fileName.Substring(0, fileName.Length - 4) + fileExtension;

            var fotografPath = Path.Combine(_fotografKlasorPath, fileName);
            using var stream = new FileStream(fotografPath, FileMode.Create);
            await Task.Delay(5000);
            await fotograf.CopyToAsync(stream);

            stream.Close();
            if (cancellationToken.IsCancellationRequested && System.IO.File.Exists(fotografPath))
            {
                System.IO.File.Delete(fotografPath);
            }

            return Ok(new { FileName = fileName });

        }


        [HttpDelete]
        public IActionResult Sil(string fileName)
        {
            var path = Path.Combine(_fotografKlasorPath, fileName);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }

            return Ok();
        }
    }
}
