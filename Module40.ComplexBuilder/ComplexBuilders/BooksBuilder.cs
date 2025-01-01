using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using Demo.Clip01;

namespace ComplexBuilder.ComplexBuilders;

public class BooksBuilder
{
    private IEnumerable<(int id, string title, int categoryId)> BookRecords { get; set; }
        = Enumerable.Empty<(int, string, int)>();

    public BooksBuilder WitBooks(IEnumerable<(int id, string title, int categoryId)> rows)
    {
        BookRecords = rows.ToList();
        return this;
    }

    private IDictionary<int, (int id, string name, int? paretnId)> CategoryRecords { get; set; }
        = new Dictionary<int, (int id, string name, int? categoryId)>();

    private IDictionary<int, Category> Categories { get; } = new Dictionary<int, Category>();

    public BooksBuilder WithCategories(IEnumerable<(int id, string name, int? parentId)> repoCategories)
    {
        CategoryRecords = repoCategories.ToDictionary(row => row.id);
        return this;
    }


    public IEnumerable<Book> Build() => BookRecords.Select(row => new Book(row.id, row.title, GetCategory(row.categoryId)));

    private Category GetCategory(int id) => Categories.TryGetValue(id, out var category) ? category : CreateCategory(id);

    private Category CreateCategory(int id)
    {
            (int _, string name, int? paretnId) = CategoryRecords[id];
            var result = paretnId.HasValue ? GetCategory(paretnId.Value).Subcategory(id, name) :
                   Category.CreateRoot(id, name);
            Categories[id] = result;
            return result;
    }
}