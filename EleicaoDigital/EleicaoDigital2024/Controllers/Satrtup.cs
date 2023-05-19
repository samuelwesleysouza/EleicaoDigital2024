using EleicaoDigitalAplication.Services;
using EleicaoRepository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;

namespace EleicaoDigital2024.Controllers
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ControleCadastroService>();
            services.AddControllers();
            services.AddCors();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new OpenApiInfo { Title = "EleicaoDigital2024", Version = "v1" });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

            });

            //continuação do token codigo copiado passo a passo 
            //Oque esse codigo faz vai validar os user verdadeiro por completo 
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
                         ValidIssuer = "var",//ValidIssuer = Configuration["Jwt:Issuer"], Estamos utilizando o var esse aqui es o dinâmico
                         ValidAudience = "var",//ValidAudience = Configuration["Jwt:Audience"],
                         IssuerSigningKey = new SymmetricSecurityKey
                       (Encoding.UTF8.GetBytes("b23ced2d-db9e-43e8-b297-0656d6393282"))  //Configuration["Jwt:Key"] Esse key dinâmico mas irei passar o meu fixo que criei
                     };
                 });
            services.AddAuthorization(); //APOS TIVEMOS QUE COLOCAR ESSE RETORNO 

            //REFERENCIAR O BANCO DE DADOS AQUI APÒS REFERENCIAR O REPOSITORY NAS DEPENDENCIA 
            services.AddDbContext<EleicaoContext>(option => option.UseSqlServer("server=DESKTOP-SESKBTO\\SQLEXPRESS;database=EleicaoDigital2024;trusted_Connection=True;TrustServerCertificate=True;"));

        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseCors(options => options.WithOrigins("*").AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //Ativa o Swagger
            app.UseSwagger();

            // Ativa o Swagger UI
            app.UseSwaggerUI(opt =>
            {
                opt.SwaggerEndpoint("/swagger/v1/swagger.json", "TodoAPI V1");
                opt.RoutePrefix = string.Empty;
            });
        }
    }
}
