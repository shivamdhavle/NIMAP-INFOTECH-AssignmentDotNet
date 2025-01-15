using AssignmentDotNet.Models;

public interface IProductService
{
    // Removed pagination parameters
    IEnumerable<Product> GetProducts();  // Now returns all products without pagination
    Product GetProductById(int productId);
    void AddProduct(Product product);
    void UpdateProduct(Product product);
    void DeleteProduct(int productId);
}
