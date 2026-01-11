using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MediiProgramare_FitnessManagement.Data;
using MediiProgramare_FitnessManagement.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace MediiProgramare_FitnessManagement.Pages.FitnessClasses
{
    [Authorize(Roles = "Admin")]
    public class EditModel : PageModel
    {
        private readonly MediiProgramare_FitnessManagement.Data.MediiProgramare_FitnessManagementContext _context;

        public EditModel(MediiProgramare_FitnessManagement.Data.MediiProgramare_FitnessManagementContext context)
        {
            _context = context;
        }

        [BindProperty]
        public FitnessClass FitnessClass { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.FitnessClasses == null)
            {
                return NotFound();
            }

            var fitnessclass =  await _context.FitnessClasses.FirstOrDefaultAsync(m => m.ID == id);
            if (fitnessclass == null)
            {
                return NotFound();
            }
            FitnessClass = fitnessclass;
           ViewData["ClassTypeID"] = new SelectList(_context.ClassType, "ID", "TypeName");
           ViewData["GymID"] = new SelectList(_context.Gym, "ID", "Name");
           ViewData["TrainerID"] = new SelectList(_context.Trainer, "ID", "LastName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(FitnessClass).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FitnessClassExists(FitnessClass.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool FitnessClassExists(int id)
        {
          return (_context.FitnessClasses?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
