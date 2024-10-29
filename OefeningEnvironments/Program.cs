namespace OefeningEnvironments
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.MapGet("/environment", (IHostEnvironment env, IConfiguration config) =>
            {
                var environmentMessage = config["AppSettings:EnvironmentMessage"];
                if (env.IsDevelopment())
                {
                    return Results.Ok(environmentMessage);
                }
                else if (env.IsProduction())
                {
                    return Results.Ok(environmentMessage);
                }
                else
                {
                    return Results.Ok("Onbekende omgeving");
                }
            });

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
