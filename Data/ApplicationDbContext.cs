using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Project1670.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project1670.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            PopulateCategory(builder);
            SeedBook(builder);
            SeedUser(builder);
            SeedRole(builder);
            SeedUserRole(builder);
        }

        private void SeedUser(ModelBuilder builder)
        {
            //1. tạo tài khoản ban đầu để add vào DB
            var admin = new IdentityUser
            {
                Id = "1",
                UserName = "admin@fpt.com",
                Email = "admin@fpt.com",
                NormalizedUserName = "admin@fpt.com",
                EmailConfirmed = true
            };

            var storeowner = new IdentityUser
            {
                Id = "2",
                UserName = "storeowner@fpt.com",
                Email = "storeowner@fpt.com",
                NormalizedUserName = "storeowner@fpt.com",
                EmailConfirmed = true
            };

            var customer = new IdentityUser
            {
                Id = "3",
                UserName = "customer@fpt.com",
                Email = "customer@fpt.com",
                NormalizedUserName = "customer@fpt.com",
                EmailConfirmed = true
            };

            //2. khai báo thư viện để mã hóa mật khẩu
            var hasher = new PasswordHasher<IdentityUser>();

            //3. thiết lập và mã hóa mật khẩu   từng tài khoản
            admin.PasswordHash = hasher.HashPassword(admin, "123456");
            customer.PasswordHash = hasher.HashPassword(customer, "123456");
            storeowner.PasswordHash = hasher.HashPassword(storeowner, "123456");

            //4. add tài khoản vào db
            builder.Entity<IdentityUser>().HasData(admin, customer, storeowner);
        }

        private void SeedRole(ModelBuilder builder)
        {
            //1. tạo các role cho hệ thống
            var admin = new IdentityRole
            {
                Id = "A",
                Name = "Admin",
                NormalizedName = "Admin"
            };
            var storeowner = new IdentityRole
            {
                Id = "B",
                Name = "StoreOwner",
                NormalizedName = "StoreOwner"
            };
            var customer = new IdentityRole
            {
                Id = "C",
                Name = "Customer",
                NormalizedName = "Customer"
            };

            //2. add role vào trong DB
            builder.Entity<IdentityRole>().HasData(admin, customer, storeowner);

        }

        private void SeedUserRole(ModelBuilder builder)
        {
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    UserId = "1",
                    RoleId = "A"
                },
                new IdentityUserRole<string>
                {
                    UserId = "2",
                    RoleId = "B"
                },
                new IdentityUserRole<string>
                {
                    UserId = "3",
                    RoleId = "C"
                }
             );
        }

        private void PopulateCategory(ModelBuilder builder)
        {
            var comic = new Category
            {
                Id = 1,
                Name = "Comic",
                Description = "The stories in comic books and graphic novels are presented to the reader through engaging, sequential narrative art (illustrations and typography) that's either presented in a specific design or the traditional panel layout you find in comics.",
                Image = "https://m.media-amazon.com/images/I/61m7Jsvu1sL.jpg"
            };
            var scifi = new Category
            {
                Id = 2,
                Name = "ScienceFiction",
                Description = "Though they're often thought of in the same vein as fantasy, what distinguishes science fiction stories is that they lean heavily on themes of technology and future science. You'll find apocalyptic and dystopian novels in the sci-fi genre as well.",
                Image = "https://m.media-amazon.com/images/I/61m7Jsvu1sL.jpg"
            };
            var horror = new Category
            {
                Id = 3,
                Name = "Horror",
                Description = "Meant to cause discomfort and fear for both the character and readers, horror writers often make use of supernatural and paranormal elements in morbid stories that are sometimes a little too realistic.",
                Image = "https://m.media-amazon.com/images/I/61m7Jsvu1sL.jpg"
            };
            builder.Entity<Category>().HasData(comic, scifi, horror);
        }
        private void SeedBook(ModelBuilder builder)
        {
            builder.Entity<Book>().HasData(
                new Book
                {
                    Id = 1,
                    Title = "The Umbrella Academy, Vol. 1",
                    Price = 20,
                    Description = "Dark Horse Books, 184 Pages",
                    Quantity =30,
                    CategoryId = 1,
                    Image = "https://m.media-amazon.com/images/I/61m7Jsvu1sL.jpg"
                },
                new Book
                {
                    Id = 3,
                    Title = "Frank Miller's Sin City Volume 1",
                    Price = 35,
                    Description = "Dark Horse Books, 280 Pages",
                    Quantity = 30,
                    CategoryId = 1,
                    Image = "https://img.thriftbooks.com/api/images/m/20f29c7cae6564e7459110e2cd248e1e0865d228.jpg"
                },
                new Book
                {
                    Id = 2,
                    Title = "Game of Thrones",
                    Price = 100,
                    Description = "A Song of Ice and Fire Series, 801 Pages",
                    Quantity = 30,
                    CategoryId = 2,
                    Image = "https://img.thriftbooks.com/api/images/m/0c6017fb9fe27f6ded6709b6d208c3ab1652a05b.jpg"
                },
                new Book
                {
                    Id = 4,
                    Title = "A Clash of Kings",
                    Price = 80,
                    Description = "A Song of Ice and Fire Series, 784 Pages",
                    Quantity = 30,
                    CategoryId = 2,
                    Image = "https://img.thriftbooks.com/api/images/i/m/8FD33A481ADBA129AFB0BB58608AD92DA8EF5699.jpg"
                },
                new Book
                {
                    Id = 5,
                    Title = "The Night Eternal",
                    Price = 76,
                    Description = "The Strain Trilogy, 560 Pages",
                    Quantity = 30,
                    CategoryId = 3,
                    Image = "https://img.thriftbooks.com/api/images/m/7c7380abc6e305301e3245b8452f2b6cb1fd2b11.jpg"
                },
                new Book
                {
                    Id = 6,
                    Title = "The Fall",
                    Price = 56,
                    Description = "The Strain Trilogy Series, 448 Pages",
                    Quantity = 30,
                    CategoryId = 3,
                    Image = "https://img.thriftbooks.com/api/images/m/b1997effbab92350fe8ac0ff5a8979855c399440.jpg"
                }
            );
        }
    }
}
