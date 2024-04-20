using ECommerce.Models;

namespace ECommerce.Services
{
    public class ProductService : IProductService
    {
        private readonly IDbService _dbService;

        public ProductService(IDbService dbService)
        {
            _dbService = dbService;
        }
        public async Task<bool> CreateProduct(Product product)
        {
            var result =
           await _dbService.EditData(
               "INSERT INTO public.product" +
               " (name, price, category, color, description, imagepath, quantity)" +
               " VALUES " +
               "(@Name, @Price, @Category,@Color, @Description, @ImagePath, @Quantity)",
               product);
            return true;
        }

        public async Task<bool> DeleteProduct(int id)
        {
            var deleteEmployee = await _dbService.EditData("DELETE FROM public.product WHERE id=@Id", new { id });
            return true;
        }

        public async Task<List<Product>> GetProductList()
        {
            var productList = await _dbService.GetAll<Product>("SELECT * FROM public.product", new { });
            return productList;
        }
        public async Task<Product> GetProductById(int id)
        {
            var product = await _dbService.GetAsync<Product>("SELECT * FROM public.product where id=@id", new { id });
            return product;
        }

        public async Task<Product> UpdateProduct(Product product)
        {
            var updateProduct =
             await _dbService.EditData(
                 "Update public.product " +
                 "SET name=@Name, price=@Price, category=@Category," +
                 " description=@Description, imagepath=@ImagePath, quantity=@Quantity, color=@Color " +
                 "WHERE id=@Id",
                 product);
            return product;
        }
    }
}
