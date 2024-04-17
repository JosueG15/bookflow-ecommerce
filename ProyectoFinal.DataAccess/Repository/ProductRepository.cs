using ProyectoFinal.DataAccess.Data;
using ProyectoFinal.DataAccess.Repository.IRepository;
using ProyectoFinal.Models;

namespace ProyectoFinal.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _db;

        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Product product)
        {
            Product productFromDb = _db.Products.FirstOrDefault(pro => pro.Id == product.Id);

            if(productFromDb != null) 
            {
                productFromDb.Title = product.Title;
                productFromDb.ISBN = product.ISBN;
                productFromDb.Price = product.Price;
                productFromDb.Price50 = product.Price50;
                productFromDb.ListPrice = product.ListPrice;
                productFromDb.Price100 = product.Price100;
                productFromDb.Description = product.Description;
                productFromDb.CategoryId = product.CategoryId;
                productFromDb.Author = product.Author;

                if (product.ImageURL != null)
                {
                    productFromDb.ImageURL = product.ImageURL;
                }

            }
        }
    }
}
