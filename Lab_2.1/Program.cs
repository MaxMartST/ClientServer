using Lab_2._1;
using Microsoft.Extensions.Configuration;

namespace Lab_2._1 
{
    internal class Program
    {
        internal static IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

        static void Main(string[] args)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();

                db.Courses.AddRange(
                    new Course { Title = "C# Language", Duration = 40, Description = "C# Language" },
                    new Course { Title = ".Net Client-Server", Duration = 40, Description = "Creating client server for .NET using C#" },
                    new Course { Title = "Pattern", Duration = 24, Description = "OOP Pattern" },
                    new Course { Title = "JavaScript", Duration = 24, Description = "JavaScript for web developers" }
                    );
                db.SaveChanges();
            }
            using (ApplicationContext db = new ApplicationContext())
            {
                var courses = db.Courses.ToList();
                Console.WriteLine("Courses list:");
                foreach (Course c in courses)
                    Console.WriteLine($"{c.Id}.{c.Title} - {c.Duration} - {c.Description}");

            }
        }
    }
}
