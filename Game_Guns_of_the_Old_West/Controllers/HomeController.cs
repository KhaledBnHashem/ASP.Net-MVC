using Game_Guns_of_the_Old_West.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Game_Guns_of_the_Old_West.Controllers
{


    public class HomeController : Controller
    {
        private static int _bulletCount = 12;
        private static Player _player;

        public IActionResult Index()
        {
            ViewBag.BulletCount = _bulletCount;
            return View();
        }

        public IActionResult Winner()
        {
            return View(new Player());
        }

        [HttpPost]
        public IActionResult Winner(Player player)
        {
            if (ModelState.IsValid)
            {
                player.SubmissionTime = DateTime.Now;
                _player = player;
                return RedirectToAction("Summary");
            }
            return View(player);
        }

        public IActionResult Reload()
        {
            return View();
        }

        public IActionResult ReloadBullet(int bulletCount)
        {
            _bulletCount += bulletCount;
            return RedirectToAction("Index");
        }

        public IActionResult Summary()
        {
            return View(_player);
        }

        public IActionResult Shoot()
        {
            if (_bulletCount > 0)
            {
                _bulletCount--;
                Random random = new Random();
                int randomNumber = random.Next(0, 10);
                if (randomNumber <= 3)
                {
                    return RedirectToAction("Winner");
                }
                else
                {
                    ViewBag.BulletCount = _bulletCount;
                    return View("Index");
                }
            }
            else
            {
                return RedirectToAction("Reload");
            }
        }

    }





}