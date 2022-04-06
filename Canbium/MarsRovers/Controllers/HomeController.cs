using MarsRover.Repository.Provider;
using MarsRover.Service;
using MarsRover.Service.Provider;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MarsRovers.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMarsRoverService _marsRoverService;
        private readonly Invoker _invoker;
       // [Obsolete]
        private IHostingEnvironment _environment;

        //[Obsolete]
        public HomeController(IMarsRoverService marsRoverService, Invoker invoker, IHostingEnvironment environment)
        {
            _marsRoverService = marsRoverService;
            _invoker = invoker;
            _environment = environment;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
      //  [Obsolete]
        public ContentResult Index(IFormFile postedFile)
        {
            string[] maxPoints = { "5", "5" };
            string[] currentLocation;
            string movement;
            string content = string.Empty;
          
            try
            {
                if (postedFile != null)
                {
                    //Read the input from the CSV file
                    string path = Path.Combine(this._environment.WebRootPath, "Uploads");
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    string fileName = Path.GetFileName(postedFile.FileName);
                    string filePath = Path.Combine(path, fileName);
                    using (FileStream stream = new FileStream(filePath, FileMode.Create))
                    {
                        postedFile.CopyTo(stream);
                    }
                    string csvData = System.IO.File.ReadAllText(filePath);
                    List<string> list = new List<string>();
                    foreach (string row in csvData.Split('\n'))
                    {
                        if (!string.IsNullOrEmpty(row))
                        {
                            if (!string.IsNullOrEmpty(row))
                            {
                                var input = row.Split('|');
                                foreach (var c in input)
                                {
                                    list.Add(c);
                                }
                                currentLocation = list[0].Split(' ');
                                movement = list[1].Replace("\r", "");
                                var coordinates = _marsRoverService.MoveRoverSync(maxPoints, currentLocation, movement, _invoker);
                                list.Clear();
                                if (coordinates != null)
                                    content = content + coordinates.X + " " + coordinates.Y + " " + coordinates.Dir + "" + "\n";
                                else
                                    content = content + "Bad Request";
                            }
                        }
                    }
                }
                return Content(content);
            }
            catch (Exception)
            {
                content = content + "Bad Request";
                return Content(content);
            }
            finally
            {
               
            }
        }


    }
}
