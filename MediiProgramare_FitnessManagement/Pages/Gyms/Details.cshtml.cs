using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MediiProgramare_FitnessManagement.Data;
using MediiProgramare_FitnessManagement.Models;

namespace MediiProgramare_FitnessManagement.Pages.Gyms
{
    public class DetailsModel : PageModel
    {
        private readonly MediiProgramare_FitnessManagement.Data.MediiProgramare_FitnessManagementContext _context;

        public DetailsModel(MediiProgramare_FitnessManagement.Data.MediiProgramare_FitnessManagementContext context)
        {
            _context = context;
        }

      public Gym Gym { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Gym == null)
            {
                return NotFound();
            }

            var gym = await _context.Gym
             .Include(g => g.FitnessClasses)
              .ThenInclude(fc => fc.Trainer)
             .Include(g => g.FitnessClasses)
               .ThenInclude(fc => fc.ClassType)
              .FirstOrDefaultAsync(m => m.ID == id);
            if (gym == null)
            {
                return NotFound();
            }
            else 
            {
                Gym = gym;
            }
            return Page();
        }
    }
}
