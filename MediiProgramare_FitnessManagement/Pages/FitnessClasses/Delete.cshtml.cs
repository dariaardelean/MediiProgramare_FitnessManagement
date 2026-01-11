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

namespace MediiProgramare_FitnessManagement.Pages.FitnessClasses
{
    [Authorize(Roles = "Admin")]
    public class DeleteModel : PageModel
    {
        private readonly MediiProgramare_FitnessManagement.Data.MediiProgramare_FitnessManagementContext _context;

        public DeleteModel(MediiProgramare_FitnessManagement.Data.MediiProgramare_FitnessManagementContext context)
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

            var fitnessclass = await _context.FitnessClasses.FirstOrDefaultAsync(m => m.ID == id);

            if (fitnessclass == null)
            {
                return NotFound();
            }
            else 
            {
                FitnessClass = fitnessclass;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.FitnessClasses == null)
            {
                return NotFound();
            }
            var fitnessclass = await _context.FitnessClasses.FindAsync(id);

            if (fitnessclass != null)
            {
                FitnessClass = fitnessclass;
                _context.FitnessClasses.Remove(FitnessClass);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
