using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;

using DIExample.Controllers;
using DIExample.Data;
using DIExample.Data.Repositories;
using DIExample.Domain.Services;

namespace DIExample.CompositionRoot
{
    public class CommerceControllerActivator : IControllerActivator
    {
        private readonly string _connectionString;


        public CommerceControllerActivator(string connectionString)
        {
            ArgumentNullException.ThrowIfNull(connectionString, nameof(connectionString));

            if (string.IsNullOrEmpty(connectionString))
                throw new ArgumentException("Connection string wasn't be empty!");

            _connectionString = connectionString;
        }


        public object Create(ControllerContext context)
        {
            Type controllerType = 
                context.ActionDescriptor.ControllerTypeInfo.AsType();

            CommerceContext commerceContext = new(_connectionString);

            if (controllerType == typeof(HomeController))
                return CreateController(commerceContext);

            throw new Exception($"Controller type \'{controllerType.Name}\' is not supported!");
        }

        public void Release(ControllerContext context, object controller)
        {
            (controller as IDisposable)?.Dispose();
        }

        private static Controller CreateController(CommerceContext commerceContext)
        {
            return new HomeController(
                new ProductService(
                    new SqlProductsRepository(commerceContext),
                    new AspNetUserContextAdapter()));
        }
    }
}
