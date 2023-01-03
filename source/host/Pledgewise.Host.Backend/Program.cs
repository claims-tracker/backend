using Pledgewise.Host.Backend.Dal;
using Pledgewise.Host.Backend.OpenApi;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using Unchase.Swashbuckle.AspNetCore.Extensions.Extensions;
using AutoMapper.Internal;
using Pledgewise.Host.Backend.Automapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Pledgewise", Version = "v1" });
    c.EnableAnnotations();
    c.CustomSchemaIds(OpenApiExtensions.DefaultSchemaIdSelector);
    c.CustomOperationIds(OpenApiExtensions.DefaultOperationIdSelector);

    var basePath = AppContext.BaseDirectory;
    c.IncludeXmlComments(Path.Combine(basePath, "Pledgewise.Common.xml"));
    c.IncludeXmlComments(Path.Combine(basePath, "Pledgewise.Common.Web.xml"));
    c.SchemaFilter<EnumDescriptorSchemaFilter>();

    // Unchase extensions
    // This causes UNKNOWN_BASE_TYPE when generating SDK
    c.UseAllOfToExtendReferenceSchemas();
    c.AddEnumsWithValuesFixFilters();
    c.DescribeAllParametersInCamelCase();
});
builder.Services.AddSwaggerGenNewtonsoftSupport();
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", p =>
        p.WithOrigins(
            builder.Configuration["Frontend:Url"].TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar)
        ).
        AllowAnyMethod().
        AllowAnyHeader().
        AllowCredentials()
    );
});
builder.Services.AddDbContext<MainDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("MainDb"));
});
builder.Services.AddAutoMapper(cfg =>
{
    cfg.AllowNullCollections = true;
    InternalApi.Internal(cfg).ForAllPropertyMaps(
        pm => true,
        (pm, c) =>
            c.MapFrom<NullableResolver, object>(pm.SourceMember.Name));
}, AppDomain.CurrentDomain.GetAssemblies().Where(a => a.FullName.StartsWith("GuestBell")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
