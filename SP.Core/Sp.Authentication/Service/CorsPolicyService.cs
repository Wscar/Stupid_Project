using IdentityServer4.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sp.Authentication.Service
{
    public class CorsPolicyService : ICorsPolicyService
    {
        public Task<bool> IsOriginAllowedAsync(string origin)
        {

            var task = Task.Run<bool>(() =>
            {
                if (origin == "http://localhost:8081")
                {
                    return true;
                }
                return false;
            });
            return task;
        }
    }
}
