using Microsoft.AspNetCore.Authentication.JwtBearer;
using FluentValidation;
using Microsoft.OpenApi.Models;
using MinimalApI_net6.Endpoints;
using MinimalApI_net6.Repository;
using FluentValidation.AspNetCore;
using MinimalApI_net6.Models;

namespace MinimalApI_net6.Config
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
