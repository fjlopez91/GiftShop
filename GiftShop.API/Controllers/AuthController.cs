using GiftShop.Application.Constants;
using GiftShop.Application.Dtos;
using GiftShop.Application.Utils;
using GiftShop.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GiftShop.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly IJwtUtils _jwtUtils;

        public AuthController(UserManager<User> userManager, IJwtUtils jwtUtils)
        {
            _userManager = userManager;
            _jwtUtils = jwtUtils;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] UserForAuthenticationDto model)
        {
            var user = _userManager.Users.Include(u => u.UserRoles).ThenInclude(ur => ur.Role).Where(x => x.Email == model.Email).FirstOrDefault();
            if (user == null || !await _userManager.CheckPasswordAsync(user, model.Password))
                return Unauthorized();

            var token = _jwtUtils.GetJwtToken(user);

            return Ok(new AuthResponseDto { IsAuthSuccessful = true, Token = token });
        }

        [HttpPost("Registration")]
        public async Task<IActionResult> RegisterUser([FromBody] UserForRegistrationDto userForRegistration)
        {
            if (userForRegistration == null || !ModelState.IsValid)
                return BadRequest();

            var userExists = await _userManager.FindByEmailAsync(userForRegistration.Email);
            if (userExists != null) return BadRequest("User already exists");

            if (userForRegistration.Password != userForRegistration.ConfirmPassword)
                return BadRequest("Password and Confirm Password don´t match");

            var emailSplitted = userForRegistration.Email.Split('@');

            User user = new()
            {
                Email = userForRegistration.Email,
                FirstName = userForRegistration.FirstName,
                LastName = userForRegistration.LastName,
                UserName = emailSplitted[1],
                DateCreated = DateTime.UtcNow,
                Status = Domain.Enums.EnabledStatus.Enabled,
                EmailConfirmed = true,
            };

            var result = await _userManager.CreateAsync(user, userForRegistration.Password);
            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description);

                return BadRequest(new RegistrationResponseDto { IsSuccessfulRegistration = false, Errors = errors });
            }

            await _userManager.AddToRoleAsync(user, UserRoles.User);

            return Ok(new RegistrationResponseDto { IsSuccessfulRegistration = true });
        }
    }
}