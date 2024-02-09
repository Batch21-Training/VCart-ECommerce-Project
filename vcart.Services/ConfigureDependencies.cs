using vcart.Core;
using vcart.Core.Entities;
using vcart.Repositories.Implementations;
using vcart.Repositories.Interfaces;
using vcart.Services.Implementations;
using vcart.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace vcart.Services
{
    public static class ConfigureDependencies
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration config)
        {
            //database
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(config.GetConnectionString("DbConnection"));
            });

            services.AddScoped<DbContext, AppDbContext>();

            //repository
            services.AddScoped<IRepository<Category>, Repository<Category>>();
            services.AddScoped<IRepository<Item>, Repository<Item>>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IRepository<CartItem>, Repository<CartItem>>();
            services.AddScoped<IRepository<PaymentDetail>, Repository<PaymentDetail>>();
            services.AddScoped<IRepository<Order>, Repository<Order>>();
            services.AddScoped<IRepository<OrderItem>, Repository<OrderItem>>();


            services.AddScoped<ICartRepository, CartRepository>();

            //services
            services.AddScoped<IService<Item>, Service<Item>>();
            services.AddScoped<IService<Order>, Service<Order>>();
            services.AddScoped<IService<OrderItem>, Service<OrderItem>>();

            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IItemService, ItemService>();
            services.AddScoped<ICartService, CartService>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IOrderItemService, OrderItemService>();
        }
    }
}
