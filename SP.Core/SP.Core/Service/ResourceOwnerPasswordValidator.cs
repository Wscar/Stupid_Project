using IdentityServer4.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sp.Service;
using Sp.Service.Dtos;
using SP.Models;
using IdentityServer4.Models;

namespace SP.Core.Service
{
    public class ResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        private readonly IUserService userService;
        public ResourceOwnerPasswordValidator(IUserService _userService)
        {
            userService = _userService;
        }

        public async  Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
          var result=  userService.SignIn(context.UserName, context.Password);
            if (result.Status == Status.Success)
            {
                var user = result.Data as AppUser;
                context.Result = new GrantValidationResult( user.UserName, "admin");
               
            }
            else
            {
                context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, result.Msg);
            }            
        }
    }
}
