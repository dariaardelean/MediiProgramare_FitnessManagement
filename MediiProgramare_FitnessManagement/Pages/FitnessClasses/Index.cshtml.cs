using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MediiProgramare_FitnessManagement.Data;
using MediiProgramare_FitnessManagement.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MediiProgramare_FitnessManagement.Pages.FitnessClasses
{
    public class IndexModel : PageModel
    {
        private readonly MediiProgramare_FitnessManagement.Data.MediiProgramare_FitnessManagementContext _context;

        public IndexModel(MediiProgramare_FitnessManagement.Data.MediiProgramare_FitnessManagementContext context)
        {
            _context = context;
        }

        public IList<FitnessClass> FitnessClass { get;set; } = default!;

        public async Task OnGetAsync(int? classTypeId)
        {
            IQueryable<FitnessClass> classesQuery = _context.FitnessClasses
        .Include(f => f.ClassType)
        .Include(f => f.Gym)
        .Include(f => f.Trainer);

            if (classTypeId != null)
            {
                classesQuery = classesQuery
                    .Where(c => c.ClassTypeID == classTypeId);
            }

            FitnessClass = await classesQuery.ToListAsync();

            ViewData["ClassTypeID"] = new SelectList(
                _context.ClassType,
                "ID",
                "TypeName",
                classTypeId
            );
        }
    }
}
