using ECommerce.Models;

namespace ECommerce.Services
{
    public interface IProductService
    {
        Task<bool> CreateProduct(Product product);
        Task<List<Product>> GetProductList();
        Task<Product> GetProductById(int productId);
        Task<Product> UpdateProduct(Product product);
        Task<bool> DeleteProduct(int id);
    }
}
