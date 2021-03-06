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
    public class JuegosController : Controller
    {
        private readonly RJuego db = new RJuego();
        private readonly ICrudGeneral<categoria> dbCategoria = new RCategoria();
        // GET: Juegos
        public ActionResult Index()
        {
            var respuesta = db.GetAll().Result;
            var lista = (List<juego>)respuesta;

            return View(lista);
        }
        public ActionResult JuegosSorted()
        {
            var respuesta = db.GetSortedGames().Result;
            var lista = (List<juego>)respuesta;
            return View(lista);
        }
        public ActionResult NuevoJuego()
        {
            var resp = dbCategoria.GetAll();
            if (resp.IsSuccess)
            {
                ViewBag.Categorias = (List<categoria>)resp.Result;
            }
            return View();
        }
        [HttpPost]
        public ActionResult NuevoJuego(localJuego item)
        {
            
            string fileName = Path.GetFileNameWithoutExtension(item.ImageFile.FileName);
            string extension = Path.GetExtension(item.ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssffff") + extension;
            item.imageGame = "~/Images/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Images/"), fileName);
            item.ImageFile.SaveAs(fileName);
            juego juego = new juego
            {
                imagen = item.imageGame,
                nomJuego = item.nomJuego,
                existencias = item.existencias,
                precio = item.precio,
                categoria = item.categoria,
                idcategoria=item.idcategoria
                
            };
            var resp = db.Post(juego);
            if (!resp.IsSuccess)
            {
                return View();
            }
            else
            {
                return Redirect("~/juegos");
            }
        }
        public ActionResult Editar(int id)
        {
            var item = (juego)db.GetById(id).Result;
            ViewBag.LastPic = item.imagen;
            var resp = dbCategoria.GetAll();
            if (resp.IsSuccess)
            {
                ViewBag.CategoriasEditar = (List<categoria>)resp.Result;
            }
            localJuego item2 = new localJuego
            {
                idJuego = id,
                nomJuego = item.nomJuego,
                existencias = (int)item.existencias
                
            };
            return View(item2);
        }
        [HttpPost]
        public ActionResult Editar(localJuego item)
        {
            if (item.ImageFile != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(item.ImageFile.FileName);
                string extension = Path.GetExtension(item.ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssffff") + extension;
                item.imageGame = "~/Images/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Images/"), fileName);
                item.ImageFile.SaveAs(fileName);
                juego juego = new juego
                {
                    imagen = item.imageGame,
                    nomJuego = item.nomJuego,
                    existencias = item.existencias,
                    precio = item.precio,
                    categoria = item.categoria,
                    idcategoria = (int)item.idcategoria
                };
                var resp = db.Update(juego, item.idJuego);
                if (!resp.IsSuccess)
                {
                    return View();
                }
                else
                {
                    return Redirect("~/juegos");
                }
            }
            else
            {
                var item2 = db.GetById(item.idJuego);
                var jue = (juego)item2.Result;
                jue.nomJuego = item.nomJuego;
                jue.precio = item.precio;
                jue.existencias = item.existencias;
                jue.idcategoria = item.idcategoria;
                var resp = db.Update(jue, item.idJuego);
                if (!resp.IsSuccess)
                {
                    return View();
                }
                else
                {
                    return Redirect("~/juegos");
                }
            }
        }
        [HttpGet]
        public ActionResult Eliminar(int id)
        {
            var resp = db.Delete(id);
            return Redirect("~/juegos");
        }
    }
}