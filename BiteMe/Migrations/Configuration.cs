namespace BiteMe.Migrations
{
    using BiteMe.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BiteMe.DAL.BiteMeContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "BiteMe.DAL.SchoolContext";
        }

        protected override void Seed(BiteMe.DAL.BiteMeContext context)
        {
            var products = new List<Product>
            {
                new Product{ Name = "Passion", UnitPrice = 700, Unit = Unit.kg, Description = "Family size", Category = Category.Cake },
                new Product{ Name = "Almond Brownie", UnitPrice = 180, Unit = Unit.pcs, Description = "Extra soft", Category = Category.Pastry },
                new Product{ Name = "Crispy Cookies", UnitPrice = 250, Unit = Unit.kg, Description = "Very thin", Category = Category.Cookie },
                new Product{ Name = "Valentine's", UnitPrice = 800, Unit= Unit.kg, Description = "Available only on Valentine's day", Category = Category.Cake },
                new Product{ Name = "Lemon Pie", UnitPrice = 500, Unit = Unit.kg, Description = "Tasty & bitter", Category = Category.Cake },
                new Product{ Name = "From Russia with Love", UnitPrice = 650, Unit = Unit.kg, Description = "Pavlova cake", Category = Category.Cake },
                new Product{ Name = "Soft Desire", UnitPrice = 250, Unit = Unit.pcs, Description = "Cupcakes", Category = Category.Pastry },
                new Product{ Name = "Cinamon bun", UnitPrice = 300, Unit = Unit.pcs, Description = "Perfect for English breakfast", Category = Category.Pastry },
                new Product{ Name = "Baklava", UnitPrice = 180, Unit = Unit.pcs, Description = "Old school recipy from SE Europe", Category = Category.Pastry },
                new Product{ Name = "Pumpkin Waffle", UnitPrice = 500, Unit = Unit.pcs, Description = "Suitable with tea or coffee", Category = Category.Pastry },
                new Product{ Name = "Black power", UnitPrice = 180, Unit = Unit.pcs, Description = "Crispy with chocolate bits", Category = Category.Cookie },
                new Product{ Name = "Christmas Cookie", UnitPrice = 270, Unit = Unit.pcs, Description = "Available only on Christmas", Category = Category.Cookie },
                new Product{ Name = "Green Tea", UnitPrice = 700, Unit= Unit.kg, Description = "For vegeterians", Category = Category.Cake },
                new Product{ Name = "Special Cookies", UnitPrice = 250, Unit = Unit.pcs, Description = "Contains a mix of dry fruits & Chocolate", Category = Category.Cookie },
                new Product{ Name = "Chewy Gluten Free", UnitPrice = 230, Unit = Unit.pcs, Description = "Gluten free", Category = Category.Cookie },
                new Product{ Name = "Chocolate Cake", UnitPrice = 600, Unit = Unit.pcs, Description = "With milk and dark chocolate", Category = Category.Cake },
                new Product{ Name = "Napoleon", UnitPrice = 350, Unit = Unit.pcs, Description = "Mille-feuille", Category = Category.Pastry },
                new Product{ Name = "Dry Almond", UnitPrice = 150, Unit = Unit.pcs, Description = "Filled with almonds", Category = Category.Cookie }
            };
            products.ForEach(p => context.Products.Add(p));
            context.SaveChanges();



            var customers = new List<Customer>
            {
                // Να δημιουργείται αυτόματα με την δημιουργία account.
                new Customer{ FirstName = "Thanos", LastName = "Melistas", Address = "Hremonidou 1", ZipCode = "11634", Email = "thanos.melistas@gmail.com", Password = "Woody", Phone = "6944197987", Gender = Gender.Male },
                new Customer{ FirstName = "Panagiotis", LastName = "Bourmpopoulos", Address = "Ag.Georgiou 5", ZipCode = "EC57B", Email = "bourmpopoulos@gmail.com", Password = "12345", Phone = "6990789546", Gender = Gender.Male },
                new Customer{ FirstName = "Eirini", LastName = "Stamataki", Address = "Alois", ZipCode = "19023", Email = "steirini@gmail.com", Password = "ohf89g", Phone = "6995680532", Gender = Gender.Female },
                new Customer{ FirstName = "Vasilis", LastName = "Bitsanis", Address = "Papagou 000", ZipCode = "12345", Email = "bitsanis@bitsanis.com", Password = "5f67gh8", Phone = "6987451230", Gender = Gender.Male },
                new Customer{ FirstName = "Oresits", LastName = "Papathanasiou", Address = "Dafnis 000", ZipCode = "69874", Email = "orestis.orestis@gmail.com", Password = "ht91cse", Phone = "632598745", Gender = Gender.Male },
                new Customer{ FirstName = "Periklis", LastName = "Aidinopoulos", Address = "Neas Iwnias 000", ZipCode = "45632", Email = "peri.peri@adidinopoulos.com", Password = "n65f3", Phone = "632598963", Gender = Gender.Male },
            };
            customers.ForEach(c => context.Customers.Add(c));
            context.SaveChanges();



            var orders = new List<Order>
            {
                // Πως γίνεται να περάσουμε στο orders, products και το τελικό ποσό παραγγελίας (totalUnitPrice) ???
                new Order {OrderDate = DateTime.Parse("2005-09-01"), DeliveryDate = DateTime.Parse("2005-09-02"), CustomerID = 1, Status = Status.Delivered },
                new Order {OrderDate = DateTime.Parse("2011-12-23"), DeliveryDate = DateTime.Parse("2012-01-01"), CustomerID = 1, Status = Status.Delivered },
                new Order {OrderDate = DateTime.Parse("2017-04-17"), DeliveryDate = DateTime.Parse("2017-04-18"), CustomerID = 2, Status = Status.Delivered },
                new Order {OrderDate = DateTime.Parse("2010-10-09"), DeliveryDate = DateTime.Parse("2010-11-17"), CustomerID = 3, Status = Status.Delivered },
                new Order {OrderDate = DateTime.Parse("2018-02-12"), DeliveryDate = DateTime.Parse("2018-02-13"), CustomerID = 5, Status = Status.Delivered },
                new Order {OrderDate = DateTime.Parse("2018-03-11"), DeliveryDate = DateTime.Parse("2018-06-30"), CustomerID = 2, Status = Status.Pending }
            };
            orders.ForEach(o => context.Orders.Add(o));
            context.SaveChanges();



            var productOrders = new List<ProductOrder>
            {
                // Ένα order μπορεί να έχει πολλά product. Πως τα παίρνει αυτόματα ???
                new ProductOrder{ProductID = 2, OrderID = 1, Quantity = 10 },
                new ProductOrder{ProductID = 3, OrderID = 1, Quantity = 20 },
                new ProductOrder{ProductID = 5, OrderID = 2, Quantity = 10 },
                new ProductOrder{ProductID = 12, OrderID = 2, Quantity = 2 },
                new ProductOrder{ProductID = 4, OrderID = 3, Quantity = 4 },
                new ProductOrder{ProductID = 8, OrderID = 3, Quantity = 6 },
                new ProductOrder{ProductID = 2, OrderID = 4, Quantity = 7 },
                new ProductOrder{ProductID = 7, OrderID = 4, Quantity = 35 },
                new ProductOrder{ProductID = 11, OrderID = 5, Quantity = 20 },
                new ProductOrder{ProductID = 12, OrderID = 5, Quantity = 12 },
                new ProductOrder{ProductID = 9, OrderID = 6, Quantity = 6 },
                new ProductOrder{ProductID = 1, OrderID = 6, Quantity = 8 },
            };
            productOrders.ForEach(p => context.ProductOrders.Add(p));
            context.SaveChanges();
        }
    }
}
