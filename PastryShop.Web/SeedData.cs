using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PastryShop.DAL;
using PastryShop.DAL.Models;

namespace PastryShop.Web
{
    internal static class SeedData
    {
        public static async Task Initialize(PastryDbContext dbContext)
        {
            var dessert1 = new Dessert
            {
                Name = "Torta mimosa",
                Price = 16.99m,
                CreateDate = DateTime.UtcNow.AddDays(-23),
                UserCreate = "Luana",
                ImageFullPath = "Images/Desserts/torta-mimosa.jpg",
                Ingredients = new List<Ingredient>
                {
                    new Ingredient
                    {
                        Name = "Uova",
                        Quantity = 7,
                        UM = "NR",
                        CreateDate = DateTime.UtcNow.AddDays(-23),
                        UserCreate = "Luana"
                    },
                    new Ingredient
                    {
                        Name = "Zucchero",
                        Quantity = 200,
                        UM = "GR",
                        CreateDate = DateTime.UtcNow.AddDays(-23),
                        UserCreate = "Luana"
                    },
                    new Ingredient
                    {
                        Name = "Fecola di patate",
                        Quantity = 130,
                        UM = "GR",
                        CreateDate = DateTime.UtcNow.AddDays(-23),
                        UserCreate = "Luana"
                    }
                }
            };

            var dessert2 = new Dessert
            {
                Name = "Cheesecake fredda",
                Price = 24.99m,
                CreateDate = DateTime.UtcNow.AddDays(-23),
                UserCreate = "Luana",
                ImageFullPath = "Images/Desserts/cheesecake-a-freddo.jpg",
                Ingredients = new List<Ingredient>
                {
                    new Ingredient
                    {
                        Name = "Confettura",
                        Quantity = 250,
                        UM = "GR",
                        CreateDate = DateTime.UtcNow.AddDays(-23),
                        UserCreate = "Luana"
                    },
                    new Ingredient
                    {
                        Name = "Uova",
                        Quantity = 3,
                        UM = "NR",
                        CreateDate = DateTime.UtcNow.AddDays(-23),
                        UserCreate = "Luana"
                    },
                    new Ingredient
                    {
                        Name = "Zucchero",
                        Quantity = 350,
                        UM = "GR",
                        CreateDate = DateTime.UtcNow.AddDays(-23),
                        UserCreate = "Luana"
                    }
                }
            };

            var dessert3 = new Dessert
            {
                Name = "Biscotti al burro",
                Price = 9.99m,
                CreateDate = DateTime.UtcNow.AddDays(-23),
                UserCreate = "Luana",
                ImageFullPath = "Images/Desserts/biscotti-al-burro.jpg",
                Ingredients = new List<Ingredient>
                {
                    new Ingredient
                    {
                        Name = "Farina 00",
                        Quantity = 200,
                        UM = "GR",
                        CreateDate = DateTime.UtcNow.AddDays(-23),
                        UserCreate = "Luana"
                    },
                    new Ingredient
                    {
                        Name = "Burro",
                        Quantity = 100,
                        UM = "GR",
                        CreateDate = DateTime.UtcNow.AddDays(-23),
                        UserCreate = "Luana"
                    },
                    new Ingredient
                    {
                        Name = "Zucchero",
                        Quantity = 150,
                        UM = "GR",
                        CreateDate = DateTime.UtcNow.AddDays(-23),
                        UserCreate = "Luana"
                    }
                }
            };

            var dessert4 = new Dessert
            {
                Name = "Budino classico",
                Price = 19.25m,
                CreateDate = DateTime.UtcNow.AddDays(-23),
                UserCreate = "Luana",
                ImageFullPath = "Images/Desserts/Budino-classico-al-cioccolato.jpg",
                Ingredients = new List<Ingredient>
                {
                    new Ingredient
                    {
                        Name = "Latte",
                        Quantity = 1,
                        UM = "LT",
                        CreateDate = DateTime.UtcNow.AddDays(-23),
                        UserCreate = "Luana"
                    },
                    new Ingredient
                    {
                        Name = "Cacao amaro",
                        Quantity = 25,
                        UM = "GR",
                        CreateDate = DateTime.UtcNow.AddDays(-23),
                        UserCreate = "Luana"
                    },
                    new Ingredient
                    {
                        Name = "Zucchero",
                        Quantity = 150,
                        UM = "GR",
                        CreateDate = DateTime.UtcNow.AddDays(-23),
                        UserCreate = "Luana"
                    }
                }
            };

            var dessert5 = new Dessert
            {
                Name = "Macarons",
                Price = 19.25m,
                CreateDate = DateTime.UtcNow.AddDays(-23),
                UserCreate = "Luana",
                ImageFullPath = "Images/Desserts/macarons.jpg",
                Ingredients = new List<Ingredient>
                {
                    new Ingredient
                    {
                        Name = "Albumi vecchi",
                        Quantity = 100,
                        UM = "GR",
                        CreateDate = DateTime.UtcNow.AddDays(-23),
                        UserCreate = "Luana"
                    },
                    new Ingredient
                    {
                        Name = "Farina di mandorle",
                        Quantity = 125,
                        UM = "GR",
                        CreateDate = DateTime.UtcNow.AddDays(-23),
                        UserCreate = "Luana"
                    },
                    new Ingredient
                    {
                        Name = "Zucchero",
                        Quantity = 150,
                        UM = "GR",
                        CreateDate = DateTime.UtcNow.AddDays(-23),
                        UserCreate = "Luana"
                    }
                }
            };

            // cleanup existing data
            //dbContext.ShowcaseItems.RemoveRange(dbContext.ShowcaseItems);
            //dbContext.Desserts.RemoveRange(dbContext.Desserts);

            //foreach (var sci in dbContext.ShowcaseItems)
            //    dbContext.ShowcaseItems.Remove(sci);

            foreach (var d in dbContext.Desserts)
                dbContext.Desserts.Remove(d);

            //await dbContext.SaveChangesAsync();

            dbContext.Desserts.Add(dessert1);
            dbContext.Desserts.Add(dessert2);
            dbContext.Desserts.Add(dessert3);
            dbContext.Desserts.Add(dessert4);
            dbContext.Desserts.Add(dessert5);

            await dbContext.ShowcaseItems.AddRangeAsync(
                new ShowcaseItem
                {
                    Dessert = dessert1,
                    Enable = true,
                    Price = 14.99m,
                    CreateDate = DateTime.UtcNow.AddHours(-3),
                    CreateUser = "piero.cannizzaro@gmail.com"
                },
                new ShowcaseItem
                {
                    Dessert = dessert2,
                    Enable = true,
                    Price = 17.99m,
                    CreateDate = DateTime.UtcNow.AddHours(-(24 + 2)),
                    CreateUser = "piero.cannizzaro@gmail.com"
                },
                new ShowcaseItem
                {
                    Dessert = dessert3,
                    Enable = true,
                    Price = 22.99m,
                    CreateDate = DateTime.UtcNow.AddHours(-(24 * 2 + 4)),
                    CreateUser = "piero.cannizzaro@gmail.com"
                },
                new ShowcaseItem
                {
                    Dessert = dessert4,
                    Enable = true,
                    Price = 25.99m,
                    CreateDate = DateTime.UtcNow.AddHours(-(24 * 4 + 1)),
                    CreateUser = "piero.cannizzaro@gmail.com"
                },
                new ShowcaseItem
                {
                    Dessert = dessert5,
                    Enable = true,
                    Price = 25.99m,
                    CreateDate = DateTime.UtcNow.AddHours(-(24 * 3 + 5)),
                    CreateUser = "piero.cannizzaro@gmail.com"
                },

                new ShowcaseItem
                {
                    Dessert = dessert5,
                    Enable = true,
                    Price = 14.99m,
                    CreateDate = DateTime.UtcNow.AddHours(-3),
                    CreateUser = "piero.cannizzaro@gmail.com"
                },

                new ShowcaseItem
                {
                    Dessert = dessert4,
                    Enable = true,
                    Price = 17.99m,
                    CreateDate = DateTime.UtcNow.AddHours(-(24 + 2)),
                    CreateUser = "piero.cannizzaro@gmail.com"
                });

            await dbContext.SaveChangesAsync();
        }
    }
}