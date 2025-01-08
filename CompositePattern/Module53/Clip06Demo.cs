using System;
using System.Linq;
using CompositePattern.Module53;

namespace Demo.Clip06
{
    class Clip06Demo : CompositePattern.Common.Demo
    {
        private void Display(string title, Name author, Volume volumes)
        {
            try
            {
                Book book = new Book(title, author, volumes);
                Console.WriteLine();
                Console.WriteLine(book);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR: {ex.Message}");
            }
        }

        private void Display(string title, Name author) =>
            Display(title, author, Volume.Create(("1", "Title")));

        private void Display(INameFactory nameFactory)
        {
            this.Display("The Lord of the Rings", nameFactory.Create("John Tolkien"), 
                Volume.Create(
                    ("I", "First"),
                    ("II", "Second"),
                    ("III", "Third")));
            this.Display("Object-Oriented Software Construction", nameFactory.Create("Bertrand Meyer"));
            this.Display("Design Patterns", nameFactory.Create(
                "Erich Gamma", "Richard Helm", "Ralph Johnson", "John Vlissides"));
            this.Display("The Art of Computer Programming", nameFactory.Create("Donald Knuth"),
                Volume.Create(
                    ("1", "Begginer"),
                    ("2", "Mid"),
                    ("3", "Advanced")));
        }

        protected override void Implementation()
        {
            this.Display(new CommonNames());
        }
    }
}