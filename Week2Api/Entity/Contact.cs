using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Week2Api.Entity;

[Table("Contact", Schema = "dbo")]
public class Contact : BaseEntity
{
    public int CustomerId { get; set; }
    public virtual Customer Customer { get; set; }

    public string ContactType { get; set; }
    public string Information { get; set; }
    public bool IsDefault { get; set; }
}

public class ContactConfiguration : IEntityTypeConfiguration<Contact>
{
    public void Configure(EntityTypeBuilder<Contact> builder)
    {
        builder.Property(x => x.InsertDate).IsRequired();
        builder.Property(x => x.InsertUserId).IsRequired();
        builder.Property(x => x.UpdateDate).IsRequired(false);
        builder.Property(x => x.UpdateUserId).IsRequired(false);
        builder.Property(x => x.IsActive).IsRequired().HasDefaultValue(true);

        builder.Property(x => x.CustomerId).IsRequired();
        builder.Property(x => x.ContactType).IsRequired().HasMaxLength(10);
        builder.Property(x => x.Information).IsRequired().HasMaxLength(100);
        builder.Property(x => x.IsDefault).IsRequired().HasDefaultValue(false);

        builder.HasIndex(x => x.CustomerId);
        builder.HasIndex(x => new {x.Information, x.ContactType}).IsUnique();
    }
}