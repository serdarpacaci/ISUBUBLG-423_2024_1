﻿using IsubuIdentitiyServer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace IsubuIdentitiyServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class UserController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> KullaniciKayit(KullaniciKayitDto input)
        {
            var eklenecekUser = new ApplicationUser
            {
                Email = input.Eposta,
                UserName = input.KullaniciAdi,
            };

            var result = await _userManager.CreateAsync(eklenecekUser, input.Sifre);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors.Select(x => x.Description));
            }

            return Ok();
        }
    }
}
