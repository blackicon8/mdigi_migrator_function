using AzureFunctionApp.Domain.Resources;

namespace AzureFunctionApp.Common.Interfaces;
public interface IResourceRepository
{
    public void AddResources(Resources resources);
}
