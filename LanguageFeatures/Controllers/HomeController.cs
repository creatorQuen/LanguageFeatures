using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LanguageFeatures.Models;

namespace LanguageFeatures.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            //
            /*
            List<string> results = new List<string>();

            foreach (Product p in Product.GetProducts())
            {
                string name = p?.Name ?? "<No Name>";
                decimal? price = p?.Price ?? 0;

                string relatedName = p?.Related?.Name ?? "<None>";

                //results.Add(string.Format("Name: {0}, Price: {1}, Related: {2}", name, price, relatedName));
                results.Add($"Name: {name}, Price: {price}, Related: {relatedName}");
            }
            return View(results);
            */



            // Использование инициализаторпа коллекции.
            /*
            return View("Index", new string[] { "Bob", "Joe", "Alice"});
            */



            // Использование инициализатора индексированной коллекции.
            /*___Инициализация словоря
            Dictionary<string, Product> products = new Dictionary<string, Product>
            {
                {"Kayak", new Product {Name = "Kayak", Price = 275M} },
                {"Lifejacket", new Product {Name = "Lifejacket", Price = 48.95M } }
            };
            return View("Index", products.Keys);
            */

            /*___Использование синтаксиса инициализатора коллекции
            Dictionary<string, Product> products = new Dictionary<string, Product>
            {
                ["Kayak"] = new Product { Name = "Kayak", Price = 275M},
                ["Lifejacket"] = new Product { Name = "Lifejacket", Price = 48.95M}
            };
            return View("Index", products.Keys);
            */



            // Сопоставление с образцом: Выполнеине проверки типа.
            /*
            object[] data = new object[] { 275M, 29.95M, "apple", "orange", 100, 10 };
            decimal total = 0;
            for(int i=0; i < data.Length; i++)
            {
                if (data[i] is decimal d)
                {
                    total += d;
                }
            }
            return View("Index", new string[] { $"Total: {total:C2}" });
            */



            // Сопоставление с образцом в операторах switch.
            /*
            object[] data = new object[] { 275M, 29.95M, "apple", "orange", 100, 10 };
            decimal total = 0;
            for (int i = 0; i < data.Length; i++)
            {
                switch (data[i])
                {
                    case decimal deicmalValue:
                        total += deicmalValue;
                        break;
                    case int intValue when intValue > 50:
                        total += intValue;
                        break;
                }
            }
            return View("Index", new string[] { $"Total: {total:C2}" });
            */



            // Использование расширяющих методов.
            /*
            ShoppingCart cart = new ShoppingCart { Products = Product.GetProducts() };
            decimal cartTotal = cart.TotalPrices();
            return View("Index", new string[] { $"Total: {cartTotal:C2}" });
            */



            // Применение расширяющего метода к массиву.
            /*
            ShoppingCart cart = new ShoppingCart { Products = Product.GetProducts() };
            Product[] productArray =
            {
                new Product {Name = "Kayak", Price = 275M},
                new Product {Name = "Lifejacket", Price = 48.95M}
            };
            decimal cartTotal = cart.TotalPrices();
            decimal arrayTotal = productArray.TotalPrices();
            return View("Index", new string[] {
                $"Cart Total: {cartTotal:C2}",
                $"Array Total: {arrayTotal:C2}"
            });
            */



            // Применениние фильтрующего расширяющего метода
            /*
            ShoppingCart cart = new ShoppingCart { Products = Product.GetProducts() };
            Product[] productArray =
            {
                new Product {Name = "Kayak", Price = 275M},
                new Product {Name = "Lifejacket", Price = 48.95M},
                new Product {Name = "Soccer ball", Price = 19.50M},
                new Product {Name = "Corner flag", Price = 34.95M},
            };
            decimal arrayTotal = productArray.FilterByPrice(20).TotalPrices();
            return View("Index", new string[] { $"Array Total: {arrayTotal:C2}"});
            */



            // ИСПОЛЬЗОВАНИЕ ЛЯМБДА-ВЫРАЖЕНИЙ.
            // Использование двух фильтрующих методов.
            /*
            ShoppingCart cart = new ShoppingCart { Products = Product.GetProducts() };
            Product[] productArray =
            {
                new Product {Name = "Kayak", Price = 275M},
                new Product {Name = "Lifejacket", Price = 48.95M},
                new Product {Name = "Soccer ball", Price = 19.50M},
                new Product {Name = "Corner flag", Price = 34.95M},
            };
            decimal arrayTotal = productArray.FilterByPrice(20).TotalPrices();
            decimal nameFilterTotal = productArray.FilterByName('S').TotalPrices();

            return View("Index", new string[] { $"Array Total: {arrayTotal:C2}",
                $"Name Total: {nameFilterTotal:C2}"}
            );
            */



            // Определение функций. Использование функции для фильтрации объектов Product.
            // Однако именно такой пример не идеален.
            // Плюс необходимо писать вне класса метод FilterByPrice.
            ////bool FilterByPrice(Product p)
            ////{
            ////    return (p?.Price ?? 0) >= 20;
            ////}
            /*
            Product[] productArray =
                {
                new Product {Name = "Kayak", Price = 275M},
                new Product {Name = "Lifejacket", Price = 48.95M},
                new Product {Name = "Soccer ball", Price = 19.50M},
                new Product {Name = "Corner flag", Price = 34.95M},
                };

                Func<Product, bool> nameFilter = delegate (Product prod) { return prod?.Name?[0] == 'S';};

                decimal priceFilterTotal = productArray
                    .Filter(FilterByPrice)
                    .TotalPrices();

                decimal nameFilterTotal = productArray
                    .Filter(nameFilter)
                    .TotalPrices();

                return View("Index", new string[]
                {
                    $"Price Total: {priceFilterTotal:C2}",
                    $"Name Total: {nameFilter:C2}"
                });
            */
            //------------------------------------------------------------------------------------
            //  Именно эту задачу решают лямбда-выражения, позволяя определять 
            // функции более элегантным и выразительным способом, как видно в листинге 4.31.
            /*
            Product[] productArray =
            {
                new Product {Name = "Kayak", Price = 275M},
                new Product {Name = "Lifejacket", Price = 48.95M},
                new Product {Name = "Soccer ball", Price = 19.50M},
                new Product {Name = "Corner flag", Price = 34.95M},
            };

            decimal priceFilterTotal = productArray
                .Filter(p => (p?.Price ?? 0) >= 20)
                .TotalPrices();

            decimal nameFilterTotal = productArray
                .Filter(p => p?.Name?[0] == 'S')
                .TotalPrices();

            return View("Index", new string[]
            {
                $"Price Total: {priceFilterTotal:C2}",
                $"Name Total: {nameFilterTotal:C2}"
            });
            */




            // ИСПОЛЬЗОВАНИЕ МЕТОДОВ И СВОЙСТВ В ФОРМЕ ЛЯМБДА-ВЫРАЖЕНИЙ.
            // Создание общего шаблона действия.
            /*
            return View(Product.GetProducts().Select(p => p?.Name));
            */
            //------------------------------------------------------------------
            //// Метод действия, представленный как лямбда-выражение.
            //public ViewResult Index() => View(Product.GetProducts().Select(p => p?.Name));



            // ИСПОЛЬЗОВАНИЕ АВТОМАТИЧЕСКОГО ВЫВЕДЕНИЯ ТИПА И АНОНИМНЫХ ТИПОВ.
            // Использование выведения типа.
            /*
            var names = new[] { "Kayak", "Lifejacket", "Soccer ball" };
            return View(names);
            */



            // Использование анонимных типов.
            // Создание анономного типа.
            /*
            var product = new[]
            {
                new {Name = "Kayak", Price = 275M},
                new {Name = "Lifejacket", Price = 48.95M},
                new {Name = "Soccer ball", Price = 19.50M},
                new {Name = "Corner flag", Price = 34.95M},
            };
            return View(product.Select(p => p.Name));
            // return View(products.Select(p => p.GetType().Name));  - это чтобы вывести имя анонимного типа.
            */




            // ПОЛУЧЕНИЕ ИМЕН.
            // Использование жестко закодированного имени.

            var products = new[]
            {
                new { Name = "Kayak", Price = 275M },
                new { Name = "Lifejacket", Price = 48.95M },
                new { Name = "Soccer ball", Price = 19.50M },
                new { Name = "Corner flag", Price = 34.95M  },

            };
            //// Использование жестко закодированного имени.
            //return View(products.Select(p => $"Name: {p.Name}, Price: {p.Price}"));
            return View(products.Select(p => $"{nameof(p.Name)}: {p.Name}, {nameof(p.Price)}: {p.Price}"));
        }


        // ИСПОЛЬЗОВАНИЕ АСИНХРОННЫХ МЕТОДОВ.
        // Определение асинхронных методов действий (применение ключевых слов async и await.).
        /*
        public async Task<ViewResult> Index()
        {
            long? lenght = await MyAsyncMethods.GetPageLength();
            return View(new string[] { $"Length: {lenght}" });
        }
        */

    }
}
