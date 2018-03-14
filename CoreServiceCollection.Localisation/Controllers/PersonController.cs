using System;
using System.Linq;
using CoreServiceCollection.Localisation.Models;
using CoreServiceCollection.Localisation.Services;
using Microsoft.AspNetCore.Mvc;

namespace CoreServiceCollection.Localisation.Controllers
{
    public class PersonController : Controller
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        // GET: Person
        public ActionResult Index()
        {
            var persons = _personService.Persons;

            return View(persons);
        }

        // GET: Person/Details/5
        public ActionResult Details(Guid id)
        {
            var person = _personService.Persons.First(p => p.Id == id);
            return View(person);
        }

        // GET: Person/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Person/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PersonViewModel viewModel)
        {
            try
            {
                viewModel.Id = Guid.NewGuid();
                _personService.Persons.Add(viewModel);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Person/Edit/5
        public ActionResult Edit(Guid id)
        {
            var person = _personService.Persons.First(p => p.Id == id);
            return View(person);
        }

        // POST: Person/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PersonViewModel viewModel)
        {
            try
            {
                var person = _personService.Persons.First(p => p.Id == viewModel.Id);
                _personService.Persons.Remove(person);

                _personService.Persons.Add(viewModel);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Person/Delete/5
        public ActionResult Delete(Guid id)
        {
            var person = _personService.Persons.First(p => p.Id == id);
            return View(person);
        }

        // POST: Person/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(PersonViewModel viewModel)
        {
            try
            {
                var person = _personService.Persons.First(p => p.Id == viewModel.Id);
                _personService.Persons.Remove(person);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}