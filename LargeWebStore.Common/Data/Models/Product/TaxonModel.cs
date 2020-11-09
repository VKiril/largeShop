using LargeWebStore.Common.Domain.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace LargeWebStore.Common.Data.Models.Product
{
    public class TaxonModel : ModelBase
    {
        public Guid TreeRoot { get; set; }
        public Guid? Parent { get; set; }
        public int TreeLevel { get; set; }
        public string Code { get; set; }
    }
}
