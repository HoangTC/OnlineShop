using OnlineShop.DAL;
using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Controllers
{
    public class HomeController : Controller
    {
        OnlineShopContext db = new OnlineShopContext();
        public ActionResult Index()
        {
            ViewBag.ListCategory = db.Categories;
            var products = db.Products.Include(p => p.Category);
            return View(products.ToList());
        }

        public ActionResult List(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.Category = db.Categories.Where(c => c.CategoryId == id).Select(c => c.Name).FirstOrDefault();
            ViewBag.ListCategory = db.Categories;
            var products = db.Products.Where(p => p.CategoryId == id);
            return View(products.ToList());
        }

        [HttpGet]
        public ActionResult Login()
        {
            if (Session["Id"] != null)
                return RedirectToAction("Index", "Home");
            return View();
        }

        [HttpPost]
        public ActionResult Login([Bind(Include = "Username,Password")] User account)//string Username, string Password)
        {
            if (ModelState.IsValid)
            {
                var user = db.Users.Where(u => u.Username == account.Username && u.Password == account.Password).FirstOrDefault();
                if (user != null)
                {
                    Session["Id"] = user.Id;
                    return RedirectToAction("Index", "Products");
                }
                ViewBag.Message = "Tài khoản hoặc mật khẩu không đúng";
            }
            return View();
        }

        [HttpPost]
        public void EditProduct([Bind(Include = "Id,Name,ImageData,ImageFile,CategoryId")] Product product)
        {
            var file = product.ImageFile;
            if (file != null && file.ContentLength > 0)
            {
                if (product.ImageData != "default.png")
                {
                    System.IO.File.Delete(Server.MapPath("~/Content/Images/" + product.ImageData));
                }
                file.SaveAs(Server.MapPath("~/Content/Images/" + file.FileName));
                product.ImageData = file.FileName;
                
            }
            db.Entry(product).State = EntityState.Modified;
            db.SaveChanges();

            return;
        }

        [HttpPost]
        public void CreateProduct([Bind(Include = "Id,Name,ImageData,ImageFile,CategoryId")] Product product)
        {
            var file = product.ImageFile;
            if (file != null && file.ContentLength > 0)
            {
                file.SaveAs(Server.MapPath("~/Content/Images/" + file.FileName));
                product.ImageData = file.FileName;
            }
            db.Products.Add(product);
            db.SaveChanges();
            
            return;
        }

        // GET: Products1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
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

        [HttpGet]
        public ActionResult Logout()
        {
            Session["Id"] = null;
            return RedirectToAction("Login", "Home");
        }
    }
}