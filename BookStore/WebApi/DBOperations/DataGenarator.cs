using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace WebApi.DBOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookStoreDbContext(
            serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {
            // Look for any book.
                if (context.Books.Any())
                {
                    return;   // Data was already seeded
                }

                context.Books.AddRange(
                    new Book{
                    Title = "Lean Startup",
                    GenreId = 1, //Personal Growth
                    PageCount = 200,
                    PublishDate = new DateTime(2001,06,12)
                    },
                    new Book{
                    Title = "Herland",
                    GenreId = 2, // Science Fiction
                    PageCount = 250,
                    PublishDate = new DateTime(2010,05,23)
                    },
                    new Book{
                    Title = "Dune",
                    GenreId = 2, //Personal Growth
                    PageCount = 540,
                    PublishDate = new DateTime(2001,12,21)

                    }
                );
                context.SaveChanges();
            }
        }
    }
}   