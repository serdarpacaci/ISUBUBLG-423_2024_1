
using IsubuSatis.Siparis.Application.Consumers;
using IsubuSatis.Siparis.Persistence;
using MassTransit;
using Microsoft.EntityFrameworkCore;

namespace IsubuSatis.Siparis.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            var constr = builder.Configuration.GetConnectionString("Default");
            builder.Services.AddDbContext<SiparisDbContext>(x => x.UseSqlServer(constr, y =>
            {
                y.MigrationsAssembly("IsubuSatis.Siparis.Persistence");
            }));
            // Add services to the container.

            builder.Services.AddMassTransit(x =>
            {
                x.AddConsumer<SiparisOlusturMessageCommandConsumer>();

                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host(builder.Configuration["RabbitMQUrl"], "/", host =>
                    {
                        host.Username("guest");
                        host.Password("guest");
                    });

                    cfg.ReceiveEndpoint("siparis-olustur-service", e =>
                    {
                        e.ConfigureConsumer<SiparisOlusturMessageCommandConsumer>(context);
                    });

                });
            });


            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            builder.Services.AddMediatR(x =>
              x.RegisterServicesFromAssembly(typeof(Siparis.Application.Commands.CreateSiparisCommand).Assembly)
             );


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
