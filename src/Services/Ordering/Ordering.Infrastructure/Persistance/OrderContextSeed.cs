using Microsoft.Extensions.Logging;
using Ordering.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Infrastructure.Persistance
{
    public class OrderContextSeed
    {
        public static async Task SeedAsync(OrderContext orderContext, ILogger<OrderContextSeed> logger)
        {
            if (!orderContext.Orders.Any())
            {
                orderContext.Orders.AddRange(GetPreconfiguredOrders());
                await orderContext.SaveChangesAsync();
                logger.LogInformation("Seed database associated with context {DbContextName}", typeof(OrderContext).Name);
            }
        }

        private static IEnumerable<Order> GetPreconfiguredOrders()
        {
            return new List<Order>
            {
                new Order() {UserName = "swn", FirstName = "Nina", LastName = "BG", EmailAddress = "nin@gmail.com", 
                    AddressLine = "Bahcelievler", Country = "Turkey", TotalPrice = 350, State = "jfw", ZipCode = "435",
                    CVV = "test", CardName = "jifwj", CardNumber = "84752", Expiration = "jfir", PaymentMethod = 1,
                    LastModifiedBy = "5452"
                }
            };
        } 
    }
}
