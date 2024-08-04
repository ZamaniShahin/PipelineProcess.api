﻿using Ardalis.SharedKernel;
using PipelineProcess.api.Core.Aggregates.ProjectAggregate;

namespace PipelineProcess.api.Core.Aggregates.SchemaAggregate;

public class Schema
    : BaseEntity<Guid>, IAggregateRoot
{
  public Schema(string title, string? description)
  {
    Id = Guid.NewGuid();
    CreatedAt = DateTime.Now;
    IsRemoved = false;
    
    
    Title = title;
    Description = description;
  }

  public void Update(string title, string? description)
  {
    Title = title;
    Description = description;

    this.Modified();
  }
  public string Title { get; private set; }
  public string? Description { get; private set; }
  
  private List<Project> _projects = [];
  public IEnumerable<Project> Projects => _projects.AsEnumerable();

  private void Modified()
    => this.ModifiedAt = DateTime.Now;
}
