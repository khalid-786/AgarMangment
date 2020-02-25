using Microsoft.AspNet.Identity;
using RoomManage.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace RoomManage.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            var list = db.Categories.ToList();
            return View(list);
        }
        public ActionResult changeLanguage(string languageAbberation)
        {
            if (languageAbberation != null)
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(languageAbberation);
                Thread.CurrentThread.CurrentUICulture = new  CultureInfo(languageAbberation);
            }
            HttpCookie cookie = new HttpCookie("language");
            
            cookie.Value = languageAbberation;
            Response.Cookies.Add(cookie);
            Session["language"] = languageAbberation;
            var list = db.Categories.ToList();
            return red("Index" ,list);
        }
        // GET: Barrennesses/Details/5
        public ActionResult Details(int? barrennesId)
        {
            if (barrennesId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            /*var Jobs = from app in db.Barrennesses
                       join user in db.Users
                       on app.UserId equals user.Id
                       where app.Id == barrennesId
                       select app;*/
            Barrenness barrenness = db.Barrennesses.Find(barrennesId);
            if (barrenness == null)
            {
                return HttpNotFound();
            }
            Session["BarrennessIs"] = barrennesId;
            return View(barrenness);
        }
        [Authorize]
        [HttpGet]
        public ActionResult Apply() {
            return View();

        }
        
        [HttpPost] 
        public ActionResult Apply(string Message)
        {
            var applierId = User.Identity.GetUserId();
            var barrenssId = (int)Session["BarrennessIs"];
            var barrnn = db.Barrennesses.Find(barrenssId);
            if (Message != "")
            {
                var check = db.ApplyForBarrennes.Where(a => a.BarrennessId == barrenssId && a.UserId == applierId).ToList();
                if (check.Count < 1)
                {
                    ApplyForBarrennes barrennes = new ApplyForBarrennes();
                    barrennes.UserId = applierId;
                    barrennes.BarrennessId = barrenssId;
                    barrennes.ApplyDate = DateTime.Now;
                    barrennes.Message = Message;
                    db.ApplyForBarrennes.Add(barrennes);
                    db.SaveChanges();
                    barrnn.Number -= 1;
                    db.SaveChanges();
                    ViewBag.Result = Resources.BarrennessController.ApplySuccessMessage;
                }
                else
                {
                    ViewBag.Result = Resources.BarrennessController.ApplyErrorMessage;
                }
            }
            else {
                ViewBag.Result = Resources.BarrennessController.ApplyMessageRequired; 
            }
            return View();
        }
        [Authorize]
        public ActionResult getBarrennesApplier(int b_Id) {
           
            var barrennes = from app in db.ApplyForBarrennes
                       join applier in db.Users
                       on app.UserId equals applier.Id
                       join publish in db.Barrennesses
                       on applier.Id equals publish.UserId
                            where app.BarrennessId == b_Id
                            select new getBarrennesApplierViewModel
                            {
                              username = applier.UserName ,
                              phoneNumber = applier.PhoneNumber ,
                              address = applier.fullAdress ,
                              apply_id = app.Id ,
                              applier_id = app.UserId

                            };
          
            return View(barrennes.ToList());
        }
        [Authorize]
        public ActionResult chat(int Id)
        {
            Session["applyId"] = Id;
            var applyId = (int)Session["applyId"];
            var sender_id = User.Identity.GetUserId();
            //var reciver_id = (int)Session["reciverId"];
            ViewBag.applyid = Session["applyId"];
            var d = db.ApplyForBarrennes.Find(applyId);
            ViewBag.reciverid = d.UserId;
            var chatingMessage = db.Chatings.Where(a => a.applyId == Id).ToList();
            var messagecount = db.Chatings.Where(a =>  a.reciver == sender_id && a.applyId == Id).Count();
            Session["messagecount"] = messagecount;
            return View(chatingMessage);
        }
        [Authorize]
        public JsonResult loadMessage()
        {
            var applyId = (int)Session["applyId"];
            var chatingMessage = db.Chatings.Where(a => a.applyId == applyId).ToList();
            return Json(chatingMessage , JsonRequestBehavior.AllowGet);
        }
        [Authorize]
        public string sendMessaged(string message)
        {
            var sender_id = User.Identity.GetUserId();
             var applyId = (int)Session["applyId"];
             var apply = db.ApplyForBarrennes.Find(applyId);
            Chating chat = new Chating();
            var today = DateTime.Now;
            string reciver;
            if (apply.UserId == sender_id) {
                reciver = apply.barrennes.UserId;
            }
            else
            {
                reciver = apply.UserId;
            }
            chat.applyId = applyId;
            chat.sender = sender_id;
            chat.reciver = reciver;
            chat.sendDate = today.ToString();
            chat.message = message;
            db.Chatings.Add(chat);
            db.SaveChanges();
            return today.ToString(); 
        }
        [Authorize]
        public ActionResult comment()
        {
            var today = DateTime.Today.ToShortDateString();
            var sender_id = User.Identity.GetUserId();
            var toDayComment = db.Comments.Where(a => a.sendDate.Contains(today.ToString()) && a.UserId == sender_id).ToList();
            return View(toDayComment);
        }
        public string sendComment(string message)
        {
            var sender_id = User.Identity.GetUserId();
            Comment comment = new Comment();
            var today = DateTime.Today.ToShortDateString();
            comment.UserId = sender_id;
            comment.sendDate = today.ToString();
            comment.message = message;
            db.Comments.Add(comment);
            db.SaveChanges();
            return today.ToString();
        }
        [Authorize(Roles = "Admins")]
        public ActionResult getUserComment()
        {
            var today = DateTime.Today.ToShortDateString();
            var toDayComment = db.Comments.Where(a => a.sendDate.Contains(today.ToString())).ToList();
            return View(toDayComment);
        }
        [Authorize(Roles = "Admins")]
        public string deleteComment(int id)
        {
            Comment comment = db.Comments.Find(id);
            db.Comments.Remove(comment);
            db.SaveChanges();
            return Resources.AccountController.DeleteCommentSuccessMessage;
        }
        [Authorize(Roles = "Admins")]
        public ActionResult searchCommentByDate(DateTime AutoSearch)
        {
            var today = AutoSearch.Date.ToShortDateString();
            var toDayComment = db.Comments.Where(a => a.sendDate.Contains(today.ToString())).ToList();
                return PartialView(toDayComment);
      
        }
        public ActionResult getBarrennesByApplier()
        {
            var userId = User.Identity.GetUserId();

            var barrennes = from app in db.ApplyForBarrennes
                            join barrenn in db.Barrennesses
                            on app.BarrennessId equals barrenn.Id
                            where app.UserId == userId
                            select new getBarrennesByApplierViewModel
                            {
                                barrennessDesc = barrenn.barrenessDescription,
                                price = barrenn.leasePrice,
                                fulladdress = barrenn.fullLocation,
                                apply_id = app.Id,
                                applier_id = app.UserId ,
                                publisher_id = barrenn.User.UserName ,
                                state = barrenn.state
                            };

            return View(barrennes.ToList());
        }
        public ActionResult search()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "CategoryTitle");
            ViewBag.State = new SelectList(new[] { "الجزيرة", "الخرطوم", "سنار", "القضارف", "كسلا", "البحر الأحمر", "نهر النيل", "شمال كردفان" });

            return View();
        }
        public ActionResult SearchBarrennes(string AutoSearch, int CategoryId)
        {
            var barrennesSearch = db.Barrennesses.Where(a => a.CategoryId == CategoryId
            && a.state.Contains(AutoSearch)
            ).ToList();
            return View(barrennesSearch);
        }
        public ActionResult getBarrennesByCategory(int Id)
        {
            var barrennesSearch = db.Barrennesses.Where(a => a.CategoryId == Id   ).ToList();
            return View(barrennesSearch);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
                }
    }
}