using LaboratorioPWA.Models;
using LaboratorioPWA.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LaboratorioPWA.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly ICrudGeneral<categoria> db = new RCategoria(); 
        // GET: Categoria
        public ActionResult Index()
        {
            var items = db.GetAll().Result;
            List<categoria> item = (List<categoria>)items;
            return View(item);
        }
        public ActionResult NuevaCategoria()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NuevaCategoria(LocalCat item)
        {
            string fileName = Path.GetFileNameWithoutExtension(item.ImageFile.FileName);
            string extension = Path.GetExtension(item.ImageFile.FileName);
            fileName = fileName +DateTime.Now.ToString("yymmssffff")+ extension;
            item.imagenCat = "~/Images/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Images/"),fileName);
            item.ImageFile.SaveAs(fileName);
            categoria cat = new categoria
            {
                imagenCat = item.imagenCat,
                nomCategoria=item.nomCategoria
            };
            var resp = db.Post(cat);
            if (!resp.IsSuccess)
            {
                return View();
            }
            else
            {
                return Redirect("~/categoria");
            }
        }
        public ActionResult Editar(int id)
        {
            var item = (categoria)db.GetById(id).Result;
            ViewBag.LastPic = item.imagenCat;
            LocalCat item2 = new LocalCat
            {
                idcategoria=id,
                nomCategoria=item.nomCategoria,
            };
            return View(item2);
        }
        [HttpPost]
        public ActionResult Editar(LocalCat item)
        {
            if (item.ImageFile!=null)
            {
                string fileName = Path.GetFileNameWithoutExtension(item.ImageFile.FileName);
                string extension = Path.GetExtension(item.ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssffff") + extension;
                item.imagenCat = "~/Images/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Images/"), fileName);
                item.ImageFile.SaveAs(fileName);
                categoria cat = new categoria
                {
                    imagenCat = item.imagenCat,
                    nomCategoria = item.nomCategoria
                };
                var resp = db.Update(cat,item.idcategoria);
                if (!resp.IsSuccess)
                {
                    return View();
                }
                else
                {
                    return Redirect("~/categoria");
                }
            }
            else
            {
                var item2 = db.GetById(item.idcategoria);
                var cate = (categoria)item2.Result;
                cate.nomCategoria = item.nomCategoria;
                var resp = db.Update(cate, item.idcategoria);
                if (!resp.IsSuccess)
                {
                    return View();
                }
                else
                {
                    return Redirect("~/categoria");
                }
            }
        }
        [HttpGet]
        public ActionResult Eliminar(int id)
        {
            var resp = db.Delete(id);
            return Redirect("~/categoria");
        }
    }
}