using System;
using System.Collections.Generic;
using System.Linq;
using Demo.Clip01;

namespace ComplexBuilder.ComplexBuilders
{
    class Clip01Demo : ComplexBuilder.Common.Demo
    {
        protected override void Implementation()
        {
            var repo = new Repository();
            Console.WriteLine("Categories:");
            repo.Categories.ToList().ForEach(tuple => Console.WriteLine(tuple));
            Console.WriteLine("---");
            Console.WriteLine("Books:");
            repo.Books.ToList().ForEach(tuple => Console.WriteLine(tuple));
            
            IEnumerable<Book> books = new BooksBuilder()
                .WithCategories(repo.Categories)
                .WitBooks(repo.Books)
                .Build();
            
            books.ToList().ForEach(Console.WriteLine);
        }
    }
}