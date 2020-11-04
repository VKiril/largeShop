using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LargeWebStore.Common.Domain.Commands.Product;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LargeWebStore.DWH.Api.Controllers
{
    public class ProductController : ApiBaseController
    {
        public ProductController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> CreateCustomerAsync(CreateProductCommand command)
        {
            return Ok(await CommandAsync(command));
        }
    }
}
