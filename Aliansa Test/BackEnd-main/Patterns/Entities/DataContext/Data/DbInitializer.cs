using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Entities.DataContext.Data
{
    public static class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var _context = new AppDbContext(serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>()))
            {

                if (_context.Companies.Any())
                {
                    return;
                }

                _context.Companies.AddRange(
                    new Company { CompanyName = "Baseball Company" },
                    new Company { CompanyName = "Wood toys Company" },
                    new Company { CompanyName = "Mattel" }
                );

                _context.SaveChanges();

                if (_context.Toys.Any())
                {
                    return;
                }

                _context.Toys.AddRange(
                    new Toy
                    {
                        CompanyId = _context.Companies.FirstOrDefault(a => a.CompanyName.Equals("Baseball Company")).CompanyId,
                        ToyName = $"Bat",
                        Description = "Baseball bat",
                        AgeRestriction = 12,
                        Price = 100
                    },

                    new Toy
                    {
                        CompanyId = _context.Companies.FirstOrDefault(a => a.CompanyName.Equals("Wood toys Company")).CompanyId,
                        ToyName = $"Horse",
                        Description = "Wood horse",
                        AgeRestriction = 12,
                        Price = 90
                    },

                    new Toy
                    {
                        CompanyId = _context.Companies.FirstOrDefault(a => a.CompanyName.Equals("Mattel")).CompanyId,
                        ToyName = $"Guitar",
                        Description = "Wood Guitar",
                        AgeRestriction = 12,
                        Price = 200
                    }
                );

                _context.SaveChanges();
            }
        }
    }
}
