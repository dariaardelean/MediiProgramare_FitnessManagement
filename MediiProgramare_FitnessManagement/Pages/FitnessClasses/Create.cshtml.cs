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
using System.Data;

namespace MediiProgramare_FitnessManagement.Pages.FitnessClasses
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : PageModel
    {
        private readonly MediiProgramare_FitnessManagement.Data.MediiProgramare_FitnessManagementContext _context;

        public CreateModel(MediiProgramare_FitnessManagement.Data.MediiProgramare_FitnessManagementContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ClassTypeID"] = new SelectList(_context.ClassType, "ID", "TypeName");
        ViewData["GymID"] = new SelectList(_context.Gym, "ID", "Name");
        ViewData["TrainerID"] = new SelectList(_context.Trainer, "ID", "LastName");
            return Page();
        }

        [BindProperty]
        public FitnessClass FitnessClass { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                
                ViewData["ClassTypeID"] = new SelectList(_context.ClassType, "ID", "TypeName");
                ViewData["GymID"] = new SelectList(_context.Gym, "ID", "Name");
                ViewData["TrainerID"] = new SelectList(_context.Trainer, "ID", "LastName");

                return Page();
            }


            _context.FitnessClasses.Add(FitnessClass);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
