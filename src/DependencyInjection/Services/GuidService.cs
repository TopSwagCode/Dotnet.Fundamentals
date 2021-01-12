using System;

namespace DependencyInjection.Services
{
    public class GuidService : IGuidService, ISingletonGuidService, IScopedGuidService, ITransientGuidService
    {
        private Guid _guid;

        public GuidService()
        {
            _guid = Guid.NewGuid();
        }

        public Guid GetGuid()
        {
            return _guid;
        }
    }
}
