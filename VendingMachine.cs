using System;
using System.Collections.Generic;
using System.Linq;

namespace Vending {
    public class VendingMachine {
        private List<Product> _products = new List<Product> ();

        public VendingMachine () {
            _products.Add (new Product () { Id = 1, Name = "Snickers", Price = .75 });
            _products.Add (new Product () { Id = 2, Name = "Pepsi", Price = 1.25 });
            _products.Add (new Product () { Id = 3, Name = "Diamond Ring", Price = 2_400 });
            _products.Add (new Product () { Id = 4, Name = "Tesla", Price = 85_000 });
            _products.Add (new Product () { Id = 5, Name = "Hot Pocket", Price = 1.50 });
        }

        // Add a new product to the Vending Machine (For stocking machine)
        public void AddProduct (Product newProduct) {
            List<int> allIds = _products.Select (p => p.Id).ToList ();
            int newProductId = newProduct.Id;

            if (allIds.Contains (newProductId)) {
                Console.WriteLine ("This product ID already exists.");
            } else {
                _products.Add (newProduct);
            }
        }

        // Remove a product from the Vending Machine (for purchasing a product)
        public void RemoveProduct (Product productToRemove) {
            _products.Remove (productToRemove);
        }

        // Get all products ordered by price (lowest on top)
        public List<Product> GetAll () {
            List<Product> sortedByPrice = _products.OrderBy (p => p.Price).ToList ();
            return sortedByPrice;
        }

        // Find a product by name. Results should be ordered by name)
        public List<Product> SearchByName (string nameCriteria) {
            List<Product> foundProduct = _products.Where (p => p.Name == nameCriteria).ToList ();
            return foundProduct;
        }

        // Find a product between a range or prices. Results should be ordered by price
        public List<Product> SearchByPrice (double minPrice, double maxPrice) {
            List<Product> sortedByPrice = _products.Where (p => p.Price < maxPrice && p.Price > minPrice).ToList ();
            return sortedByPrice;
        }

        // Return a product with a given ID. Return null if not found.
        public Product GetById (int id) {
            Product purchasedProduct = _products.FirstOrDefault (p => p.Id == id);
            return purchasedProduct;
        }

        // Return the cheapest product or null if there are no products
        public Product GetCheapest () {
            double minPrice = _products.Min (p => p.Price);
            Product cheapestProduct = _products.FirstOrDefault (p => p.Price == minPrice);
            return cheapestProduct;
        }

        // Return the most expensive product or null if there are no products
        public Product GetMostExpensive () {
            double maxPrice = _products.Max (p => p.Price);
            Product boujiestProduct = _products.FirstOrDefault (p => p.Price == maxPrice);
            return boujiestProduct;
        }

        // Return all the product names in alphabetical ordere
        public List<string> GetProductNames () {
            return _products.Select (p => p.Name).OrderBy (n => n).ToList ();
        }

        // Property to represent the total of all the products' prices.
        public double TotalValue {
            get {
                return _products.Sum (p => p.Price);
            }
        }
    }
}