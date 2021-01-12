using System;

namespace DependencyInjection.Services
{
    public interface IGuidService
    {
        Guid GetGuid();
    }

    public interface ISingletonGuidService : IGuidService
    {
    }

    public interface IScopedGuidService : IGuidService
    {
    }

    public interface ITransientGuidService : IGuidService
    {
    }
}
