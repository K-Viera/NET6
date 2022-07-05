using Microsoft.EntityFrameworkCore; // Include extension method
using Packt.Shared;
using static System.Console;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;


QueryingCategories();
//FilteredIncludes();
//QueryingProducts();

static void QueryingProducts()
{
    using (Northwind db = new())
    {
        WriteLine("Products that cost more than a price, highest at top.");
        string? input;
        decimal price;
        do
        {
            Write("Enter a product price: ");
            input = ReadLine();
        } while (!decimal.TryParse(input, out price));
        IQueryable<Product>? products = db.Products?
          .Where(product => product.Cost > price)
          .OrderByDescending(product => product.Cost);
        if (products is null)
        {
            WriteLine("No products found.");
            return;
        }
        WriteLine($"ToQueryString: {products.ToQueryString()}");
        foreach (Product p in products)
        {
            WriteLine(
              "{0}: {1} costs {2:$#,##0.00} and has {3} in stock.",
              p.ProductId, p.ProductName, p.Cost, p.Stock);
        }
    }
}
static void FilteredIncludes()
{
    using (Northwind db = new())
    {
        ILoggerFactory loggerFactory = db.GetService<ILoggerFactory>();
        loggerFactory.AddProvider(new ConsoleLoggerProvider());
        Write("Enter a minimum for units in stock: ");
        string unitsInStock = ReadLine() ?? "10";
        int stock = int.Parse(unitsInStock);
        IQueryable<Category>? categories = db.Categories?
          .Include(c => c.Products.Where(p => p.Stock >= stock));
        if (categories is null)
        {
            WriteLine("No categories found.");
            return;
        }
        foreach (Category c in categories)
        {
            WriteLine($"{c.CategoryName} has {c.Products.Count} products with a minimum of {stock} units in stock.");
            foreach (Product p in c.Products)
            {
                WriteLine($"  {p.ProductName} has {p.Stock} units in stock.");
            }
        }
    }
}

static void QueryingCategories()
{
    try
    {
        using (Northwind db = new())
        {
            //ILoggerFactory loggerFactory = db.GetService<ILoggerFactory>();
            //loggerFactory.AddProvider(new ConsoleLoggerProvider());
            Console.WriteLine("Categories and how many products they have:");
            // a query to get all categories and their related products
            IQueryable<Category>? categories = db.Categories;
              //.Include(c => c.Products);
            if (categories is null)
            {
                Console.WriteLine("No categories found.");
                return;
            }
            // execute query and enumerate results
            foreach (Category c in categories)
            {
                Console.WriteLine($"{c.CategoryName} has {c.Products.Count} products.");
            }
        }
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }
}
