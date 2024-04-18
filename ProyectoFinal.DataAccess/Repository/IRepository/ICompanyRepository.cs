using ProyectoFinal.Models;

namespace ProyectoFinal.DataAccess.Repository.IRepository
{
    public interface ICompanyRepository: IRepository<Company>
    {
        void Update(Company company);
    }
}
