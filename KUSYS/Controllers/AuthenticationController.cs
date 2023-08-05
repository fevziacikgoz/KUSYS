using KUSYS.Api.Controllers;
using KUSYS.Application.Common.Dtos;
using KUSYS.Application.Common.Messages;
using KUSYS.Application.Models;
using KUSYS.Application.StudentsOp;
using KUSYS.Application.StudentsOp.Command.CreateStudent;
using KUSYS.Application.StudentsOp.Query.GetStudentByIdentityUserIdQueries;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Mime;
using System.Security.Claims;
using System.Text;

namespace KUSYS.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [AllowAnonymous]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly IMediator _mediator;
        public AuthenticationController(UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IConfiguration configuration,
            IMediator mediator)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _mediator = mediator;
        }
        [HttpPost("Login")]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> Login(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user != null && await _userManager.CheckPasswordAsync(user, password))
            {
                var autClaims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name,user.UserName),
                    new Claim(ClaimTypes.PrimarySid,user.Id),
                    new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
                };
                var student = await _mediator.Send(new GetStudentByIdentityUserIdQuery(user.Id));
                if (student != null)
                {
                    autClaims.Add(new Claim(ClaimTypes.Sid, student.Id.ToString()));
                }
                var userRoles = await _userManager.GetRolesAsync(user);
                foreach (var role in userRoles)
                {
                    autClaims.Add(new Claim(ClaimTypes.Role, role));
                }
                var jwtToken = GetToken(autClaims);

                var identity = new ClaimsIdentity(autClaims, JwtBearerDefaults.AuthenticationScheme);
                var claimsPrincipal = new ClaimsPrincipal(identity);
                // Set current principal
                Thread.CurrentPrincipal = claimsPrincipal;
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(jwtToken),
                    expiration = jwtToken.ValidTo
                });
            }
            return Unauthorized();
        }

        private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(12),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );
            return token;

        }

        [HttpPost("Register")]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> Register(RegisterModel registerModel)
        {
            var userExist = await _userManager.FindByNameAsync(registerModel.Email);
            if (userExist != null)
            {
                return StatusCode(StatusCodes.Status403Forbidden, new DataResponseDto<bool> { Data = false, Successful = false, Message = MessagesConstant.UserAlreadyExist });
            }
            IdentityUser user = new IdentityUser()
            {
                Email = registerModel.Email,
                PhoneNumber = registerModel.PhoneNumber,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = registerModel.Email
            };
            var result = await _userManager.CreateAsync(user, registerModel.Password);
            if (!result.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new DataResponseDto<bool> { Data = false, Successful = false, Message = MessagesConstant.UserCreateFailed });
            }
            await _userManager.AddToRoleAsync(user, "User");

            var test = new StudentController(_mediator).Create(new CreateStudentCommand()
            {
                createUpdateStudentModel = new CreateUpdateStudentModel()
                {
                    Name = registerModel.Name,
                    Surname = registerModel.Surname,
                    Mail = registerModel.Email,
                    BirthDate = registerModel.BirthDate,
                    IsActive = true,
                    PhoneNumber = registerModel.PhoneNumber,
                    IdentityUserId = user.Id
                }
            });

            //await _mediator.Send(new CreateStudentCommand()
            //{
            //    createUpdateStudentModel = new CreateUpdateStudentModel()
            //    {
            //        Name = registerModel.Name,
            //        Surname = registerModel.Surname,
            //        Mail = registerModel.Email,
            //        BirthDate = registerModel.BirthDate,
            //        IsActive = true,
            //        PhoneNumber = registerModel.PhoneNumber,
            //        IdentityUserId = user.Id
            //    }
            //});

            return StatusCode(StatusCodes.Status201Created, new DataResponseDto<bool> { Data = true, Successful = true, Message = MessagesConstant.UserCreated });

        }
    }
}