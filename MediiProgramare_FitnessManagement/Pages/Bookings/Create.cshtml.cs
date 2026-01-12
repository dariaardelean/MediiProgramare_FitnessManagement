using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MediiProgramare_FitnessManagement.Data;
using MediiProgramare_FitnessManagement.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace MediiProgramare_FitnessManagement.Pages.Bookings
{
    public class CreateModel : PageModel
    {
        private readonly MediiProgramare_FitnessManagement.Data.MediiProgramare_FitnessManagementContext _context;

        public CreateModel(MediiProgramare_FitnessManagement.Data.MediiProgramare_FitnessManagementContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["FitnessClassID"] = new SelectList(_context.FitnessClasses, "ID", "ClassName");
        
            return Page();
        }

        [BindProperty]
        public Booking Booking { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            var userEmail = User.Identity?.Name;

            if (string.IsNullOrEmpty(userEmail))
            {
                ModelState.AddModelError("", "Trebuie să fii logat.");
                return Page();
            }

            var member = await _context.Member
                .FirstOrDefaultAsync(m => m.Email == userEmail);

            if (member == null)
            {
                ModelState.AddModelError("", "Nu există membru asociat contului.");
                return Page();
            }

            
            Booking.MemberID = member.ID;
            Booking.BookingDate = DateTime.Now;

            _context.Booking.Add(Booking);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
