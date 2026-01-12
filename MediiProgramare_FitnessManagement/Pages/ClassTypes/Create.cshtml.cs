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

namespace MediiProgramare_FitnessManagement.Pages.ClassTypes
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
            return Page();
        }

        [BindProperty]
        public ClassType ClassType { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            Console.WriteLine(">>> ON POST A FOST APELAT <<<");

            if (!ModelState.IsValid)
            {
                Console.WriteLine(">>> MODELSTATE INVALID <<<");
                return Page();
            }

            _context.ClassType.Add(ClassType);
            await _context.SaveChangesAsync();

            Console.WriteLine(">>> SALVAT CU SUCCES <<<");

            return RedirectToPage("./Index");
        }
    }
}
