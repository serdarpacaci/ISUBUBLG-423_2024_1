using Ocelot.DependencyInjection;
using Ocelot.Middleware;

namespace IsubuSatis.Gateway
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Configuration.SetBasePath(builder.Environment.ContentRootPath)
              .AddJsonFile("OcelotConfiguration.json", optional: false, reloadOnChange: true);

            builder.Services.AddControllers();

            builder.Services.AddOcelot();
            builder.Services.AddSwaggerForOcelot(builder.Configuration);

            var app = builder.Build();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseSwaggerForOcelotUI(opt =>
            {
                opt.PathToSwaggerGenerator = "/swagger/docs";
            });

            app.MapControllers();
            app.UseOcelot().Wait();


            app.Run();
        }
    }
}
