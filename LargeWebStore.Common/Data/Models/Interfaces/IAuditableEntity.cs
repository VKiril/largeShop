using System;

namespace LargeWebStore.Common.Domain.Data.Interfaces
{
	public interface IAuditableEntity
	{
		void SetId(Guid id);
		Guid Id { get; set; }
		DateTime CreatedAt { get; set; }

		DateTime? UpdatedAt { get; set; }
	}
}
