//using FurnitureShop.Core.Contracts;
//using FurnitureShop.Data.Contexts;
//using FurnitureShop.Data.Seeders;
//using FurnitureShop.Services.Blogs;
//using FurnitureShop.WinApp;

//var context = new StoreDbContext();

//IStoreRepository storeRepo = new StoreRepository(context);

//var seeder = new DataSeeder(context);
//seeder.Initialize();

//var pagingParams = new PagingParams
//{
//    PageNumber = 1,
//    PageSize = 5,
//    SortColumn = "Name",
//    SortOrder = "DESC"
//};

//var producers = context.Producers.ToList();

//Console.WriteLine("{0,-4}{1,-30}{2,-30}",
//    "ID", "Name", "Notes");

//foreach (var producer in producers)
//{
//    Console.WriteLine("{0,-4}{1,-30}{2,-30}",
//        producer.Id, producer.Name, producer.Notes);
//}

//var products = await storeRepo.GetPopularProductsAsync(3);

////var products = context.Products
////    .OrderBy(p => p.Title)
////    .Select(p => new
////    {
////        Id = p.Id,
////        Title = p.Title,
////        ViewCount = p.ViewCount,
////        PostedDate = p.PostedDate,
////        Producer = p.Producer.Name,
////        Category = p.Category.Name,
////    })
////    .ToList();

//foreach (var product in products)
//{
//    Console.WriteLine("ID      : {0}", product.Id);
//    Console.WriteLine("Title   : {0}", product.Title);
//    Console.WriteLine("View    : {0}", product.ViewCount);
//    Console.WriteLine("Date    : {0:MM/dd/yyyy}", product.PostedDate);
//    Console.WriteLine("Producer  : {0}", product.Producer.Name);
//    Console.WriteLine("Category: {0}", product.Category.Name);
//    Console.WriteLine("".PadRight(80, '-'));
//}

//var categories = await storeRepo.GetCategoriesAsync();

//Console.WriteLine("{0,-5}{1,-50}{2,10}",
//    "ID", "Name", "Count");

//foreach (var item in categories)
//{
//    Console.WriteLine("{0,-5}{1,-50}{2,10}",
//        item.Id, item.Name, item.PostCount);
//}

//var tagsList = await storeRepo.GetPagedTagsAsync(pagingParams);

//Console.WriteLine("{0,-5}{1,-50}{2,10}",
//    "ID", "Name", "Count");

//foreach (var item in tagsList)
//{
//    Console.WriteLine("{0,-5}{1,-50}{2,10}",
//        item.Id, item.Name, item.ProductCount);
//}