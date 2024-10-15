using AzureFunctionApp.Common.Interfaces;
using AzureFunctionApp.Domain.Common;
using AzureFunctionApp.Domain.Resources;
using AzureFunctionApp.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AzureFunctionApp.Services;
public class ResourceRepository : IResourceRepository
{
    private readonly AppDbContext _context;
    private readonly IDbContextExceptionHandler _dbContextExceptionHandler;

    public ResourceRepository(AppDbContext context, IDbContextExceptionHandler dbContextExceptionHandler)
    {
        _context = context;
        _dbContextExceptionHandler = dbContextExceptionHandler;
    }

    public void AddResources(Resources resources)
    {
        try
        {
            AddOrUpdate(resources.Clients);
            AddOrUpdate(resources.Brands);
            AddOrUpdate(resources.Campaigns);
            AddOrUpdate(resources.AdRuns);
            AddOrUpdate(resources.Sizes);
            AddOrUpdate(resources.Jobs);
            AddOrUpdate(resources.Services);
            AddOrUpdate(resources.WeeklyBreakdowns);

            _context.SaveChanges();
        }
        catch (Exception ex)
        {
            _dbContextExceptionHandler.HandleException(ex);
        }
    }

    private void AddOrUpdate<T>(List<T> collection) where T : EntityBase
    {
        var existingItems = 
            _context.Set<T>().Where(
                e => collection.Select(item => item.Id).Contains(e.Id)).ToList();

        foreach (var item in collection)
        {
            var existingItem = existingItems.FirstOrDefault(e => e.Id == item.Id);

            if (existingItem != null)
            {
                _context.Entry(existingItem).CurrentValues.SetValues(item);
            }
            else
            {
                _context.Set<T>().Add(item);
            }
        }
    }
}
