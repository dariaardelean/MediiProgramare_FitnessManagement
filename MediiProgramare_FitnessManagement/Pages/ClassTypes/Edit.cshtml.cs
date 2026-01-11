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

namespace MediiProgramare_FitnessManagement.Pages.ClassTypes
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
        public ClassType ClassType { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ClassType == null)
            {
                return NotFound();
            }

            var classtype =  await _context.ClassType.FirstOrDefaultAsync(m => m.ID == id);
            if (classtype == null)
            {
                return NotFound();
            }
            ClassType = classtype;
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

            _context.Attach(ClassType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClassTypeExists(ClassType.ID))
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

        private bool ClassTypeExists(int id)
        {
          return (_context.ClassType?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
