using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using Movies_PRN211.Models;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Xml.Linq;

namespace Movies_PRN211.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MoviesContext con = new MoviesContext();
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
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

        public IActionResult Index(string? name, int? caid, string? view)
        {

            var query = con.Movies.AsQueryable();
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(ok => ok.Name.Contains(name));
            }
            if (caid != null)
            {
                query = query.Where(ok => ok.CaId == (caid));
            }
            if (view != null)
            {
                if(view == "des")
                {
                    query = query.OrderByDescending(ok => ok.View);
                }
                if(view == "asc")
                {
                    query = query.OrderBy(ok => ok.View);
                }
            }
            ViewBag.caid = caid;
            ViewBag.name = name;
            ViewBag.view = view;
            return View(query);
        }

        public IActionResult Detail(int? id)
        {
            Movie e = new Movie();
            if (id != null)
            {
                e = con.Movies.FirstOrDefault(e => e.Id == id);
            }
            return View(e);
        }
        [HttpPost]
        public IActionResult Detail(int? id, int? view)
        {
            var m = con.Movies.Find(id);
            if (id != null && view != null)
            {
                m.View = view + 1;
                con.Movies.Update(m);
                con.SaveChanges();
            }
            return View(m);
        }

        public IActionResult Edit(int? id)
        {
            Movie e = new Movie();
            if (id != null)
            {
                e = con.Movies.FirstOrDefault(e => e.Id == id);
            }
            return View(e);
        }

        [HttpPost]
        public IActionResult Edit(Movie? e)
        {
            if (e != null)
            {
                con.Movies.Update(e);               
                con.SaveChanges();
            }
            ViewBag.Message = "Update successful";
            return View(e);

        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Movie? movie)
        {
            if (movie != null)
            {
                con.Movies.Add(movie);
                con.SaveChanges();
            }
            ViewBag.Message = "Create Successful";
            return View();
        }


        public IActionResult Delete(int id)
        {
            var m = con.Movies.Find(id);
            con.Movies.Remove(m);
            con.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Comment(int id, string? name, string? cmt)
        {
            Comment cmtt = new Comment();
            cmtt.Id = id;
            cmtt.Name = name;
            cmtt.Date = DateTime.Now;
            cmtt.Comment1 = cmt;
            con.Comments.Add(cmtt);
            con.SaveChanges();
            
            return RedirectToAction("Detail", new { id = id });

        }

    }
}