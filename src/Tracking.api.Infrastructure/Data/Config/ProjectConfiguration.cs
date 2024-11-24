using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tracking.api.Core.Aggregates.ProjectAggregate;

namespace Tracking.api.Infrastructure.Data.Config;

public class ProjectConfiguration : IEntityTypeConfiguration<Project>
{
  public void Configure(EntityTypeBuilder<Project> builder)
  {
    builder.HasKey(x => x.Id);

    builder.Property(x => x.Id).HasMaxLength(DataSchemaConstants.DEFAULT_ID_LENGTH);
    
    builder.Property(x => x.Description)
      .HasMaxLength(DataSchemaConstants.DEFAULT_DESCRIPTION_LENGTH)
      .IsRequired();

    builder.HasOne(x => x.Schema)
      .WithMany(x => x.Projects)
      .HasForeignKey(x => x.SchemaId);


    builder.HasMany(x => x.ProjectProcesses)
      .WithOne(x => x.Project)
      .HasForeignKey(x => x.ProjectId);
  }
}
