using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PipelineProcess.api.Core.Aggregates.ProcessAggregate;

namespace PipelineProcess.api.Infrastructure.Data.Config;

public class TodoItemConfiguration : IEntityTypeConfiguration<Process>
{
  public void Configure(EntityTypeBuilder<Process> builder)
  {
    builder.HasKey(x => x.Id);

    builder.Property(x => x.Id).HasMaxLength(DataSchemaConstants.DEFAULT_ID_LENGTH);

    builder.Property(x => x.Title).HasMaxLength(DataSchemaConstants.DEFAULT_TITLE_LENGTH).IsRequired();

    builder.Property(x => x.Description).HasMaxLength(DataSchemaConstants.DEFAULT_DESCRIPTION_LENGTH);

    builder.HasMany(x => x.ProcessSheets)
      .WithOne(x => x.TodoItem)
      .HasForeignKey(x=>x.TodoItemId);
  }
}
