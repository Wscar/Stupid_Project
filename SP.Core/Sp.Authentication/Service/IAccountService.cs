using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Validation;
using Sp.Authentication.Dtos;
namespace Sp.Authentication.Service
{
   public interface IAccountService
    {
        Task<GrantValidationResult> SignIn(string userName, string password);
    }
}
