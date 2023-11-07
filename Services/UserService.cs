using Microsoft.AspNetCore.Http;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public UserService(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public string GetMyName()
        {
            var result = string.Empty;
            if (_contextAccessor.HttpContext is not null)
                result = _contextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name);
            return result;
        }
    }
}
