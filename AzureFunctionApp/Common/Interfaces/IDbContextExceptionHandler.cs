using System;

namespace AzureFunctionApp.Common.Interfaces;
public interface IDbContextExceptionHandler
{
    public void HandleException(Exception ex);
}
