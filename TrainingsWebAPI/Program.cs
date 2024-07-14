using EFTrainingLibrary.Models;
using EFTrainingLibrary.Repos;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TrainingUserLibrary.Repos;
namespace TrainingsWebAPI
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
            builder.Services.AddScoped<IEFTechnologyRepoAsync, EFTechnologyRepoAsync>();
            builder.Services.AddScoped<IEFEmployeeRepoAsync,EFEmployeeRepoAsync>();
            builder.Services.AddScoped<IEFTrainerRepoAsync, EFTrainerRepoAsync>();
            builder.Services.AddScoped<IEFTrainingRepoAsync, EFTrainingRepoAsync>();
            builder.Services.AddScoped<IETraineeRepoAsync, EFTraineeRepoAsync>();
            builder.Services.AddScoped<ITrainingUserRepo, TrainingUserRepo>();
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new
                Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = "https://www.Chetan.com",
                    ValidAudience = "https://www.Chetan.com",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("hello hi how are you heaven knows i am miserable now"))
                };
            });
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("MyPolicy", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseCors("MyPolicy");
            app.MapControllers();

            app.Run();
        }
    }
}
