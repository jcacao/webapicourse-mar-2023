

using Microsoft.EntityFrameworkCore;

namespace EmployeesApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            // Startup ConfigureServices
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            //builder.Services.AddScoped<DepartmentsLookup>();
            builder.Services.AddScoped<ILookupDepartments, DepartmentsLookup>();
            builder.Services.AddScoped<ILookupEmployees, EntityFrameworkEmployeeLookup>();

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