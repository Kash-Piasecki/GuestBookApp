﻿using Microsoft.AspNetCore.Mvc;

namespace GuestBookApp.Controllers
{
    public class AccountController : Controller
    {
        
        public IActionResult Register()
        {
            return View();
        }
    }
}