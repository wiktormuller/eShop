using Autofac;
using eShop.Domain.Interfaces;
using eShop.Infrastructure.Services;

namespace eShop.Infrastructure.IoC.Modules
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<AuthService>().As<IAuth>().InstancePerLifetimeScope();
            builder.RegisterType<CartItemService>().As<ICartItem>().InstancePerLifetimeScope();
            builder.RegisterType<EncrypterService>().As<IEncrypter>().InstancePerLifetimeScope();
            builder.RegisterType<JwtService>().As<IJwt>().InstancePerLifetimeScope();
            builder.RegisterType<OrderService>().As<IOrder>().InstancePerLifetimeScope();
            builder.RegisterType<ProductService>().As<IProduct>().InstancePerLifetimeScope();
            builder.RegisterType<ShoppingCartService>().As<IShoppingCart>().InstancePerLifetimeScope();
            builder.RegisterType<UserService>().As<IUser>().InstancePerLifetimeScope();
        }
    }
}
