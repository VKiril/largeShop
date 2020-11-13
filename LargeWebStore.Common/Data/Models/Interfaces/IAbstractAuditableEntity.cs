using System;

namespace LargeWebStore.Common.Data.Models.Interfaces
{
    public interface IAbstractAuditableEntity
    {
        abstract Guid Id { get; set; }
        DateTime CreatedAt { get; set; }

        DateTime? UpdatedAt { get; set; }
    }
}
