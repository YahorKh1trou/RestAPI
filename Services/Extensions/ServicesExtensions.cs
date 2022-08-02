using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Services.Services;
using Services.Services.Contracts;

namespace Services.Extensions
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
            => services.AddScoped<IBooksService, BooksService>();

        public static void AddAuth(this IServiceCollection services)
            => services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                   .AddJwtBearer(options =>
                   {
                      options.RequireHttpsMetadata = false;
                      options.TokenValidationParameters = new TokenValidationParameters
                         {
                             ValidateIssuer = true,
                             ValidIssuer = AuthService.ISSUER,
                             ValidateAudience = true,
                             ValidAudience = AuthService.AUDIENCE,
                             ValidateLifetime = true,
                             IssuerSigningKey = AuthService.GetSymmetricSecurityKey(),
                             ValidateIssuerSigningKey = true,
                         };
                   });

    }
}
