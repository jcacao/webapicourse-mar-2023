

using AutoMapper;
using EmployeesApi.AutomapperProfiles;
using EmployeesApi.Controllers.Domain;
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
            // Startup ConfigureServices
            builder.Services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            //builder.Services.AddScoped<DepartmentsLookup>();
            builder.Services.AddScoped<ILookupDepartments, DepartmentsLookup>();
            builder.Services.AddScoped<ILookupEmployees, EntityFrameworkEmployeeLookup>();
            builder.Services.AddScoped<IManageEmployees, EntityFrameworkEmployeeLookup>();

            var sqlConnectionString = builder.Configuration.GetConnectionString("employees");
            Console.WriteLine("Using this connection string " + sqlConnectionString);
            if (sqlConnectionString == null )
            {
                throw new Exception("Don't start this api! Can't connect to a database");
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
                // 1 singleton service that the data context needs for connections
                // 1 scoped service for the Data Context

                options.UseSqlServer(sqlConnectionString);
            });

            var mapperConfig = new MapperConfiguration(options =>
            {
                options.AddProfile<Departments>();
               options.AddProfile<Employees>();
            });

            var mapper = mapperConfig.CreateMapper();

            builder.Services.AddSingleton<MapperConfiguration>(mapperConfig); // this has the stuff for the IQueryable (the thing turns our code into SQL)
            builder.Services.AddSingleton<IMapper>(mapper); // a utility that can "Map" stuff for us.
            var app = builder.Build();
            
            // Startup Configure
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run(); // kestrel web server is up and listening for requests. 
                            // there is only ONE of these per API
                               // It is a "Singleton"
        }
    }
}