using LargeWebStore.Common.Domain.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace LargeWebStore.Common.Data.Models.Shipping
{
    public class AddressModel : ModelBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Street { get; set; }
        public string Company { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }
        public string ProvinceCode { get; set; }
        public string ProvinceName { get; set; }
    }
}
