
using IsubuSatis.KatalogApi.Models;
using IsubuSatis.KatalogApi.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace IsubuSatis.KatalogApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddScoped<IKategoriService, KategoriService>();
            builder.Services.AddScoped<IUrunService, UrunService>();

            var mongoDbConfiguration = builder.Configuration.GetSection("MongoDbSettings");
            builder.Services.Configure<MongoDbSettings>(mongoDbConfiguration);

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddAutoMapper(typeof(Program));

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(x =>
                {
                    x.Authority = "https://localhost:5001";
                    x.Audience = "resource_katalog";
                });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
