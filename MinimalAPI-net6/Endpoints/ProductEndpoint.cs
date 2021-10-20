using FluentValidation;
using MinimalApI_net6.Config;
using MinimalApI_net6.Models;
using MinimalApI_net6.Repository;

namespace MinimalApI_net6.Endpoints
{
    public class ProductEndpoint : IEndpoint
    {
        public void DefineEndpoints(WebApplication app)
        {

            app.MapGet("/Products", GetAll);

            app.MapGet("/Product/{id}", GetProductById).WithName("GetProductById");

            app.MapPost("/Product", CreateProduct)
                .Produces(StatusCodes.Status400BadRequest)
                .Produces<Product>(StatusCodes.Status201Created);

            app.MapPut("/Product", UpdateProduct);//.RequireAuthorization();

            app.MapDelete("/Product", DeleteProduct);
        }
        internal IEnumerable<Product> GetAll(IProductRepository ProductRepo) => ProductRepo.GetAll();
        internal IResult GetProductById(IProductRepository productRepo, int id)
        {
            var Product = productRepo.GetById(id);
            return (Product is null ? Results.NotFound() : Results.Ok(Product));
        }
        internal IResult CreateProduct(IProductRepository productRepo, IValidator<Product> validator, Product product)
        {
            var productValidation = validator.Validate(product);
            if (!productValidation.IsValid)
            {
                return Results.BadRequest(productValidation.Errors.Select(x => new { errors = x.ErrorMessage }));
            }
            if (product is null)
                return Results.BadRequest();
            if (productRepo.GetById(product.Id) is not null)
                return Results.BadRequest("This product is already exist");
            productRepo.Create(product);
            return Results.CreatedAtRoute("GetProductById", new { id=product.Id}, product);
        }
        internal IResult UpdateProduct(IProductRepository productRepo, Product product)
        {
            if (productRepo.GetById(product.Id) is null)
                return Results.NotFound();

            var result = productRepo.Update(product);
            return Results.Ok(result);
        }
        internal IResult DeleteProduct(IProductRepository productRepo, int id)
        {
            if (productRepo.GetById(id) is null)
                return Results.NotFound();

            productRepo.Delete(id);
            return Results.Ok();
        }
    }
}
