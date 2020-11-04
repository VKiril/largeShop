using LargeWebStore.Common.Domain.Data;
using System.Threading.Tasks;

namespace LargeWebStore.Common.Data.Repositories.Contracts
{
    public interface ICustomerRepository : IBaseRepository<CustomerModel>
    {
        Task<bool> EmailExistAsync(string email);
    }
}
