using ProyectoFinal.DataAccess.Data;
using ProyectoFinal.DataAccess.Repository.IRepository;
using ProyectoFinal.Models;

namespace ProyectoFinal.DataAccess.Repository
{
    public class ProductImageRepository : Repository<ProductImage>, IProductImageRepository
    {
        private readonly ApplicationDbContext _db;

        public ProductImageRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(ProductImage productImage)
        {
            _db.ProductImages.Update(productImage);
        }
    }
}
