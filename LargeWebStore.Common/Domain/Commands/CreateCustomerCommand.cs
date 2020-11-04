using LargeWebStore.Common.Domain.Dtos;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace LargeWebStore.Common.Domain.Commands
{
    public class CreateCustomerCommand : CommandBase<CustomerDto>
    {
        public CreateCustomerCommand()
        {
        }

        [JsonConstructor]
        public CreateCustomerCommand(string name, string email, string phone)
        {
            Name = name;
            Email = email;
            PhoneNumber = phone;
        }

        [JsonProperty("name")]
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [JsonProperty("email")]
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [JsonProperty("phone_number")]
        [Required]
        [Phone]
        public string PhoneNumber { get; set; }
    }
}
