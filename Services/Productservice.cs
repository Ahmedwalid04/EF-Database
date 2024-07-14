using Microsoft.EntityFrameworkCore;
public class ProductService
{
    public void AddProduct(Product product)
    {
        using var context = new ApplicationDbContext();
        try
        {
            // Simple validation example
            if (string.IsNullOrWhiteSpace(product.Name) || product.Price <= 0)
            {
                Console.WriteLine("Invalid product data. Please ensure the name is not empty and the price is positive.");
                return;
            }
            context.Products.Add(product);
            context.SaveChanges();
            Console.WriteLine("Product added successfully!");
        }
        catch (DbUpdateException ex)
        {
            Console.WriteLine($"An error occurred while saving the product: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An unexpected error occurred: {ex.Message}");
        }
    }
    public Product? GetProduct(int productId)
    {
        using var context = new ApplicationDbContext();
        return context.Products.Find(productId);
    }

    public List<Product> GetAllProducts()
    {
        using var context = new ApplicationDbContext();
        return context.Products.ToList();
    }

    public void UpdateProduct(Product product)
    {
        using var context = new ApplicationDbContext();
        context.Products.Update(product);
        context.SaveChanges();
    }

    public void DeleteProduct(int productId)
    {
        using var context = new ApplicationDbContext();
        var product = context.Products.Find(productId);
        if (product != null)
        {
            context.Products.Remove(product);
            context.SaveChanges();
        }
    }
}
