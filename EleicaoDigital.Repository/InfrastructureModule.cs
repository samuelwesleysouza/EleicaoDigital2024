using EleicaoDigital.Repository.Repository.Pessoa;
using EleicaoDigital.Repository.Repository.PostUsuario;
using EleicaoDigital.Repository.Repository.Usuario;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace EleicaoDigital.Repository
{
    public static class InfrastructureModule
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddMySQL(configuration)
                .AddRepositories();

            return services;
        }

        public static IServiceCollection AddMySQL(this IServiceCollection services, IConfiguration configuration)
        {

            //var connection = configuration.GetConnectionString("MySqlConnectionString");
            var host = configuration["DBHOST"] ?? "localhost";
            var port = configuration["DBPORT"] ?? "3306";
            var password = configuration["MYSQL_ROOT_PASSWORD"] ?? configuration.GetConnectionString("MYSQL_ROOT_PASSWORD");
            var userid = "root";//configuration["MYSQL_USER"] ?? configuration.GetConnectionString("MYSQL_USER");
            var productsdb = configuration["MYSQL_DATABASE"] ?? configuration.GetConnectionString("MYSQL_DATABASE");

            string mySqlConnStr = $"server={host}; userid={userid};pwd={password};port={port};database={productsdb}";


            return services.AddDbContext<Context>(options =>
                            options.UseMySql(
                                mySqlConnStr,
                                ServerVersion.AutoDetect(mySqlConnStr)
                                ));
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IPessoaRepository, PessoaRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IPostsUsuarioRepository, PostsUsuarioRepository>();

            return services;
        }
    }
}
