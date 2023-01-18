using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using XMLwork.Models;

namespace XMLwork.Controllers
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
            return View();
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
        public void DownloadXML()
        {
            string inputXMLUrl = "http://www.ploscompbiol.org/article/fetchObjectAttachment.action?uri=info%3Adoi%2F10.1371%2Fjournal.pcbi.1002244&representation=XML";
            string outputFile = Directory.GetCurrentDirectory() + "\\" + "electroTest.xml";

            WebClient webClient = new WebClient();
            string xmlString = webClient.DownloadString(inputXMLUrl);
            System.IO.File.WriteAllText(outputFile, xmlString);
        }
    }
}
