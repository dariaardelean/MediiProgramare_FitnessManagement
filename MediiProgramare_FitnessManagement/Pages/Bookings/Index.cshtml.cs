using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MediiProgramare_FitnessManagement.Data;
using MediiProgramare_FitnessManagement.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace MediiProgramare_FitnessManagement.Pages.Bookings
{
   
    public class IndexModel : PageModel
    {
        private readonly MediiProgramare_FitnessManagement.Data.MediiProgramare_FitnessManagementContext _context;

        public IndexModel(MediiProgramare_FitnessManagement.Data.MediiProgramare_FitnessManagementContext context)
        {
            _context = context;
        }

        public IList<Booking> Booking { get;set; } = default!;

        public async Task OnGetAsync()
        {
            IQueryable<Booking> bookingsQuery = _context.Booking
        .Include(b => b.FitnessClass)
        .Include(b => b.Member);

            // daca NU este admin → doar booking-urile lui
            if (!User.IsInRole("Admin"))
            {
                var userEmail = User.Identity.Name;

                bookingsQuery = bookingsQuery
                    .Where(b => b.Member.Email == userEmail);
            }

            Booking = await bookingsQuery.ToListAsync();
        }
    }
}
