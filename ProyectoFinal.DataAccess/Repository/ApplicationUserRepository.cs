using ProyectoFinal.DataAccess.Data;
using ProyectoFinal.DataAccess.Repository.IRepository;
using ProyectoFinal.Models;

namespace ProyectoFinal.DataAccess.Repository
{
    public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
    {
        private readonly ApplicationDbContext _db;

        public ApplicationUserRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
