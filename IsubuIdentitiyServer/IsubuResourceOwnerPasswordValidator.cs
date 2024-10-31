using IdentityModel;
using IdentityServer4.Validation;
using IsubuIdentitiyServer.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace IsubuIdentitiyServer
{
    public class IsubuResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public IsubuResourceOwnerPasswordValidator(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            var user = await _userManager.FindByEmailAsync(context.UserName);

            if (user is null)
            {
                AddErrorResult(context);

                return;
            }

            var isPassWordValid = await _userManager.CheckPasswordAsync(user, context.Password);
            if (!isPassWordValid)
            {
                AddErrorResult(context);

                return;
            }

            context.Result = new GrantValidationResult(user.Id.ToString(), 
                OidcConstants.AuthenticationMethods.Password);
        }

        private void AddErrorResult(ResourceOwnerPasswordValidationContext context)
        {
            context.Result.CustomResponse = new System.Collections.Generic.Dictionary<string, object>
                {
                    {"error", "E-posta veya şifre bilgisi hatalı" }
                };
        }
    }
}
