using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitnessManagement.MAUI.Models;

namespace FitnessManagement.MAUI.Services
{
    public class FitnessClassService
    {
        public async Task<List<FitnessClass>> GetFitnessClassesAsync()
        {
            // simulăm apel async
            await Task.Delay(500);

            return new List<FitnessClass>
            {
                new FitnessClass
                {
                    Name = "Pilates",
                    TrainerName = "Alina Popescu",
                    ScheduledDate = new DateTime(2016, 1, 15, 10, 30, 0)
                },
                new FitnessClass
                {
                    Name = "Yoga",
                    TrainerName = "Ana Ionescu",
                    ScheduledDate = new DateTime(2016, 1, 16, 18, 0, 0)
                },
                new FitnessClass
                {
                    Name = "Full Body Workout",
                    TrainerName = "Luca Maier",
                    ScheduledDate = new DateTime(2016, 1, 17, 9, 0, 0)
                }
            };
        }
    }
}
