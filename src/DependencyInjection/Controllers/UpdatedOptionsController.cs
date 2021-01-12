using DependencyInjection.Options;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DependencyInjection.Controllers
{
    public class UpdatedOptionsController : Controller
    {

        private readonly IOptionsSnapshot<DatabaseOptions> _databaseOptionsSnapshot;
        private readonly IOptionsSnapshot<ExternalOptions> _externalOptionsSnapshot;

        public UpdatedOptionsController(
            IOptionsSnapshot<DatabaseOptions> databaseOptionsSnapshot,
            IOptionsSnapshot<ExternalOptions> externalOptionsSnapshot)
        {
            _databaseOptionsSnapshot = databaseOptionsSnapshot;
            _externalOptionsSnapshot = externalOptionsSnapshot;
        }

        public IActionResult Index()
        {
            var databaseOptions = _databaseOptionsSnapshot.Value;

            ViewBag.Username = databaseOptions.Username;
            ViewBag.Password = databaseOptions.Password;
            ViewBag.Hostname = databaseOptions.Hostname;
            ViewBag.Port = databaseOptions.Port;

            var externalOptions = _externalOptionsSnapshot.Value;

            ViewBag.ConnectionString = externalOptions.ConnectionString;

            return View();
        }
    }
}
