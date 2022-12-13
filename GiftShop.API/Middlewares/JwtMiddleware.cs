using GiftShop.Application.Services;
using GiftShop.Application.Utils;

namespace GiftShop.API.Middlewares
{
    public class JwtMiddleware : IMiddleware
    {
        private readonly IUserService _userService;
        private readonly IJwtUtils _jwtUtils;

        public JwtMiddleware(IUserService userService, IJwtUtils jwtUtils)
        {
            _userService = userService;
            _jwtUtils = jwtUtils;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var userEmail = _jwtUtils.ValidateToken(token);
            if (userEmail != null)
            {
                context.Items["User"] = await _userService.GetByEmail(userEmail);
            }

            await next(context);
        }
    }
}