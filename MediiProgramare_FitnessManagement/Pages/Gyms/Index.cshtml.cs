using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MediiProgramare_FitnessManagement.Data;
using MediiProgramare_FitnessManagement.Models;
using MediiProgramare_FitnessManagement.Models.ViewModels;

namespace MediiProgramare_FitnessManagement.Pages.Gyms
{
    public class IndexModel : PageModel
    {
        private readonly MediiProgramare_FitnessManagement.Data.MediiProgramare_FitnessManagementContext _context;

        public IndexModel(MediiProgramare_FitnessManagement.Data.MediiProgramare_FitnessManagementContext context)
        {
            _context = context;
        }

        public GymIndexData GymData { get; set; }

        public async Task OnGetAsync(int? id)
        {
            GymData = new GymIndexData
            {
                Gyms = await _context.Gym
                    .Include(g => g.FitnessClasses)
                    .ToListAsync()
            };

            if (id != null)
            {
                GymData.FitnessClasses = GymData.Gyms
                    .Single(g => g.ID == id)
                    .FitnessClasses;
            }
        }
    }
}
