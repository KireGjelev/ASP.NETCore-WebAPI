using Class03.Homework.Models;

namespace Class03.Homework
{
    public static class StaticDb
    {
        public static List<Book> Books = new List<Book>()
        {
            new Book
            {
                Id = 1,
                Title = "Clean Code",
                Author = "Robert Cecil Martin"
            },
            new Book
            {
                Id = 2,
                Title = "Clean Architecture",
                Author = "Robert Cecil Martin"
            },
            new Book
            {
                Id = 3,
                Title = "Data Engineering with Python",
                Author = "Paul Crickard"
            },
            new Book
            {
                Id = 4,
                Title = "The Mythical Man-Month",
                Author = "Frederick Phillips Brooks Jr."
            }
        };
    }
}
