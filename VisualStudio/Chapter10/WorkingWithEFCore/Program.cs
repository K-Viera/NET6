﻿using Microsoft.EntityFrameworkCore; // Include extension method
using Packt.Shared;
using static System.Console;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage; // IDbContextTransaction

//QueryingCategories();
//FilteredIncludes();
//QueryingProducts();
//QueryingCategoriesWithExplicitLoad();

//if (AddProduct(categoryId: 6,
//  productName: "Bob's Burgers", price: 500M))
//{
//    WriteLine("Add product successful.");
//}
if (IncreaseProductPrice(
  productNameStartsWith: "Bob", amount: 20M))
{
    WriteLine("Update product price successful.");
}
ListProducts();


static int DeleteProducts(string name)
{
    using (Northwind db = new())
    {
        using (IDbContextTransaction t = db.Database.BeginTransaction())
        {
            WriteLine("Transaction isolation level: {0}",
              arg0: t.GetDbTransaction().IsolationLevel);
            IQueryable<Product>? products = db.Products?.Where(
              p => p.ProductName.StartsWith(name));
            if (products is null)
            {
                WriteLine("No products found to delete.");
                return 0;
            }
            else
            {
                db.Products.RemoveRange(products);
            }
            int affected = db.SaveChanges();
            t.Commit();
            return affected;
        }
    }
}

static bool IncreaseProductPrice(
  string productNameStartsWith, decimal amount)
{
    using (Northwind db = new())
    {
        // get first product whose name starts with name
        Product updateProduct = db.Products.First(
          p => p.ProductName.StartsWith(productNameStartsWith));
        updateProduct.Cost += amount;
        int affected = db.SaveChanges();
        return (affected == 1);
    }
}

static bool AddProduct(
  int categoryId, string productName, decimal? price)
{
    using (Northwind db = new())
    {
        Product p = new()
        {
            CategoryId = categoryId,
            ProductName = productName,
            Cost = price
        };
        // mark product as added in change tracking
        db.Products?.Add(p);
        // save tracked change to database
        int affected = db.SaveChanges();
        return (affected == 1);
    }
}

static void ListProducts()
{
    using (Northwind db = new())
    {
        WriteLine("{0,-3} {1,-35} {2,8} {3,5} {4}",
          "Id", "Product Name", "Cost", "Stock", "Disc.");
        foreach (Product p in db.Products
          .OrderByDescending(product => product.Cost))
        {
            WriteLine("{0:000} {1,-35} {2,8:$#,##0.00} {3,5} {4}",
              p.ProductId, p.ProductName, p.Cost, p.Stock, p.Discontinued);
        }
    }
}

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
static void QueryingCategoriesWithExplicitLoad() {
    using (Northwind db = new())
    {
        Console.WriteLine("Categories and how many products they have:");
        IQueryable<Category>? categories;

        db.ChangeTracker.LazyLoadingEnabled = false;
        Write("Enable eager loading? (Y/N): ");
        bool eagerloading = (ReadKey().Key == ConsoleKey.Y);
        bool explicitloading = false;
        WriteLine();
        if (eagerloading)
        {
            categories = db.Categories?.Include(c => c.Products);
        }
        else
        {
            categories = db.Categories;
            Write("Enable explicit loading? (Y/N): ");
            explicitloading = (ReadKey().Key == ConsoleKey.Y);
            WriteLine();
        }

        if (categories is null)
        {
            Console.WriteLine("No categories found.");
            return;
        }

        foreach (Category c in categories)
        {
            if (explicitloading)
            {
                Write($"Explicitly load products for {c.CategoryName}? (Y/N): ");
                ConsoleKeyInfo key = ReadKey();
                WriteLine();
                if (key.Key == ConsoleKey.Y)
                {
                    CollectionEntry<Category, Product> products =
                      db.Entry(c).Collection(c2 => c2.Products);
                    if (!products.IsLoaded) products.Load();
                }
            }
            Console.WriteLine($"{c.CategoryName} has {c.Products.Count} products.");
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
