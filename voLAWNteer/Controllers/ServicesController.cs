﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using voLAWNteer.Data;
using voLAWNteer.Models;

namespace voLAWNteer.Controllers
{
    public class ServicesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ServicesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Services
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Service.Include(s => s.Lawn);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Services/Create
        public IActionResult Create()
        {
            ViewData["LawnId"] = new SelectList(_context.Lawn, "Id", "City");
            return View();
        }

        // POST: Services/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Service service, [FromRoute] int id )
        {
            if (ModelState.IsValid)
            {
                service.LawnId = id;
                service.Id = 0;
                service.ListingCreated = DateTime.Now;
                _context.Add(service);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index","Pendings");
            }
            ViewData["LawnId"] = new SelectList(_context.Lawn, "Id", "City", service.LawnId);
            return View(service);
        }

        // GET: Services/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var service = await _context.Service.FindAsync(id);
            if (service == null)
            {
                return NotFound();
            }
            ViewData["LawnId"] = new SelectList(_context.Lawn, "Id", "City", service.LawnId);
            return View(service);
        }

        // POST: Services/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CompletedDate,ListingCreated,LawnId")] Service service)
        {
            if (id != service.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(service);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServiceExists(service.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["LawnId"] = new SelectList(_context.Lawn, "Id", "City", service.LawnId);
            return View(service);
        }

        private bool ServiceExists(int id)
        {
            return _context.Service.Any(e => e.Id == id);
        }
    }
}
