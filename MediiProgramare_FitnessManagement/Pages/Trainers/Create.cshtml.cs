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

namespace MediiProgramare_FitnessManagement.Pages.Trainers
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
            ViewData["ClassTypes"] = _context.ClassType.ToList();
            return Page();
        }

        [BindProperty]
        public Trainer Trainer { get; set; } = default!;

        [BindProperty]
        public List<int> SelectedClassTypes { get; set; } = new List<int>();


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                ViewData["ClassTypes"] = _context.ClassType.ToList();
                return Page();
            }

            _context.Trainer.Add(Trainer);
            await _context.SaveChangesAsync();

            foreach (var classTypeId in SelectedClassTypes)
            {
                _context.TrainerClassType.Add(new TrainerClassType
                {
                    TrainerID = Trainer.ID,
                    ClassTypeID = classTypeId
                });
            }

            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
