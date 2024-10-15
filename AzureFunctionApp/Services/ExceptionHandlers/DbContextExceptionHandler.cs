using AzureFunctionApp.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;

namespace AzureFunctionApp.Services.ExceptionHandlers;
public class DbContextExceptionHandler : IDbContextExceptionHandler
{
    private readonly ILogger _logger;

    public DbContextExceptionHandler(ILogger logger)
    {
        _logger = logger;
    }

    public void HandleException(Exception ex)
    {
        if (ex is DbUpdateException)
        {
            _logger.LogError($"DbUpdateException: {ex.Message}");
        }
        else
        {
            _logger.LogError($"Exception: {ex.Message}");
        }
    }
}
