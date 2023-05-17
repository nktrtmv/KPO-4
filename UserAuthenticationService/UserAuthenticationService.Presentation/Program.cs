using FluentValidation.AspNetCore;

using UserAuthenticationService.NamingPolicies;
using UserAuthenticationService.Infrastructure.Extensions;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = new SnakeCaseNamingPolicy();
    });

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(o =>
{
    o.CustomSchemaIds(x => x.FullName);
});

builder.Services.AddFluentValidation(conf =>
{
    conf.RegisterValidatorsFromAssembly(typeof(Program).Assembly);
    conf.AutomaticValidationEnabled = true;
});

builder.Services
    // .AddBll()
    .AddDalInfrastructure(builder.Configuration)
    .AddDalRepositories();

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.MigrateUp();

app.Run();