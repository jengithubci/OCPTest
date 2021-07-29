using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OCPSample.Models;
using Npgsql;

namespace OCPSample.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //var cs = "Host=localhost;Username=postgres;Password=s$cret;Database=sampledb";

            //var cs = "User ID=sqlrd;Password=rd@12345;Host=172.30.231.186;Port=5432;Database=sampledb;Pooling=true;Min Pool Size=0;Max Pool Size=100;Connection Lifetime=0;";

            var cs = "User ID=sqlrd1;Password=rd-12345;Host=172.30.231.186;Port=5432;Database=sampledb;Pooling=true;Connection Lifetime=0;";
            
            var con = new NpgsqlConnection(cs);
            con.Open();

            var sql = "SELECT version()";

            using var cmd = new NpgsqlCommand(sql, con);

            var version = cmd.ExecuteScalar().ToString();
            


            /* cmd.CommandText = "INSERT INTO cars(name, price) VALUES('Audi',52642)";
            cmd.ExecuteNonQuery();
            */

            //var val = "xyz";

            return View("Index", version);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
