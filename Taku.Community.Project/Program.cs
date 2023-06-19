using Microsoft.EntityFrameworkCore;
using Taku.Community.Project.Data;
using Taku.Community.Project.Domain;
using Taku.Community.Project.Domain.CommandHandlers.AccountDetails;
using Taku.Community.Project.Domain.CommandHandlers.CardDetails;
using Taku.Community.Project.Domain.QueryHandlers.CardDetails;

namespace Taku.Community.Project.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));


            builder.Services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(Program).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(GetCardByIdQueryHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(AddAccountCommandHandler).Assembly);
            });

            builder.Services.AddTransient(typeof(IRepository<>), typeof(GenericRepository<>));
            builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();


            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
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