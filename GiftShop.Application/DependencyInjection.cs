using FluentValidation;
using GiftShop.Application.Dtos;
using GiftShop.Application.Features.Behaviors;
using GiftShop.Application.Features.Products.Commands.CreateProduct;
using GiftShop.Application.Features.Products.Commands.DeleteProduct;
using GiftShop.Application.Features.Products.Commands.UpdateProduct;
using GiftShop.Application.Features.Products.Queries.GetProduct;
using GiftShop.Application.Features.Products.Queries.GetProducts;
using GiftShop.Application.Services;
using GiftShop.Application.Utils;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace GiftShop.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCoreApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddMediatR(typeof(IMediator).GetTypeInfo().Assembly);

            // Identity            
            services.AddTransient<IdentityInitializerService>();

            // Services            
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddTransient<IJwtUtils, JwtUtils>();

            // Products Handlers
            services.AddScoped<IRequestHandler<GetProductQuery, ProductDto>, GetProductHandler>();
            services.AddScoped<IRequestHandler<GetProductsQuery, List<ProductDto>>, GetProductsHandler>();
            services.AddScoped<IRequestHandler<CreateProductCommand, bool>, CreateProductHandler>();
            services.AddScoped<IRequestHandler<DeleteProductCommand, bool>, DeleteProductHandler>();
            services.AddScoped<IRequestHandler<UpdateProductCommand, bool>, UpdateProductHandler>();

            // Validators
            services.AddValidatorsFromAssemblyContaining(typeof(AbstractValidator<>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));

            return services;
        }
    }
}