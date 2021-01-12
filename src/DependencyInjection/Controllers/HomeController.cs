using DependencyInjection.Models;
using DependencyInjection.Options;
using DependencyInjection.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Diagnostics;

namespace DependencyInjection.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly GuidWrapperService _guidWrapperService;
        private readonly ISingletonGuidService _singletonGuidService;
        private readonly IScopedGuidService _scopedGuidService;
        private readonly ITransientGuidService _transientGuidService;
        private readonly IOptionsSnapshot<DatabaseOptions> _databaseOptionsSnapshot;

        public HomeController(
            ILogger<HomeController> logger,
            GuidWrapperService guidWrapperService,
            ISingletonGuidService singletonGuidService,
            IScopedGuidService scopedGuidService,
            ITransientGuidService transientGuidService,
            IOptionsSnapshot<DatabaseOptions> databaseOptionsSnapshot)
        {
            _logger = logger;

            _guidWrapperService = guidWrapperService;
            _singletonGuidService = singletonGuidService;
            _scopedGuidService = scopedGuidService;
            _transientGuidService = transientGuidService;
            _databaseOptionsSnapshot = databaseOptionsSnapshot;
        }

        public IActionResult Index()
        {
            ViewBag.Singleton = _singletonGuidService.GetGuid();
            ViewBag.Scoped = _scopedGuidService.GetGuid();
            ViewBag.Transient = _transientGuidService.GetGuid();

            ViewBag.WSingleton = _guidWrapperService.GetSingletonGuid();
            ViewBag.WScoped = _guidWrapperService.GetScopedGuid();
            ViewBag.WTransient = _guidWrapperService.GetTransientGuid();

            return View();
        }

        public IActionResult Options()
        {
            var databaseOptions = _databaseOptionsSnapshot.Value;

            ViewBag.Username = databaseOptions.Username;
            ViewBag.Password = databaseOptions.Password;
            ViewBag.Hostname = databaseOptions.Hostname;
            ViewBag.Port = databaseOptions.Port;

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
