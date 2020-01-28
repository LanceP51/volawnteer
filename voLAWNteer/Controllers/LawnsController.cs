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
    public class LawnsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LawnsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Lawns
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Lawn.Where(i => i.Approved != null);
            return View(await applicationDbContext.ToListAsync());
            
        }

        // GET: Lawns/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lawn = await _context.Lawn
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lawn == null)
            {
                return NotFound();
            }

            return View(lawn);
        }

        // GET: Lawns/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Lawns/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Lawn lawn)
        {
            //ModelState.Remove("lawn.Approved");
            if (ModelState.IsValid)
            {
                _context.Add(lawn);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lawn);
        }

        // GET: Lawns/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lawn = await _context.Lawn.FindAsync(id);
            if (lawn == null)
            {
                return NotFound();
            }
            return View(lawn);
        }

        // POST: Lawns/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,StreetAddress,City,State,ZipCode,Size,Description,Photo")] Lawn lawn)
        {
            if (id != lawn.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lawn);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LawnExists(lawn.Id))
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
            return View(lawn);
        }

        // GET: Lawns/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lawn = await _context.Lawn
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lawn == null)
            {
                return NotFound();
            }

            return View(lawn);
        }

        // POST: Lawns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lawn = await _context.Lawn.FindAsync(id);
            _context.Lawn.Remove(lawn);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LawnExists(int id)
        {
            return _context.Lawn.Any(e => e.Id == id);
        }
    }
}
