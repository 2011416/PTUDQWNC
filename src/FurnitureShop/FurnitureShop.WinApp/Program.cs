using FurnitureShop.Data.Contexts;
using FurnitureShop.Data.Seeders;

var context = new BlogDbContext();

var seeder = new DataSeeder(context);

seeder.Initialize();

var producers = context.Producers.ToList();

Console.WriteLine("{0,-4}{1,-30}{2,-30}",
    "ID", "Name", "Notes");

foreach (var producer in producers)
{
    Console.WriteLine("{0,-4}{1,-30}{2,-30}",
        producer.Id, producer.Name, producer.Notes);
}

var products = context.Products
    .OrderBy(p => p.Title)
    .Select(p => new
    {
        Id = p.Id,
        Title = p.Title,
        ViewCount = p.ViewCount,
        PostedDate = p.PostedDate,
        Producer = p.Producer.Name,
        Category = p.Category.Name,
    })
    .ToList();

foreach (var product in products)
{
    Console.WriteLine("ID      : {0}", product.Id);
    Console.WriteLine("Title   : {0}", product.Title);
    Console.WriteLine("View    : {0}", product.ViewCount);
    Console.WriteLine("Date    : {0:MM/dd/yyyy}", product.PostedDate);
    Console.WriteLine("Producer  : {0}", product.Producer);
    Console.WriteLine("Category: {0}", product.Category);
    Console.WriteLine("".PadRight(80, '-'));
}