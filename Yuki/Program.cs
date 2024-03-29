var assembly = typeof(Program).Assembly;
var builder = WebApplication.CreateBuilder(args);

const string allowAllOrigins = "_allowAllOrigins";

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddCarter();

builder.Services.AddSwaggerGen(options => { options.CustomSchemaIds(type => type.ToString()); });

builder.Services.AddEfCore();
builder.Services.AddQuartz();

builder.Services.AddInvoicesFeature();

builder.Services.AddMediatR(config =>
    config.RegisterServicesFromAssembly(assembly));

builder.Services.AddValidatorsFromAssembly(assembly);

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: allowAllOrigins,
        policyBuilder =>
        {
            policyBuilder
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(allowAllOrigins);

app.UseExceptionHandler();

app.UseHttpsRedirection();

app.MapCarter();

app.Run();