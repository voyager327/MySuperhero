using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Superhero.Data;
using Superhero.Models;

namespace Superhero.Controllers
{
    public class SuperHeroController : Controller
    {
        // GET: SuperHero
        public ApplicationDbContext db; 
        public SuperHeroController(ApplicationDbContext db)
        {
            this.db = db;
        }
        public ActionResult Index()
        {
            var superheroes = db.SuperHeroes.ToList();

            return View(superheroes);
        }

        // GET: SuperHero/Details/5
        public ActionResult Details(int power)
        {
            var superheroes = db.SuperHeroes.Where(a => a.Id == power).SingleOrDefault();
            return View(superheroes);
        }

        // GET: SuperHero/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SuperHero/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SuperHero superhero)
        {
            try
            {
                // TODO: Add insert logic here
                db.SuperHeroes.Add(superhero);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SuperHero/Edit/5
        public ActionResult Edit(int id)
        {
            var superheroes = db.SuperHeroes.Where(e => e.Id == id).SingleOrDefault();
            return View(superheroes);

            //var rooms = db.Rooms.Where(e => e.AnimalId == animalId).SingleOrDefault();
            //return rooms;


            //var superheroes = db.SuperHeroes.ToList().FirstOrDefault();
            //db.SaveChanges();
            //return View();
        }

        // POST: SuperHero/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit(SuperHero superhero)
        {
            try
            {
                // TODO: Add update logic here
                db.SuperHeroes.Update(superhero);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SuperHero/Delete/5
        public ActionResult Delete( int id)
        {
            var superheroes = db.SuperHeroes.Where(f => f.Id == id).SingleOrDefault();
            return View(superheroes);

            //db.SuperHeroes.Remove(superhero);
            //db.SaveChanges();
            //return View();
        }

        // POST: SuperHero/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Remove(SuperHero superhero)
        {
            try
            {
                // TODO: Add delete logic here
                db.SuperHeroes.Remove(superhero);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

  //int id, IFormCollection collection
        