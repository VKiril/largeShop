using LargeWebStore.Common.Domain.Data;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LargeWebStore.Api.Services.Elastic
{
    public interface ICustomerService
    {
        Task<GetResponse<CustomerModel>> GetAsync(int id);
        Task<ISearchResponse<CustomerModel>> SearchAsync(string query, int page = 1, int pageSize = 5);
        Task DeleteAsync(CustomerModel product);
        Task SaveSingleAsync(CustomerModel product);
        Task SaveManyAsync(CustomerModel[] products);
        Task SaveBulkAsync(CustomerModel[] products);
        Task ReIndex(CustomerModel[] products);
    }
}
