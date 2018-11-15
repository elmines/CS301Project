using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace UAMovie.Controllers
{
    public class CustomerInterfaceController : Controller
    {
        public IActionResult NowPlaying()
        {
            return View();
        }
    }
}