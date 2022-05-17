using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OnionArchExample.Application.Features.Queies.GetAllProducts;
using OnionArchExample.Application.Interfaces.Repository;
using OnionArchExample.Infrastructure.Context;
using OnionArchExample.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchExample.Infrastructure
{
    public static class ServiceInjection
    {
        public static void AddPersistenceServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<ApplicationDbContext>(opt => opt.UseInMemoryDatabase("memoryDb"));

            serviceCollection.AddTransient<IProductRepository, ProductRepository>();

            //serviceCollection.AddMediatR(Assembly.GetExecutingAssembly());
            serviceCollection.AddMediatR(typeof(GetAllProductsQuery).GetTypeInfo().Assembly);
        }
    }
}
