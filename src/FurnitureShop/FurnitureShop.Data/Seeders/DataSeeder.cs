using FurnitureShop.Core.Entities;
using FurnitureShop.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Data;
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
            var categories = AddCategories();
            var roles = AddRoles();
            var users = AddUsers(roles);
            var products = AddProducts(users, categories);
            var deliveries = AddDeliveries(users);


        }
        private IList<Category> AddCategories()
        {

            var categories = new List<Category>() {
                new()
                {
                    Name= "Phòng khách",
                    UrlSlug="phong-khach",
                    Description="Để trang trí phòng khách",

                },
                 new()
                {
                    Name= "Sofa",
                    UrlSlug="sofa",
                    Description="Ghế sofa",

                },
                  new()
                {
                    Name= "Trang trí",
                    UrlSlug="trang-tri",
                    Description="Dùng để trang trí",

                },
                   new()
                {
                    Name= "Phòng ăn",
                    UrlSlug="phong-an",
                    Description="Để trang trí phòng ăn",

                },
                    new()
                {
                    Name= "Bàn ăn",
                    UrlSlug="ban-an",
                    Description="Bàn ăn ",

                },
                      new()
                {
                    Name= "Giường ngủ",
                    UrlSlug="giuong-ngu",
                    Description="Giường ngủ ",

                },
                       new()
                {
                    Name= "Phòng ngủ",
                    UrlSlug="phong-ngu",
                    Description="Phòng ngủ ",

                },





            };
            foreach (var category in categories)
            {
                if (!_dbContext.Categories.Any(a => a.UrlSlug == category.UrlSlug))
                {
                    _dbContext.Categories.Add(category);
                }
            }
            _dbContext.SaveChanges();
            return categories;

        }
        private IList<Role> AddRoles()
        {
            var roles = new List<Role>() {
                new()
                {
                    Name= "User",
                    UrlSlug= "user",
                    Description= "Tài khoản dành cho user",

                },
                 new()
                {
                    Name= "Admin",
                    UrlSlug= "admin",
                    Description= "Tài khoản dành cho admin",

                }
            };
            foreach (var role in roles)
            {
                if (!_dbContext.Roles.Any(a => a.UrlSlug == role.UrlSlug))
                {
                    _dbContext.Roles.Add(role);
                }
            }
            _dbContext.SaveChanges();
            return roles;

        }
        private IList<User> AddUsers(IList<Role> roles)
        {

            var users = new List<User>()
            {
                new()
                {
                    Name= "Amin",
                    UrlSlug= "amin",
                    Password= "123",
                    Adress= "Da Lat",
                    Role= roles[1],
                    Email= "admin@gmail.com",


                },
                 new()
                {
                    Name= "UserTest",
                    UrlSlug= "user-test",
                    Password= "123",
                    Adress= "Da Lat",
                    Role= roles[0],
                    Email= "usertest@gmail.com",
                    phoneNumber= "091111111"

                },
                  new()
                {
                    Name= "Hung",
                    UrlSlug= "hung",
                    Password= "123",
                    Adress= "Da Lat",
                    Role= roles[0],
                    Email= "hung@gmail.com",
                      phoneNumber= "091222222"
                },
                   new()
                {
                    Name= "Hoanh Anh",
                    UrlSlug= "hoanh-anh",
                    Password= "123",
                    Adress= "Da Lat",
                    Role= roles[1],
                    Email= "anh@gmail.com",
                      phoneNumber= "091333333"
                },
                    new()
                {
                    Name= "Nhan",
                    UrlSlug= "nhan",
                    Password= "123",
                    Adress= "Da Lat",
                    Role= roles[1],
                    Email= "nhan@gmail.com",
                      phoneNumber= "091444444"

                }


            };
            foreach (var user in users)
            {
                if (!_dbContext.Users.Any(a => a.UrlSlug == user.UrlSlug))
                {
                    _dbContext.Users.Add(user);
                }
            }
            _dbContext.SaveChanges();
            return users;


        }
        private IList<Delivery> AddDeliveries(IList<User> users)
        {
            var deliveries = new List<Delivery>()
            {
                new(){
                   Name= "Vận chuyển nhanh",
                   Date= DateTime.Now,
                   UrlSlug="van-chuyen-nhanh",
                  User= users[1]
                },
                new(){
                   Name= "Vận chuyển thông thường",
                   Date= DateTime.Now,
                   UrlSlug="van-chuyen-thong-thuong",
                  User= users[1]
                },
            };
            foreach (var deliver in deliveries)
            {
                if (!_dbContext.Deliveries.Any(a => a.UrlSlug == deliver.UrlSlug))
                {
                    _dbContext.Deliveries.Add(deliver);
                }
            }
            _dbContext.SaveChanges();
            return deliveries;

        }
        private IList<Product> AddProducts(IList<User> users, IList<Category> categories)
        {

            var products = new List<Product>() {
                new()
                {
                    Name= "Bàn ăn mở rộng Poppy",
                    UrlSlug= "ban-an-mo-rong",
                    Size="D1800/2250 - R900 - C740 mm",
                    Description="Bàn ăn mở rộng Poppy PMA830012 được làm từ gỗ tự nhiên với tông màu vàng ấm áp, mang không khí gần gũi cho mỗi bữa ăn. Bàn Poppy nổi bật với thiết kế phần mặt bàn có thể mở rộng khi gia đình có khách. Tuy thiết kế đơn giản nhưng lại rất tiện lợi và cực kì phù hợp cho không gian phòng ăn của mọi gia đình.",
                    Categories= new List<Category>()
                    {
                        categories[3],
                        categories[4]
                    },
                    Material="Gỗ tần bì (ash) , MDF veneer tần bì",
                    Price="17,500,000 đ",
                   User= users[1]


                },
                 new()
                {
                    Name= "Sofa Combo góc phải da Bali 520",
                    UrlSlug= "sofa-combo",
                    Size="D2800/1600 - R890 - C725 mm",
                    Description="Sofa Combo góc phải da Bali 520 có thiết kế 3 chỗ ngồi với phần chân bằng kim loại được sơn phối hợp 2 màu đen và gold. Phần nệm ghế được bọc da Bali bền và đẹp tạo cảm giác thoải mái dễ chịu khi ngồi. Sofa Combo bọc da tự nhiên với thiết kế sang trọng, hiện đại phù hợp cho không gian quây quần sum họp gia đình sau khoảng thời gian đi làm bận rộn hay là nơi chào đón những vị khách đến chơi nhà.",
                    Categories= new List<Category>()
                    {
                        categories[0],
                        categories[1]
                    },
                    Material="Chân kim loại 2 màu đen/gold - nệm bọc da tự nhiên",
                    Price="96,900,000 đ",
                                       User= users[2]



                },
                  new()
                {
                    Name= "Giường Cabo 1m8 PMA940025",
                    UrlSlug= "giuong-cabo",
                    Size="D2000 - R1800 - C1050 mm",
                    Description="Giường Cabo với thiết kế trang nhã, tinh tế, sang trọng trong đó khung giường được làm bằng chất liệu gỗ phủ lớp MDF veener ash cao cấp, chân giường được làm từ kim loại được sơn đen chắc chắn, có khả năng chịu lực tốt. Giường Cabo mang đến cảm giác thư giãn, thoải mái nhất để nghỉ ngơi sau thời gian làm việc dài, mà còn là món đồ quan trọng trong thiết kế nội thất phòng ngủ.",
                    Categories= new List<Category>()
                    {
                        categories[5],
                        categories[6]
                    },
                    Material="Gỗ - MDF veneer Ash, chân kim loại",
                    Price="96,900,000 đ",
                    Collection="Cabo",
                                      User= users[3]



                },





            };
            foreach (var product in products)
            {
                if (!_dbContext.Products.Any(a => a.UrlSlug == product.UrlSlug))
                {
                    _dbContext.Products.Add(product);
                }
            }
            _dbContext.SaveChanges();
            return products;
        }



    }
}
