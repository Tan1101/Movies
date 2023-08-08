using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Movies_PRN211.Models;
using Newtonsoft.Json;

namespace Movies_PRN211.Controllers
{
    public class AccountController : Controller
    {
        private readonly MoviesContext _context;

        public AccountController(MoviesContext context)
        {
            _context = context;
        }

        

        // GET: AccountController
        public IActionResult Login()
        {
            if (TempData.ContainsKey("SuccessRegister"))
            {
                ViewBag.SuccessMessage = TempData["SuccessRegister"];
            }
            Account _user = new Account();
            return View(_user);
        }

        [HttpPost]
        public IActionResult Login(Account account)
        {
            var user = _context.Accounts.FirstOrDefault(a => a.Gmail == account.Gmail && a.Password == account.Password);
            if (user != null)
            {
                // Convert the user object to JSON string and store it in the Session
                string userJson = JsonConvert.SerializeObject(user);
                HttpContext.Session.SetString("User", userJson);

                // Redirect to the Admin Dashboard page if the user has Role 0
                if (user.Role == "admin")
                {
                    return RedirectToAction("Index", "Home", new { area = "Admin" });
                }
                // Redirect to the User Home page if the user has Role 1
                else if (user.Role == "user")
                {
                    return RedirectToAction("Index", "Home", new { area = "" });
                }
            }
            else
            {
                ViewBag.message = "Username or password not correct";
            }

            // Return the Login View with the account information if login is unsuccessful
            return View(account);
        }
        public ActionResult Logout()
        {
            HttpContext.Session.Remove("User");
            return RedirectToAction("Index", "Home");
        }

        

    }
}
