using LargeWebStore.Common.Data.Repositories.Contracts;
using LargeWebStore.Common.Domain.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace LargeWebStore.Common.Data.Repositories
{
    public class CustomerRepository : BaseRepository<CustomerModel>, ICustomerRepository
    {
        public CustomerRepository(LocalWebStoreContext context): base(context)
        {
        }

        public async Task<bool> EmailExistAsync(string email)
        {
            return await ModelDbSets.AsNoTracking().AnyAsync(e => e.Email.Equals(email, StringComparison.CurrentCultureIgnoreCase));
        }
    }
}
