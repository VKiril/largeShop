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
    public class TaxonController : ApiBaseController
    {
        public TaxonController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTaxonCommand command)
        {
            return Ok(await CommandAsync(command));
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok();
        }
    }
}
