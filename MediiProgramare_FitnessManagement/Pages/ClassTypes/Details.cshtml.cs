using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MediiProgramare_FitnessManagement.Data;
using MediiProgramare_FitnessManagement.Models;

namespace MediiProgramare_FitnessManagement.Pages.ClassTypes
{
    public class DetailsModel : PageModel
    {
        private readonly MediiProgramare_FitnessManagement.Data.MediiProgramare_FitnessManagementContext _context;

        public DetailsModel(MediiProgramare_FitnessManagement.Data.MediiProgramare_FitnessManagementContext context)
        {
            _context = context;
        }

      public ClassType ClassType { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ClassType == null)
            {
                return NotFound();
            }

            var classtype = await _context.ClassType.FirstOrDefaultAsync(m => m.ID == id);
            if (classtype == null)
            {
                return NotFound();
            }
            else 
            {
                ClassType = classtype;
            }
            return Page();
        }
    }
}
