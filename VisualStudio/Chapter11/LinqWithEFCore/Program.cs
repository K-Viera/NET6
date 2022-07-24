using LinqWithEFCore;
using Microsoft.EntityFrameworkCore;
using static System.Console;

//FilterAndSort();
//WriteLine("filter with LINQ query comprehension syntax");
//FilterAndSortWithQuerySyn();

//WriteLine("join categories");
//WriteLine();
//JoinCategoriesAndProduct();
//JoinWithQuerySyn();

WriteLine("group join categories");
WriteLine();
GroupJoinCategoriesAndProducts();
WriteLine();
GroupJoinWithQuerySyn();

static void GroupJoinWithQuerySyn() {
    using (Northwind db = new())
    {
        var queryGroup = from c in db.Categories.AsEnumerable()
                         join p in db.Products on c.CategoryId equals p.CategoryId into pGroup
                         select new
                         {
                             c.CategoryName,
                             Products=pGroup
                         };
        var prueba = queryGroup.AsEnumerable();
        foreach (var category in prueba)
        {
            WriteLine("{0} has {1} products.",
              arg0: category.CategoryName,
              arg1: category.Products.Count());
            foreach (var product in category.Products)
            {
                WriteLine($" {product.ProductName}");
            }
        }

        //foreach (var category in queryGroup) { 
        //    WriteLine($"Category: {category.CategoryName}");
        //    foreach (var product in category.Products) {
        //        WriteLine(product);
        //    }
        //}
    }
}

static void GroupJoinCategoriesAndProducts()
{
    using (Northwind db = new())
    {
        // group all products by their category to return 8 matches
        var queryGroup = db.Categories.AsEnumerable().GroupJoin(
          inner: db.Products,
          outerKeySelector: category => category.CategoryId,
          innerKeySelector: product => product.CategoryId,
          resultSelector: (c, matchingProducts) => new
          {
              c.CategoryName,
              Products = matchingProducts.OrderBy(p => p.ProductName)
          });
        foreach (var category in queryGroup)
        {
            WriteLine("{0} has {1} products.",
              arg0: category.CategoryName,
              arg1: category.Products.Count());
            foreach (var product in category.Products)
            {
                WriteLine($" {product.ProductName}");
            }
        }
    }
}

static void JoinWithQuerySyn()
{
    using (Northwind db = new())
    {
        var join = from category in db.Categories
                   join product in db.Products on category.CategoryId equals product.CategoryId
                   select new { category.CategoryName, product.ProductName };
        foreach (var product in join)
        {
            WriteLine($"{product.ProductName},{product.CategoryName}");
        }
        WriteLine(join.Count());
    }
}

static void JoinCategoriesAndProduct()
{
    using (Northwind db = new())
    {
        // join evert product to its category to return 77 matches
        var queryJoin = db.Categories.Join(
            inner: db.Products,
            outerKeySelector: category => category.CategoryId,
            innerKeySelector: product => product.CategoryId,
            resultSelector: (c, p) => new { c.CategoryName, p.ProductName, p.ProductId }
            );
        foreach (var item in queryJoin)
        {
            WriteLine("{0}: {1} is in {2}.",
  arg0: item.ProductId,
  arg1: item.ProductName,
  arg2: item.CategoryName);
        }
            WriteLine(queryJoin.Count());
    }
}

static void FilterAndSort()
{
    using (Northwind db = new())
    {
        DbSet<Product> allProducts = db.Products;
        IQueryable<Product> filteredProducts =
          allProducts.Where(product => product.UnitPrice < 10M);
        IOrderedQueryable<Product> sortedAndFilteredProducts =
          filteredProducts.OrderByDescending(product => product.UnitPrice);
        var projectedProducts = sortedAndFilteredProducts
            .Select(product => new // anonymous type
            {
                product.ProductId,
                product.ProductName,
                product.UnitPrice
            });
        WriteLine("Products that cost less than $10:");
        foreach (var p in projectedProducts)
        {
            WriteLine("{0}: {1} costs {2:$#,##0.00}",
              p.ProductId, p.ProductName, p.UnitPrice);
        }
        WriteLine();
    }
}
static void FilterAndSortWithQuerySyn()
{
    using (Northwind db = new())
    {
        DbSet<Product> allProducts = db.Products;

        var filteredProducts =
            from product in allProducts
            where product.UnitPrice < 10M
            orderby product.UnitPrice descending
            select new { product.ProductId, product.ProductName, product.UnitPrice };

        WriteLine("Products that cost less than $10:");
        foreach (var p in filteredProducts)
        {
            WriteLine("{0}: {1} costs {2:$#,##0.00}",
              p.ProductId, p.ProductName, p.UnitPrice);
        }
        WriteLine();
    }
}