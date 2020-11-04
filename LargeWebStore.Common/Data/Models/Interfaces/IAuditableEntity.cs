using System;

namespace LargeWebStore.Common.Domain.Data.Interfaces
{
	public interface IAuditableEntity
	{
		Guid Id { get; set; }

		DateTime CreatedAt { get; set; }

		DateTime? UpdatedAt { get; set; }
	}
}
