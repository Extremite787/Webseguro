using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Webseguro.Data;
using Webseguro.Models;

namespace Webseguro.Controllers
{
    [Authorize]
    public class Personas1Controller : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;

        
        public Personas1Controller(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        [Authorize(Roles = "Dios","Humano")]
        public IActionResult Index()
        {
            List<Persona> personas = new List<Persona>();
            personas = _applicationDbContext.Persona.ToList();
            return View(personas);
        }
        [Authorize(Roles = "Dios","Humano")]
        public IActionResult Details(int Codigo)
        {
            if (Codigo == 0)

                return RedirectToAction("Index");
            Persona persona = _applicationDbContext.Persona.Where(x => x.Codigo == Codigo).FirstOrDefault();
            if (persona == null)
                return RedirectToAction("Index");
            return View(persona);
        }
        [Authorize(Roles = "Dios")]
        public IActionResult Create()
        {
            return View();
        }
        [Authorize(Roles = "Dios")]
        [HttpPost]
        public IActionResult Create(Persona persona)
        {
            try
            {
                _applicationDbContext.Add(persona);
                _applicationDbContext.SaveChanges();
            }
            catch (Exception)
            {

                return View(persona);
            }

            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Dios")]
        public IActionResult Edit(int id)
        {
            if (id == 0)
            {
                return RedirectToAction("Index");
            }

            Persona persona = _applicationDbContext.Persona.Where(x => x.Codigo == id).FirstOrDefault();
            if (persona == null)

                return RedirectToAction("Index");

            return View(persona);
        }
        [Authorize(Roles = "Dios")]
        [HttpPost]
        public IActionResult Edit(int id, Persona persona)
        {
            if (id != persona.Codigo)
                return RedirectToAction("Index");
            try
            {
                _applicationDbContext.Update(persona);
                _applicationDbContext.SaveChanges();
            }
            catch (Exception)
            {

                return View(persona);
            }

            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Dios")]
        public IActionResult Delete(int id)
        {
            if (id == 0)
                return RedirectToAction("Index");
            Persona persona = _applicationDbContext.Persona.Where(x => x.Codigo == id).FirstOrDefault();
            try
            {
                _applicationDbContext.Remove(persona);
                _applicationDbContext.SaveChanges();
            }
            catch (Exception)
            {

                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
    }
}
