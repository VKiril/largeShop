using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LargeWebStore.Api.Services.Elastic;
using LargeWebStore.Common.Domain.Commands;
using LargeWebStore.Common.Domain.Data;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LargeWebStore.Api.Controllers
{
    public class TestingController : ApiBaseController
    {
        private readonly ICustomerService _customerService;

        public TestingController(IMediator mediator, ICustomerService customerService) : base(mediator)
        {
            _customerService = customerService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(CustomerModel), 200)]
        public async Task<IActionResult> Get(string query)
        {
            var result = await _customerService.SearchAsync(query);

            return Ok(result.Documents);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCustomerCommand command)
        {
            var customer = new CustomerModel
            {
                Email = command.Email,
                Name = command.Name,
                PhoneNumber = command.PhoneNumber
            };

            await _customerService.SaveBulkAsync(new CustomerModel[] { customer });

            return Ok("created");
        }
    }
}
