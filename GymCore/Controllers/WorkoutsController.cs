using GymCore.Helpers;
using GymCore.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace GymCore.Controllers
{
    [Authorize]
    public class WorkoutsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();


        private string _un;
        private string _pun;

        public string LoggedInUserName => _un = User.Identity.GetUserName();
        public string LoggedInPublicUsername => _pun = User.Identity.GetPublicUsername();

        // GET: Workouts
        public ActionResult Index()
        {
            return View(db.WorkoutsModels.ToList().Where(u => u.UserName == LoggedInPublicUsername));
        }

        public ActionResult AllWorkouts()
        {
            return View(db.WorkoutsModels.ToList());
        }

        // GET: Workouts/Details/5
        public ActionResult Details(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkoutsModel workoutsModel = db.WorkoutsModels.Find(id);
            if (workoutsModel == null)
            {
                return HttpNotFound();
            }
            if (LoggedInPublicUsername != workoutsModel.UserName)
            {
                return HttpNotFound();
            }
            return View(workoutsModel);
        }

        // GET: Workouts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Workouts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,WorkoutName,WorkoutSets,WorkoutReps1,Weight1,WorkoutReps2,Weight2,WorkoutReps3,Weight3,WorkoutReps4,Weight4")] WorkoutsModel workoutsModel)
        {
            if (ModelState.IsValid)
            {
                workoutsModel.DateTime = DateTime.Now;
                workoutsModel.UserName = LoggedInPublicUsername;
                db.WorkoutsModels.Add(workoutsModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(workoutsModel);
        }

        // GET: Workouts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkoutsModel workoutsModel = db.WorkoutsModels.Find(id);
            if (workoutsModel == null)
            {
                return HttpNotFound();
            }
            if (LoggedInPublicUsername != workoutsModel.UserName)
            {
                return HttpNotFound();
            }
            return View(workoutsModel);
        }

        // POST: Workouts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,WorkoutName,WorkoutSets,WorkoutReps1,Weight1,WorkoutReps2,Weight2,WorkoutReps3,Weight3,WorkoutReps4,Weight4")] WorkoutsModel workoutsModel)
        {
            if (ModelState.IsValid)
            {
                //Need to change these to not change values from initial create
                workoutsModel.DateTime = DateTime.Now;
                workoutsModel.UserName = LoggedInPublicUsername;
                db.Entry(workoutsModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(workoutsModel);
        }

        // GET: Workouts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkoutsModel workoutsModel = db.WorkoutsModels.Find(id);
            if (workoutsModel == null)
            {
                return HttpNotFound();
            }
            if (LoggedInPublicUsername != workoutsModel.UserName)
            {
                return HttpNotFound();
            }
            return View(workoutsModel);
        }

        // POST: Workouts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WorkoutsModel workoutsModel = db.WorkoutsModels.Find(id);
            db.WorkoutsModels.Remove(workoutsModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
