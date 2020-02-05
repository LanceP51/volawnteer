using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using voLAWNteer.Data;
using voLAWNteer.Models;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace voLAWNteer.Controllers
{
    public class PendingsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public PendingsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            //inject the UserManager service
            _userManager = userManager;
            _context = context;
        }

        //method that needs to see who the user is
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        // GET: Pendings
        [Authorize]
        public async Task<IActionResult> Index()
        {
            //get new lawn requests where approved bool is still null
            var applicationDbContext = _context.Lawn.Where(i => i.Approved == null);
            return View(await applicationDbContext.ToListAsync());

        }

        // GET: Pendings/Details/5
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


        // GET: Pendings/Edit/5
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

        // POST: Pendings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Phone, StreetAddress,City,State,ZipCode,Size,Description,Approved,Photo")] Lawn lawn)
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
                //if lawn is approved, then send a text and send user to create the first service entry, otherwise store it as denied and do nothing with it
                if (lawn.Approved == true)
                {

                    /*
                    //text message for this method
                    ////////
                    SMSInformation twilio = new SMSInformation();

                    string accountSid = twilio.accountSID;
                    string authToken = twilio.accountToken;

                    TwilioClient.Init(accountSid, authToken);

                    var message = MessageResource.Create(
                        body: $"Hi, {lawn.FirstName}, your lawn at {lawn.StreetAddress} has been approved, and it will be added to the queue for mowing.",
                        from: new Twilio.Types.PhoneNumber(twilio.twilioPhone),
                        to: new Twilio.Types.PhoneNumber(twilio.customerPhone));
                    /////////
                    */



                    return RedirectToAction("Create", "Services", new { id = lawn.Id }); }
                else { return RedirectToAction(nameof(Index)); }
            }
            return View(lawn);
        }


        // lawn exist?
        private bool LawnExists(int id)
        {
            return _context.Lawn.Any(e => e.Id == id);
        }
    }
}
