using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Webseguro.Data;
using Webseguro.Models;

namespace Webseguro.Controllers
{
    public class GenerosController : Controller
    {
        private readonly ApplicationDbContext _context; 
        // GET: GenerosController
        public ActionResult Index()
        {
            List<Genero> ltsgenero = _context.Generos.ToList();
            return View(ltsgenero);
        }
         
        // GET: GenerosController/Details/5
        public ActionResult Details(int id)
        {
            Genero genero = _context.Generos.FirstOrDefault(x=>x.Codigo == id);
            return View(genero);
        }

        // GET: GenerosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GenerosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Genero genero)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(genero);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(genero);
            }
        }

        // GET: GenerosController/Edit/5
        public ActionResult Edit(int id)
        {
            Genero genero = _context.Generos.FirstOrDefault(x => x.Codigo == id);
            return View(genero);
        }

        // POST: GenerosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Genero genero)
        {
            if (id != genero.Codigo)
            {
                return RedirectToAction("Index");
            }
            try
            {
                _context.Update(genero);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(genero);
            }
        }

        // GET: GenerosController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: GenerosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
