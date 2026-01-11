using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MediiProgramare_FitnessManagement.Data;
using MediiProgramare_FitnessManagement.Models;

namespace MediiProgramare_FitnessManagement.Pages.Members
{
    public class DetailsModel : PageModel
    {
        private readonly MediiProgramare_FitnessManagement.Data.MediiProgramare_FitnessManagementContext _context;

        public DetailsModel(MediiProgramare_FitnessManagement.Data.MediiProgramare_FitnessManagementContext context)
        {
            _context = context;
        }

      public Member Member { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Member == null)
            {
                return NotFound();
            }

            var member = await _context.Member.FirstOrDefaultAsync(m => m.ID == id);
            if (member == null)
            {
                return NotFound();
            }
            else 
            {
                Member = member;
            }
            return Page();
        }
    }
}
