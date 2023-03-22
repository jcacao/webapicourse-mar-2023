using EmployeesApi.Adapters;
using EmployeesApi.Domain;
using Microsoft.EntityFrameworkCore;

namespace EmployeesApi
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
            builder.Services.AddScoped<ILookupDepartments, DepartmentsLookup>();
            builder.Services.AddScoped<ILookupEmployees, EntityFrameworkEmployeeLookup>();
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