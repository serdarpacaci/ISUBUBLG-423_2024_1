using IsubuSatis.Sepet.Models;
using IsubuSatis.Sepet.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IsubuSatis.Sepet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SepetController : ControllerBase
    {
        private readonly ISepetService _sepetService;
        private readonly IIdentityHelperService _identityHelperService;
        public SepetController(ISepetService sepetService, 
            IIdentityHelperService identityHelperService = null)
        {
            _sepetService = sepetService;
            _identityHelperService = identityHelperService;
        }

        [HttpGet]
        public async Task<IActionResult> GetSepet()
        {
            var userId = _identityHelperService.GetUserId();
            if (string.IsNullOrEmpty(userId))
                return BadRequest();

            var sepet = await _sepetService.GetSepet(userId);

            return Ok(sepet);
        }

        [HttpPost]
        public async Task<IActionResult> SetSepet(SepetDto sepetDto)
        {
            var userId = _identityHelperService.GetUserId();
            sepetDto.UserId = userId;
            
            await _sepetService.SepetiKaydet(sepetDto);
           
           return Ok();
        }

        [HttpDelete]
        public async Task Sil()
        {
            var userId = _identityHelperService.GetUserId();

            await  _sepetService.SepetiBosalt(userId);
        }
    }
}
