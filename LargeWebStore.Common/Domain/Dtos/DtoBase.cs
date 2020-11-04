using System;

namespace LargeWebStore.Common.Domain.Dtos
{
    public class DtoBase
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
