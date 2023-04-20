using FurnitureShop.Core.Entities;
using FurnitureShop.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureShop.Data.Seeders
{
    public class DataSeeder : IDataSeeder
    {
        private readonly BlogDbContext _dbContext;

        public DataSeeder(BlogDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Initialize()
        {
            _dbContext.Database.EnsureCreated();

            if (_dbContext.Products.Any()) return;

            var producers = AddProducers();
            var categories = AddCategories();
            var tags = AddTags();
            var products = AddProducts(producers, categories, tags);
        }

        private IList<Producer> AddProducers()
        {
            var producers = new List<Producer>()
            {
                new()
                {
                    Name ="Nội Thất An Cường",
                    UrlSlug ="an-cuong",
                    Notes ="ancuongfur@gmail.com"
                },
                new()
                {
                    Name ="Nội thất BMD",
                    UrlSlug ="bmd",
                    Notes ="bmdfur@gmotip.com",
                },
                  new()
                {
                    Name ="Nội thất Hòa Phát",
                    UrlSlug ="hoa-phat",
                    Notes ="hoaphat@gmotip.com",
                },
                    new()
                {
                    Name ="Nội thất Xuân Hòa",
                    UrlSlug ="xuan-hoa",
                    Notes ="xuanhoa@gmail.com",
                },
                    new()
                {
                    Name ="Nội thất Miền Nam",
                    UrlSlug ="mien-nam",
                    Notes ="miennamfurniture@gmail.com",
                },
                    new()
                {
                    Name ="Nội thất PPH",
                    UrlSlug ="pph",
                    Notes ="pphfurniture@gmail.com",
                }
            };

            _dbContext.Producers.AddRange(producers);
            _dbContext.SaveChanges();

            return producers;
        }

        private IList<Category> AddCategories()
        {
            var categories = new List<Category>()
            {
                new() {Name ="Bàn", Description ="Các loại bàn", UrlSlug ="ban"},
                new() {Name = "Ghế", Description = "Các loại ghế", UrlSlug = "ghe"},
                new() {Name = "Tủ", Description = "Các loại tủ", UrlSlug = "tu"},
                new() {Name ="Giường", Description ="Các loại giường", UrlSlug ="giuong"},
                new() {Name ="Hàng trang trí khác", Description ="Các loại hàng trang trí", UrlSlug ="hang-trang-tri-khac"}
            };

            _dbContext.AddRange(categories);
            _dbContext.SaveChanges();

            return categories;
        }

        private IList<Tag> AddTags()
        {
            var tags = new List<Tag>()
            {
                new() {Name ="Phòng ngủ", Description ="Vật dụng phòng ngủ", UrlSlug ="phong-ngu"},
                new() {Name = "Phòng khách", Description = "Vật dụng phòng khách", UrlSlug = "phong-khach"},
                new() {Name = "Phòng làm việc", Description = "Vật dụng phòng làm việc", UrlSlug = "phong-lam-viec"},
                new() {Name ="Phòng ăn", Description ="Vật dụng phòng ăn", UrlSlug ="phong-an"},
                new() {Name ="Hàng trang trí", Description ="Vật dụng trang trí", UrlSlug ="trang-tri"}
            };

            _dbContext.AddRange(tags);
            _dbContext.SaveChanges();

            return tags;
        }

        private IList<Product> AddProducts(
            IList<Producer> producers,
            IList<Category> categories,
            IList<Tag> tags)
        {
            var products = new List<Product>()
            {
                new()
                {
                    Title = "GHẾ SOFA DA 4 CHỖ NGỒI",
                    ShortDescription ="Ghế Sofa cao cấp",
                    Description ="Mẫu sofa da 4 chỗ ngồi SF305 có kiểu dáng phổ biến dễ dàng phù hợp với nhiều không gian nhà khác nhau",
                    Meta ="ghế sofa da 4 chỗ ngồi",
                    UrlSlug ="ghe-sofa-da-4-cho",
                    PostedDate = new DateTime(2021, 9, 30, 10, 20, 0),
                    ModifiedDate = new DateTime(2022, 7, 15, 9, 10, 0),
                    ViewCount = 10,
                    Producer = producers[0],
                    Category = categories[1],
                    Tags = new List<Tag>()
                    {
                        tags[1]
                    }
                },
                 new()
                {
                    Title = "BÀN TRÀ GỖ CAO SU",
                    ShortDescription ="Bàn trà gỗ cao su kiểu Nhật",
                    Description ="Bàn trà TT005 có kiểu dáng sang trọng bắt mắt, kết cấu được thiết kế vừa có tủ và hộc lưu trữ sẽ giúp người dùng tận dụng được tối đa không gian lưu trữ",
                    Meta ="bàn trà gỗ cao su",
                    UrlSlug ="ban-tra-go-cao-su",
                    PostedDate = new DateTime(2021, 4, 25, 8, 7, 1),
                    ModifiedDate = new DateTime(2022, 9, 18, 4, 5, 0),
                    ViewCount = 20,
                    Producer = producers[1],
                    Category = categories[0],
                    Tags = new List<Tag>()
                    {
                        tags[1]
                    }
                },
                   new()
                {
                    Title = "GIƯỜNG NGỦ GỖ",
                    ShortDescription ="Giường ngủ gỗ đèn LED ngăn kéo",
                    Description ="Mẫu giường ngủ được thiết kế thông minh bao gồm hộc tủ lưu trữ, đèn ngủ và cổng USB ở đầu giường là một trong những mẫu giường đất được ưa chuộng tại nội thất Hòa Phát",
                    Meta ="giường ngủ gỗ đèn LED",
                    UrlSlug ="giuong-ngu-go-den-led",
                    PostedDate = new DateTime(2020, 8, 29, 3, 4, 0),
                    ModifiedDate = new DateTime(2023, 2, 28, 8, 7, 1),
                    ViewCount = 14,
                    Producer = producers[2],
                    Category = categories[3],
                    Tags = new List<Tag>()
                    {
                        tags[0]
                    }
                },
                    new()
                {
                    Title = "TỦ TÀI LIỆU THẤP",
                    ShortDescription ="Tủ tài liệu đa dụng",
                    Description ="Tủ Tài Liệu Thấp TLT-01 là sản phẩm thường được sử dụng để đồ cá nhân, hồ sơ, tài liệu tại các văn phòng, cơ quan",
                    Meta ="tủ tài liệu thấp đa dụng",
                    UrlSlug ="tu-tai-lieu-thap",
                    PostedDate = new DateTime(2019, 6, 27, 5, 8, 1),
                    ModifiedDate = new DateTime(2023, 2, 28, 15, 7, 30),
                    ViewCount = 34,
                    Producer = producers[4],
                    Category = categories[2],
                    Tags = new List<Tag>()
                    {
                        tags[2]
                    }
                },

                     new()
                {
                    Title = "Bộ Bàn Ăn Mặt Đá",
                    ShortDescription ="Bộ Bàn Ăn Mặt Đá 6 Ghế Nhập Khẩu Cao Cấp",
                    Description ="mẫu bàn ăn mặt đá sang trọng. Mang đậm nét thiết kế của Bắc Âu",
                    Meta ="Bộ Bàn Ăn Mặt Đá 6 Ghế",
                    UrlSlug ="ban-an-6-ghe",
                    PostedDate = new DateTime(2021, 7, 8, 8, 16, 56),
                    ModifiedDate = new DateTime(2023, 2, 28, 23, 8, 40),
                    ViewCount = 34,
                    Producer = producers[5],
                    Category = categories[0],
                    Tags = new List<Tag>()
                    {
                        tags[3]
                    }
                }


            };


            _dbContext.AddRange(products);
            _dbContext.SaveChanges();

            return products;
        }
    }
}
