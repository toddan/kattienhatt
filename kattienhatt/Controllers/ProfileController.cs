using kattienhatt.Models;
using kattienhatt.ViewModel;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace kattienhatt.Controllers
{
    public class ProfileController : Controller
    {
        private UserManager<ApplicationUser> userManager;

        private KattienhattDbContext db = new KattienhattDbContext();

        public ProfileController()
        {
            userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new KattienhattDbContext()));
        }

        public ActionResult Index()
        {
            var user = userManager.FindById(User.Identity.GetUserId());

            if(user == null)
            {
                return HttpNotFound();
            }

            user.Profile.Media.Reverse();

            var profileviewmodel = new ProfileViewModel
            {
                Profile = user.Profile,
                Media = new Media() { ProfileId = user.Profile.ProfileId}
            };

            return View(profileviewmodel);
        }

        //
        // GET: /Profile/Details/5
        public ActionResult Details(int id)
        {
            var profile = db.Profiles.Find(id);

            if(profile == null)
            {
                return HttpNotFound();
            }

            profile.Media.Reverse();

            var profileviewmodel = new ProfileViewModel
            {
                Profile = profile
            };
            
            return View(profileviewmodel);
        }

        //
        // GET: /Profile/Edit/5
        public ActionResult Edit(int id)
        {
            var profile = db.Profiles.Find(id);

            if(profile == null)
            {
                return HttpNotFound();
            }

            return View(profile);
        }

        //
        // POST: /Profile/Edit/5
        [HttpPost]
        public ActionResult Edit(Profile profile, HttpPostedFileBase file)
        {
            string profileimagepath = "/Content/ProfileImages/";

            if(ModelState.IsValid)
            {
                if(file != null)
                {
                    file.SaveAs(HttpContext.Server.MapPath("~" + profileimagepath) + file.FileName);
                    profile.Image = profileimagepath + file.FileName;
                }

                db.Profiles.Attach(profile);
                db.Entry(profile).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(profile);
        }

        [HttpPost]
        public ActionResult AddMedia(ProfileViewModel profileviewmodel)
        {
            var profile = db.Profiles.Find(profileviewmodel.Media.ProfileId);

            if(ModelState.IsValid)
            {
                profile.Media.Add(profileviewmodel.Media);

                db.Profiles.Attach(profile);
                db.Entry(profile).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("index");
            }

            return View("Index", profileviewmodel);
        }
    }
}
