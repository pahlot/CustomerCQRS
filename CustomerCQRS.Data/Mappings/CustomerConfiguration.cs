using CustomerCQRS.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomerCQRS.Data.Mappings
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Ignore(e => e.DomainEvents);

            builder.Property(t => t.FirstName)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(t => t.LastName)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(t => t.DateOfBirth)
                .IsRequired();
        }
    }
}
