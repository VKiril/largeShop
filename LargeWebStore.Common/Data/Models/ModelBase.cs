using LargeWebStore.Common.Domain.Data.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;

namespace LargeWebStore.Common.Domain.Data
{
    public abstract class ModelBase : IAuditableEntity
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public virtual void SetId(Guid id)
        {
            Id = id;
        }
    }
}
