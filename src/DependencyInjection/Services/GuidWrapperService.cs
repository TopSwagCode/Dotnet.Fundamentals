using System;

namespace DependencyInjection.Services
{
    public class GuidWrapperService
    {
        private readonly ISingletonGuidService _singletonGuidService;
        private readonly IScopedGuidService _scopedGuidService;
        private readonly ITransientGuidService _trasientGuidService;

        public GuidWrapperService(ISingletonGuidService singletonGuidService, IScopedGuidService scopedGuidService, ITransientGuidService trasientGuidService)
        {
            _singletonGuidService = singletonGuidService;
            _scopedGuidService = scopedGuidService;
            _trasientGuidService = trasientGuidService;
        }

        public Guid GetSingletonGuid()
        {
            return _singletonGuidService.GetGuid();
        }

        public Guid GetScopedGuid()
        {
            return _scopedGuidService.GetGuid();
        }

        public Guid GetTransientGuid()
        {
            return _trasientGuidService.GetGuid();
        }
    }
}
