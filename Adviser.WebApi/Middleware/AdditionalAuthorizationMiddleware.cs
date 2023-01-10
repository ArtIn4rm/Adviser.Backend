using Adviser.WebApi.Controllers;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using MediatR;
using Adviser.WebApi;
using Adviser.WebApi.Models;
using Adviser.Application.CQRS.Users.Queries.CheckUserAuth;

namespace Adviser.WebApi.Middleware
{
    public class AdditionalAuthorizationMiddleware
    {
        private readonly RequestDelegate _next;

        public AdditionalAuthorizationMiddleware(RequestDelegate next) =>
            _next = next;

        public async Task InvokeAsync(HttpContext context)
        {
            var bearer = context.Request.Headers["Authorization"].ToString();
            if (bearer != string.Empty)
            {
                var jwt = bearer.Split(' ')[1];
                if (jwt != string.Empty && jwt != null)
                {
                    var jwtDecoded = new JwtSecurityTokenHandler().ReadJwtToken(jwt);
                    Guid id = await VerifyJwt(context, jwtDecoded);
                    if (context.Request.Path == "/api/login/auth")
                    {
                        HandleAuthorizationRequest(context, jwtDecoded, id);
                    }
                }
            }
            if (context.Request.Path != "/api/login/auth")
                await _next(context);
        }

        public async void HandleAuthorizationRequest(HttpContext context,
            JwtSecurityToken tokenDecoded, Guid id)
        {
            string email = tokenDecoded.Claims.First(claim =>
                            claim.Type == ClaimTypes.Email).Value;
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = 200;
            await context.Response.WriteAsync(LoginController.GenerateJwt(
                LoginController.CreateClaimList(email, id), Startup.Configuration!));
        }

        public async Task<Guid> VerifyJwt(HttpContext context, JwtSecurityToken jwtDecoded)
        {
            Guid id = Guid.Parse(jwtDecoded.Claims.First(claim =>
               claim.Type == ClaimTypes.NameIdentifier).Value);
            var command = new CheckUserAuthQuery
            {
                Id = id
            };
            await context.RequestServices.GetService<IMediator>()!.Send(command);
            return id;
        }

    }
}
