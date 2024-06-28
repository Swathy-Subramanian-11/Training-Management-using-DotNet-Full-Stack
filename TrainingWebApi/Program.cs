using EFTrainingLibrary.Models;
using EFTrainingLibrary.Repos;
using Microsoft.OpenApi.Models;

using EFTrainingLibrary.Repos;

namespace TrainingWebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<IEFEmployeeRepoAsync, EFEmployeeRepoAsync>();  
            builder.Services.AddScoped<IEFTrainingRepoAsync, EFTrainingRepoAsync>();

            builder.Services.AddSwaggerGen(options => {
                options.MapType<DateOnly>(() => new OpenApiSchema
                {
                    Type = "string",
                    Format = "date"
                });
            });

            builder.Services.AddScoped<IEFTrainerRepoAsync, EFTrainerRepoAsync>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
