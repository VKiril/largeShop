using LargeWebStore.Common.Domain.Dtos;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace LargeWebStore.Common.Domain.Queries
{
    public class GetCustomerQuery : QueryBase<CustomerDto>
    {
        public GetCustomerQuery()
        {

        }

        [JsonConstructor]
        public GetCustomerQuery(Guid customerId)
        {
            CustomerId = customerId;
        }

        [JsonProperty("id")]
        [Required]
        public Guid CustomerId { get; set; }
    }
}
