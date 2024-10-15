using AzureFunctionApp.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace AzureFunctionApp.Common.Extensions
{
    public static class EFCoreExtensions
    {
        public static void AddUniques<T>(this DbContext dbContext, List<T> collection) where T : EntityBase
        {
            var storedItems = dbContext.Set<T>().AsQueryable().ToList();
            var newItems = collection.Where(item => !storedItems.Any(storedItem => storedItem.Id == item.Id));
            dbContext.Set<T>().AddRange(newItems);
        }

        public static void AddUniques<T>(this DbSet<T> dbSet, List<T> collection) where T : EntityBase
        {
            var storedItems = dbSet.AsQueryable().ToList();
            var newItems = collection.Where(item => !storedItems.Any(storedItem => storedItem.Id == item.Id));
            dbSet.AddRange(newItems);
        }
    }
}
