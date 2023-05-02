
using DataAccessLayer.Data;
using DataAccessLayer.DbAccess;
using MinimalAPI.Controllers;

namespace dataBringerApi
{
    public class Program
    {//first global using
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddSingleton<ISqlDataAccess, SqlDataAccess>();
            builder.Services.AddSingleton<IUserData,UserData>();
            builder.Services.AddControllers();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Get}/{id?}");

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.ConfigureApi();

            app.Run();
        }
    }
}