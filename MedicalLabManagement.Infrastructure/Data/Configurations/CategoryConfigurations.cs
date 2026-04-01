using MedicalLabManagement.Domin.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedicalLabManagement.Infrastructure.Data.Configurations
{
	public class CategoryConfigurations : IEntityTypeConfiguration<Category>
	{
		public void Configure(EntityTypeBuilder<Category> builder)
		{
			// Code
			builder.Property(x => x.Code).IsRequired();
			builder.HasIndex(x => x.Code).IsUnique();

			// Name
			builder.Property(x => x.EnName).IsRequired();
			builder.Property(x => x.ArName).IsRequired();
		}
	}
}
