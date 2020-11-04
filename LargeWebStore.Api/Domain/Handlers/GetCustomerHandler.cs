using LargeWebStore.Common.Data.Repositories.Contracts;
using LargeWebStore.Common.Domain.Dtos;
using LargeWebStore.Common.Domain.Queries;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace LargeWebStore.Api.Domain.Handlers
{
    public class GetCustomerHandler : IRequestHandler<GetCustomerQuery, CustomerDto>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ILogger _logger;

        public GetCustomerHandler(ICustomerRepository customerRepository, ILogger<GetCustomerHandler> logger)
        {
            _customerRepository = customerRepository;
            _logger = logger;
        }

        public async Task<CustomerDto> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetAsync(x => x.Id == request.CustomerId);

            if (customer != null)
            {
                _logger.LogInformation($"Got a request get customer Id: {customer.Id}");
                var customerDto = new CustomerDto
                {
                    Id = customer.Id,
                    Name = customer.Name,
                    Email = customer.Email,
                    PhoneNumber = customer.PhoneNumber
                };
                return customerDto;
            }

            return null;
        }
    }
}
