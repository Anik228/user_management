using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace user_management.module.user.model
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("user"); 

            builder.HasKey(p => p.Id); 

          
            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(p => p.Email)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(p => p.Phone)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(p => p.Company)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(p => p.Department)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(p => p.role) 
                .IsRequired()
                .HasMaxLength(200);

           
            builder.Property(p => p.CreatedAt)
                .HasDefaultValueSql("GETUTCDATE()")
                .ValueGeneratedOnAdd();

            builder.Property(p => p.UpdatedAt)
                .HasDefaultValueSql("GETUTCDATE()")
                .ValueGeneratedOnUpdate();

         
            builder.Property(p => p.IsDeleted)
                .HasDefaultValue(false);
        }
    }
}
