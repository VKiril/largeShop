using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LargeWebStore.Common.Domain.Commands;
using LargeWebStore.Common.Domain.Dtos;
using LargeWebStore.Common.Domain.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LargeWebStore.Api.Controllers
{
    public class CustomerController : ApiBaseController
    {
        public CustomerController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(CustomerDto), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<CustomerDto>> GetCustomerAsync(Guid id)
        {
            return Single(await QueryAsync(new GetCustomerQuery(id)));
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> CreateCustomerAsync(CreateCustomerCommand command)
        {
            return Ok(await CommandAsync(command));
        }
    }
}
