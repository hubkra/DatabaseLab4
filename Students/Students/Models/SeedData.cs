using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Students.Data;
using Students.Models;
using System;
using System.Linq;

namespace MvcMovie.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new StudentsContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<StudentsContext>>()))
            {
                // Look for any movies.
                if (context.StudentsClass.Any())
                {
                    return;   // DB has been seeded
                }

                context.StudentsClass.AddRange(
                    new StudentsClass
                    {
                        Name = "Pawel",
                        Surname = "Baczek",
                        Birthday = DateTime.Parse("2000-2-12"),
                        Pesel = 992742783
                    },

                    new StudentsClass
                    {
                        Name = "Szymon",
                        Surname = "Teodor",
                        Birthday = DateTime.Parse("1998-4-16"),
                        Pesel = 193456128
                    },

                    new StudentsClass
                    {
                        Name = "Sylwia",
                        Surname = "Smaze",
                        Birthday = DateTime.Parse("1999-7-8"),
                        Pesel = 123456789
                    },

                    new StudentsClass
                    {
                        Name = "Edyta",
                        Surname = "Lubieser",
                        Birthday = DateTime.Parse("2000-8-23"),
                        Pesel = 762414920
                    }

                    );

                
                context.SaveChanges();
            }
        }
    }
}