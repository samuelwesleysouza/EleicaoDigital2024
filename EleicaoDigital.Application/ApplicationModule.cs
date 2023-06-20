using EleicaoDigital.Application.Services.Publicacao;
using EleicaoDigital.Application.Services.Usuario;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace EleicaoDigital.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services
                .AddApplicationServices()
                .AddAuthentication();

            return services;
        }

        private static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IPublicacaoService, PublicacaoService>();

            return services;
        }

        private static IServiceCollection AddAuthentication(this IServiceCollection services)
        {
            services.AddAuthentication
                 (JwtBearerDefaults.AuthenticationScheme)
                 .AddJwtBearer(options =>
                 {
                     options.TokenValidationParameters = new TokenValidationParameters
                     {
                         ValidateIssuer = true,
                         ValidateAudience = true,
                         ValidateLifetime = true,
                         ValidateIssuerSigningKey = true,
                         ValidIssuer = "var",//ValidIssuer = Configuration["Jwt:Issuer"], Estamos utilizando o var esse aqui es o din�mico
                         ValidAudience = "var",//ValidAudience = Configuration["Jwt:Audience"],
                         IssuerSigningKey = new SymmetricSecurityKey
                       (Encoding.UTF8.GetBytes("b23ced2d-db9e-43e8-b297-0656d6393282"))  //Configuration["Jwt:Key"] Esse key din�mico mas irei passar o meu fixo que criei
                     };
                 });

            return services;
        }
    }
}
