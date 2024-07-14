using System.Diagnostics;
using System.Xml.Linq;

var productService = new ProductService();


// Create
var newProduct = new Product { Name = "creatine", Price = 200 };
productService.AddProduct(newProduct);
WriteLine("Product added!");

// Read
        
var product = productService.GetProduct(newProduct.ProductId);
if (product is {})
{
    WriteLine($"Retrieved Product: {product.Name}, {product.Price}");
}
        
        
var products = productService.GetAllProducts();
if (products is {}) 

foreach (var p in products)
{
    WriteLine($"Product ID: {p.ProductId}, Name: {p.Name}, Price: {p.Price}");
}

// Update
if (product is not null)
{
    product.Name = "Protein";
    product.Price = 250.50M;
    productService.UpdateProduct(product);
    WriteLine("Product updated!");
}

// Delete
if (product is not null)
{
    productService.DeleteProduct(product.ProductId);
    WriteLine("Product deleted!");
}
