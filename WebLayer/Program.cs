
using InspectionCenter.Application.MainServices;
using InspectionCenter.Application.ServiceInterfaces;
using InspectionCenter.Infrastructure.Context;
using InspectionCenter.Repositories.MainRepositories;
using InspectionCenter.Repositories.RepositoryInterface;
using Microsoft.EntityFrameworkCore;

namespace WebLayer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                {
                    policy.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
                });
            });

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<InspectionDbContext>(options =>
               options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
            );

            builder.Services.AddScoped<IUserService ,UserService>();
            builder.Services.AddScoped<IUserRepository ,UserRepository>();
            builder.Services.AddScoped<IProvinceRepository ,ProvinceRepository>();
            builder.Services.AddScoped<IProvinceRepository, ProvinceRepository>();
            builder.Services.AddScoped<ICarService ,CarService>();
            builder.Services.AddScoped<ICarRepository ,CarRepository>();
            builder.Services.AddScoped<ICityService ,CityService>();
            builder.Services.AddScoped<ICityRepository ,CityRepository>();
            builder.Services.AddScoped<IAdminService ,AdminService>();
            builder.Services.AddScoped<ICenterService ,CenterService>();
            builder.Services.AddScoped<ICenterRepository ,CenterRepository>();
            builder.Services.AddScoped<IAppointmentService ,AppointmentService>();
            builder.Services.AddScoped<IAppointmentRepository ,AppointmentRepository>();
            builder.Services.AddScoped<IScheduleService ,ScheduleService>();
            builder.Services.AddScoped<IScheduleRepository ,ScheduleRepository>();

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            var app = builder.Build();

            app.UseCors("AllowAll");
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
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
