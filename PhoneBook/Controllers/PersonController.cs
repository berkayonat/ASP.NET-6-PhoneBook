using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.CQRS.Commands.CreatePerson;
using PhoneBook.CQRS.Commands.DeletePerson;
using PhoneBook.CQRS.Commands.UpdatePerson;
using PhoneBook.CQRS.Queries.GetAllPersons;
using PhoneBook.CQRS.Queries.GetPersonById;
using PhoneBook.CQRS.Queries.GetPersonsWithFilters;
using PhoneBook.Models;
using PhoneBook.Models.ViewModels;
using System.Collections.Generic;

namespace PhoneBook.Controllers
{
    public class PersonController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public PersonController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;

        }

        // GET: PersonController
        public async Task<IActionResult> Index(string filter)
        {
            if (!String.IsNullOrEmpty(filter))
            {
                var searchResult = await _mediator.Send(new GetPersonsWithFiltersQuery(filter));
                var result = _mapper.Map<IEnumerable<PersonViewModel>>(searchResult);
                return View(result);
            }

            var objPersonList = await _mediator.Send(new GetAllPersonsQuery());
            var model = _mapper.Map<IEnumerable<PersonViewModel>>(objPersonList);
            return View(model);
        }

        // GET: PersonController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var obj = await _mediator.Send(new GetPersonByIdQuery(id));
            if (obj == null)
            {
                return NotFound();
            }
            var model = _mapper.Map<PersonViewModel>(obj);

            return View(model);
        }

        // GET: PersonController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PersonController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PersonViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _mediator.Send(new CreatePersonCommand(model.Name, model.PhoneNumber, model.Email, model.Address));
                return RedirectToAction("index");
            }
            return View(model);
        }

        // GET: PersonController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var obj = await _mediator.Send(new GetPersonByIdQuery(id));
            if (obj == null)
            {
                return NotFound();
            }
            var model = _mapper.Map<PersonViewModel>(obj);

            return View(model);
        }

        // POST: PersonController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(PersonViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _mediator.Send(new UpdatePersonCommand(model.Id, model.Name, model.PhoneNumber, model.Email, model.Address));
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET
        public async Task<IActionResult> Delete(int id)
        {
            var entity = await _mediator.Send(new GetPersonByIdQuery(id));
            if (entity == null)
            {
                return NotFound();
            }
            await _mediator.Send(new DeletePersonCommand(id));
            return RedirectToAction(nameof(Index));
        }
    }
}
