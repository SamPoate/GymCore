using GymCore.Models;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Mvc;

namespace GymCore.Controllers
{
    [Authorize]
    public class UserBiometricsController : Controller
    {
        //Need to take logic to a service layer class
        private readonly ApplicationDbContext _db = new ApplicationDbContext();

        // GET: UserBiometrics
        public ActionResult Home()
        {
            var loggedInUserId = User.Identity.GetUserId();
            var userInDatabase = _db.Users.FirstOrDefault(i => i.Id == loggedInUserId);

            var loggedInUserBios = _db.Users.Find(userInDatabase.Id).UserBiometricsModels.LastOrDefault();

            return View(loggedInUserBios);
        }

        //GET
        public ActionResult AddDetails()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddDetails([Bind(Include = "UserId,Height,Weight,Age,Gender")] UserBiometricsModel userBiometricsModel)
        {
            var loggedInUserId = User.Identity.GetUserId();
            var userInDatabase = _db.Users.FirstOrDefault(i => i.Id == loggedInUserId);

            if (ModelState.IsValid)
            {
                _db.Users.Find(userInDatabase.Id).UserBiometricsModels.Add(userBiometricsModel);
                _db.SaveChanges();

                return RedirectToAction("Home");
            }

            return View(userBiometricsModel);
        }
    }
}