using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBaseModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NoteSaverWeb.Models;

namespace NoteSaverWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly INoteSaverDbContext _noteSaverDbContext;

        public HomeController(ILogger<HomeController> logger, INoteSaverDbContext noteSaverDbContext)
        {
            _logger = logger;
            _noteSaverDbContext = noteSaverDbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var content = _noteSaverDbContext.InnerContents.FirstOrDefault();
            var editor = new EditorViewModel() { Content = "" };

            if (content != null)
            {
                editor.Content = content.InnerText;
            }

            return View(editor);
        }

        [HttpPost]
        public IActionResult Index(EditorViewModel editor)
        {
            var content =_noteSaverDbContext.InnerContents.FirstOrDefault();

            if (content != null)
            {
                content.InnerText = editor.Content;
            }
            else
            {
                content = new InnerContent()
                {
                    InnerText = editor.Content,
                    TabId = 1,
                    UserId = 1,
                };
                _noteSaverDbContext.InnerContents.Add(content);
            }

            _noteSaverDbContext.SaveChanges();           

            return View(editor);
        }

        [HttpGet]
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
