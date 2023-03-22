using AutoMapper;
using EmployeesApi.AutomapperProfiles;
using EmployeesApi.Adapters;
using EmployeesApi.Domain;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace EmployeesApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<ILookupDepartments, DepartmentsLookup>();
            builder.Services.AddScoped<ILookupEmployees, EntityFrameworkEmployeeLookup>();
            builder.Services.AddScoped<IManageEmployees, EntityFrameworkEmployeeLookup>();
            var sqlConnectionString = builder.Configuration.GetConnectionString("employees");
            Console.WriteLine("Using this connection string " + sqlConnectionString);
            if (sqlConnectionString == null)
            {
                throw new Exception("don't start this api! Cannot connect to a database");
            }

            // Typed or Named Client
            // - 
            builder.Services.AddHttpClient<EmployeeHiredApiAdapter>(client =>
            {
                // Singleton service for the HttpClient
                // But  the message handler is scoped.
                client.BaseAddress = new Uri(builder.Configuration.GetValue<string>("employee-api")!);
            });

            builder.Services.AddDbContext<EmployeesDataContext>(options =>
            {
                options.UseSqlServer(sqlConnectionString);
            });

            var mapperConfig = new MapperConfiguration(options =>
            {
                options.AddProfile<Departments>();
                options.AddProfile<Employees>();
            });

            var mapper = mapperConfig.CreateMapper();

            builder.Services.AddSingleton<MapperConfiguration>(mapperConfig);
            builder.Services.AddSingleton<IMapper>(mapper);

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