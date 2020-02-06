using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using voLAWNteer.Data;
using voLAWNteer.Models;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace voLAWNteer.Controllers
{
    public class ServicesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ServicesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            //inject the UserManager service
            _userManager = userManager;
        }

        //method that needs to see who the user is
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        // GET: Services
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Service.Include(s => s.Lawn);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Services/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Services/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Service service, [FromRoute] int id )
        {
            var user = await GetCurrentUserAsync();

            if (ModelState.IsValid)
            {
                //create new service entry for the given LawnId FK
                service.LawnId = id;
                //tell entity that the PK is 0
                service.Id = 0;
                //give the entry created time
                service.ListingCreated = DateTime.Now;
                _context.Add(service);
                await _context.SaveChangesAsync();
                //if authorized, return to pending, if not authorized, return to queue*******
                if (user != null)
                {
                    return RedirectToAction("Index", "Pendings");
                }
                else
                {
                    return RedirectToAction("Index", "Lawns");
                }
            }
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
            return View(service);
        }

        // POST: Services/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Service service)
        {
            if (id != service.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //give a completed date
                    service.CompletedDate = DateTime.Now;
                    _context.Update(service);
                    await _context.SaveChangesAsync();

                    
                    //text message for this method
                    ////////
                    SMSInformation twilio = new SMSInformation();

                    string accountSid = twilio.accountSID;
                    string authToken = twilio.accountToken;

                    TwilioClient.Init(accountSid, authToken);

                    var message = MessageResource.Create(
                        body: $"Your lawn has a voLAWNteer, and they will be coming soon to mow your lawn!",
                        from: new Twilio.Types.PhoneNumber(twilio.twilioPhone),
                        to: new Twilio.Types.PhoneNumber(twilio.customerPhone));
                    /////////
                    
                    


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
                //send user to create new service listing and send the FK with it
                return RedirectToAction("Create", "Services", new { id = service.LawnId });
            }
            return View(service);
        }

        private bool ServiceExists(int id)
        {
            return _context.Service.Any(e => e.Id == id);
        }
    }
}
