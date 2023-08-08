using Microsoft.AspNetCore.Mvc;
using Movies_PRN211.Interfaces;
using Movies_PRN211.Models;

namespace Movies_PRN211.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IAccountRepository _accountRepository;

        public RegisterController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public IActionResult Register()
        {
            if (TempData["errorExist"] != null)
            {
                ViewBag.exit = TempData["errorExist"];
            }
            return View(new Account());
        }

        [HttpPost]
        public IActionResult Register(Account model)
        {
            if (ModelState.IsValid)
            {
                var checkExit = _accountRepository.isExits(model.Gmail);
                if (checkExit)
                {
                    TempData["errorExist"] = "User Name Is Exist";
                    ViewBag.exit = TempData["errorExist"];
                    return View(model);
                }
                else
                {
                    _accountRepository.AddAccount(model);
                    TempData["success"] = "Your account has just been created successfully";
                    return RedirectToAction("Login", "Account");
                }
            }
            else
            {
                return View(model);
            }
        }
    }
}
