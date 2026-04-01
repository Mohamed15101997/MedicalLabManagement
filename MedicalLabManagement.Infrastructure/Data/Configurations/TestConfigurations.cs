using MedicalLabManagement.Domin.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedicalLabManagement.Infrastructure.Data.Configurations
{
	public class TestConfigurations : IEntityTypeConfiguration<Test>
	{
		public void Configure(EntityTypeBuilder<Test> builder)
		{
			// Code
			builder.Property(x => x.Code).IsRequired();
			builder.HasIndex(x => x.Code).IsUnique();

			// Name
			builder.Property(x => x.Name).IsRequired();

			// Price
			builder.Property(x => x.Price).HasPrecision(18,2);

			// SampleType
			builder.Property(x => x.SampleType)
				.HasConversion<string>()
				.IsRequired();

			// RelationsShips
			builder.HasOne(x => x.Category)
				.WithMany()
				.HasForeignKey(x => x.CategoryId)
				.OnDelete(DeleteBehavior.SetNull);
		}
	}
}
