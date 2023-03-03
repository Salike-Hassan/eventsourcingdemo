using EventSourcing.Application.Handlers;
using EventSourcing.Application.Repositories;
using QuadPay.EventStore.EventStore;
using QuadPay.MediatR;

namespace EventSourcing.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);


        // Add services to the container.
        builder.Services
             .AddLogging()
            .AddSingleton(builder.Environment)
            .AddSingleton(builder.Configuration);

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services
             .AddEventStore(
                builder.Configuration.GetConnectionString("EventStore"),
                builder.Configuration.GetValue<string>("QP_TERRITORY"),
                builder.GetType().Assembly);

        builder.Services
            .AddScoped<IPostAggregateRepository, PostAggregateRepository>();

        builder.Services
            .ConfigureMediatR(builder.Configuration, typeof(CreatePostHandler).Assembly);

        var app = builder.Build();
        // Configure the HTTP request pipeline.
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