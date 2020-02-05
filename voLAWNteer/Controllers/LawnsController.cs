using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using voLAWNteer.Data;
using voLAWNteer.Models;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

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
            //only show in this view items that have been approved
            var applicationDbContext = _context.Lawn.Where(i => i.Approved == true)

                //connect Service table to these items and display dates in view
                .Include(s => s.Services)
                //order lists ascending (by date created and completedDate is null)
                .OrderBy(s => s.Services.FirstOrDefault(n => n.CompletedDate==null).ListingCreated);
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
            
            if (ModelState.IsValid)
            {
                _context.Add(lawn);
                await _context.SaveChangesAsync();



                //text message for this method
                ////////
                SMSInformation twilio = new SMSInformation();

                string accountSid = twilio.accountSID;
                string authToken = twilio.accountToken;

                TwilioClient.Init(accountSid, authToken);

                var message = MessageResource.Create(
                    body: $"Hi, {lawn.FirstName}, your lawn at {lawn.StreetAddress} has been requested, and you will be notified if it is approved.",
                    from: new Twilio.Types.PhoneNumber(twilio.twilioPhone),
                    to: new Twilio.Types.PhoneNumber(twilio.customerPhone));
                /////////
                    



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
        public async Task<IActionResult> Edit(int id, [Bind("Id, FirstName,LastName, Phone, StreetAddress,City,State,ZipCode,Size,Description,Photo")] Lawn lawn)
        {
            if (id != lawn.Id)
            {
                return NotFound();
            }
           
            if (ModelState.IsValid)
            {
                try
                {
                    //keep approved status on this lawn
                    lawn.Approved = true;
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
