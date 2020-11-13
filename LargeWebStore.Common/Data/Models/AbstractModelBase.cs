using LargeWebStore.Common.Data.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LargeWebStore.Common.Data.Models
{
    public class AbstractModelBase : IAbstractAuditableEntity
    {
        [Key]
        public virtual Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
