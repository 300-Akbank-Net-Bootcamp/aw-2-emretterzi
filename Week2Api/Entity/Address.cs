using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Week2Api.Entity;

[Table("Address", Schema = "dbo")]
public class Address : BaseEntity
{
    public int CustomerId { get; set; }
    public virtual Customer Customer { get; set; }

    public string Address1 { get; set; }
    public string Address2 { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
    public string County { get; set; }
    public string PostalCode { get; set; }
    public bool IsDefault { get; set; }
}

public class AddressConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.Property(x => x.InsertDate).IsRequired();
        builder.Property(x => x.InsertUserId).IsRequired();
        builder.Property(x => x.UpdateDate).IsRequired(false);
        builder.Property(x => x.UpdateUserId).IsRequired(false);
        builder.Property(x => x.IsActive).IsRequired().HasDefaultValue(true);

        builder.Property(x => x.CustomerId).IsRequired();
        builder.Property(x => x.Address1).IsRequired().HasMaxLength(150);
        builder.Property(x => x.Address2).IsRequired(false).HasMaxLength(150);
        builder.Property(x => x.Country).IsRequired().HasMaxLength(100);
        builder.Property(x => x.City).IsRequired().HasMaxLength(100);
        builder.Property(x => x.County).IsRequired(false).HasMaxLength(100);
        builder.Property(x => x.PostalCode).IsRequired(false).HasMaxLength(10);
        builder.Property(x => x.IsDefault).IsRequired().HasDefaultValue(false);

        builder.HasIndex(x => x.CustomerId);
    }
}