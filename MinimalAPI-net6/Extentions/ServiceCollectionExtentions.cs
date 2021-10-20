using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using MinimalAPI_net6.Endpoints;
using MinimalAPI_net6.EndPoints;
using MinimalAPI_net6.Repository;

namespace MinimalAPI_net6.Extentions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MinimalAPI-Demo", Version = "v1" });
            });
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer();
            services.AddAuthorization();    
            services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Product>());

            services.AddSingleton<IProductRepository, ProductRepository>();
            services.AddSingleton<IEndpoint, ProductEndpoint>();
           
            return services;
        }
    }
}
