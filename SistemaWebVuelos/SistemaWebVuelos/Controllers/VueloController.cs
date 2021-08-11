using SistemaWebVuelos.Datos;
using SistemaWebVuelos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaWebVuelos.Controllers
{
    public class VueloController : Controller
    {
        VuelosDBContext context = new VuelosDBContext();
        // GET: Vuelo
        public ActionResult Index()
        {
            var vuelos = context.Vuelos.ToList();
            return View(vuelos);
        }

        public ActionResult Create()
        {
            Vuelo vuelo = new Vuelo();
            return View("Create", vuelo);
        }

        [HttpPost]
        public ActionResult Create(Vuelo vuelo)
        {
            if (ModelState.IsValid)
            {
                context.Vuelos.Add(vuelo);
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("Create", vuelo);
        }

        public ActionResult Detail(string matricula)
        {
            var vuelo = (from v in context.Vuelos where v.Matricula == matricula select v).FirstOrDefault();

            if (vuelo != null)
            {
                return View("Detail", vuelo);
            }

            return HttpNotFound();
        }

        public ActionResult Delete(int id)
        {
            var vuelo = context.Vuelos.Find(id);

            if (vuelo != null)
            {
                return View(vuelo);
            }
            else
            {
                return HttpNotFound();
            }

        }

        [HttpPost]
        public ActionResult Delete(Vuelo vuelo)
        {
            context.Vuelos.Attach(vuelo);
            context.Vuelos.Remove(vuelo);
            context.SaveChanges();

            return RedirectToAction("Index");

        }

        public ActionResult Edit(int id)
        {
            var vuelo = context.Vuelos.Find(id);
            if (vuelo != null)
            {
                return View("Edit", vuelo);

            }
            else
            {
                return View(vuelo);
            }
        }
        [HttpPost]
        public ActionResult Edit(Vuelo vuelo)
        {
            if (vuelo != null)
            {
                context.Entry(vuelo).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");

            }
            else
            {
                return View(vuelo);
            }

        }

        public ActionResult TraerPorDestino(string destino)
        {
            var vuelos = (from v in context.Vuelos where v.Destino == destino select v).ToList();
            return View("Index", vuelos);
        }
    }
}