using DependencyInjection.Options;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DependencyInjection.Controllers
{
    public class OptionsController : Controller
    {

        private readonly IOptions<DatabaseOptions> _databaseOptions;
        private readonly IOptions<ExternalOptions> _externalOptions;

        public OptionsController(
            IOptions<DatabaseOptions> databaseOptions,
            IOptions<ExternalOptions> externalOptions
            )
        {
            _databaseOptions = databaseOptions;
            _externalOptions = externalOptions;
        }

        public IActionResult Index()
        {
            var databaseOptions = _databaseOptions.Value;

            ViewBag.Username = databaseOptions.Username;
            ViewBag.Password = databaseOptions.Password;
            ViewBag.Hostname = databaseOptions.Hostname;
            ViewBag.Port = databaseOptions.Port;

            var externalOptions = _externalOptions.Value;

            ViewBag.ConnectionString = externalOptions.ConnectionString;

            return View();
        }
    }
}
