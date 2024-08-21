using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PipelineProcess.api.Core.Aggregates.FactoryAggregate;

namespace PipelineProcess.api.Infrastructure.Data.Config;

public class FactoryConfiguration : IEntityTypeConfiguration<Factory>
{
  public void Configure(EntityTypeBuilder<Factory> builder)
  {
    builder.HasKey(x => x.Id);

    builder.Property(x => x.Id).HasMaxLength(DataSchemaConstants.DEFAULT_ID_LENGTH);
    
    builder.Property(x => x.Title)
      .HasMaxLength(DataSchemaConstants.DEFAULT_TITLE_LENGTH)
      .IsRequired();

    builder.HasMany(x => x.Processes)
      .WithOne(x => x.Factory)
      .HasForeignKey(x => x.FactoryId);
  }
}
