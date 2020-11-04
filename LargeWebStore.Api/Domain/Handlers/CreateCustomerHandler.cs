using LargeWebStore.Common.Business.Contracts.Logger;
using LargeWebStore.Common.Data.Repositories.Contracts;
using LargeWebStore.Common.Domain.Commands;
using LargeWebStore.Common.Domain.Dtos;
using LargeWebStore.Common.Domain.Data;
using MassTransit;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LargeWebStore.Api.Domain.Handlers
{
    public class CreateCustomerHandler : IRequestHandler<CreateCustomerCommand, CustomerDto>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMediator _mediator;
        private readonly IPublishEndpoint _endpoint;

        public CreateCustomerHandler(ICustomerRepository customerRepository, IMediator mediator, IPublishEndpoint endpoint)
        {
            _customerRepository = customerRepository;
            _mediator = mediator;
            _endpoint = endpoint;
        }

        public async Task<CustomerDto> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            // check if customer exists by email
            var customer = new CustomerModel
            {
                Id = new Guid(),
                Name = request.Name,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber
            };

            _customerRepository.Add(customer);


            if (await _customerRepository.SaveChangesAsync() == 0)
            {
                throw new ApplicationException();
            }

            await _endpoint.Publish<ILogConsumer>(new { Message = "New customer was added with id:  " + customer.Id });
            //await _mediator.Publish(new Domain.Events.CustomerCreatedEvent(customer.Id), cancellationToken);

            return new CustomerDto
            {
                Id = customer.Id,
                Email = customer.Email,
                Name = customer.Name,
                PhoneNumber = customer.PhoneNumber
            };
        }
    }
}
