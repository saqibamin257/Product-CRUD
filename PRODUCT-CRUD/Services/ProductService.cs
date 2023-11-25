using Microsoft.EntityFrameworkCore;
using PRODUCT_CRUD.Contracts.DBModel;
using PRODUCT_CRUD.Model;

namespace PRODUCT_CRUD.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDBContext appDBContext;
        public ProductService(AppDBContext _appDBContext) 
        {
           this.appDBContext = _appDBContext;
        }
        public async Task<Product> AddProduct(Product product)
        {
           var result= await appDBContext.Products.AddAsync(product);
                      await appDBContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Product> DeleteProduct(int id)
        {
            var result = await appDBContext.Products.FirstOrDefaultAsync(p => p.ProductID == id);
            if (result != null)            
            {
                appDBContext.Products.Remove(result);
                await appDBContext.SaveChangesAsync();
            }
            return null;
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await appDBContext.Products.ToListAsync();
        }

        public async Task<Product> GetProductById(int id)
        {
            return await appDBContext.Products.FirstOrDefaultAsync(p => p.ProductID == id);
        }

        public async Task<Product> UpdateProduct(Product product)
        {
            var result= await appDBContext.Products.FirstOrDefaultAsync(p=>p.ProductID == product.ProductID);
            if (result != null) 
            {
                result.Name=product.Name;
                result.Description=product.Description;
                result.Price=product.Price;
                await appDBContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
